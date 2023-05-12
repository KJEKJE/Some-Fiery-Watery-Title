using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed = 10f;
    public bool isOpen = false;
    public Rigidbody2D rb;
    public string elemType = "fire";
    public string statusEffect = "burn";
    public float chargeLevel = 0;
    public ShootProjectile chargeRef; //refers to the components from the player shooting a fireball.



    void Start()
    {
        rb.velocity = transform.right * fireballSpeed; //temporary?

        //get info from Flare somehow, or directly refer to the resultant output multiplier.

        //chargeLevel = chargeRef.GetComponent<ShootProjectile>().multiplier;
        
        //chargeLevel = chargeRef.multiplier;
        Debug.Log(chargeLevel); //checking
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?
        
        Gate gate = collision.GetComponent<Gate>(); //calls Gate script
        if (gate != null)
        {
            gate.DoorOpened();
        }

        //checking for hit detection of players/enemies
        HealthScript grassyBoi = collision.GetComponent<HealthScript>(); //calls health script from a player

        if (grassyBoi != null)
        {
            string whichPlayer = collision.name;

            if (whichPlayer == "Shanopi_A")
            {
                grassyBoi.TakeDamage(3);
                Debug.Log("Shanopi took damage? It burns! o_o");
                //play a FWOOSH sound
            }
            else if (whichPlayer == "Waterform")
            {
                grassyBoi.TakeDamage(0);
                Debug.Log("Waterform took no damage. You did literally nothing. You warmed him up I guess..?");
                //play a shloop sound
            }
            else
            {
                //grassyBoi.TakeDamage(-1); might be fun for gaining fire HP
                Debug.Log("Hm. Either you hit yourself... or you've merged?");
                //play a crackling fire sound
            }

        }

        Debug.Log("Damage done from fireball: " + chargeLevel); //determines how much damage that fireball would do to an enemy/player

        //area for merging/colliding with a droplet

        Destroy(gameObject); //despawns
    }

}
