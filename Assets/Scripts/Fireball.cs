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
    public float chargeLevel = 1f;
    //public ShootProjectile chargeRef; //refers to the components from the player shooting a fireball.

    public GameObject mergedProj;
    public Transform mergedSpawn;



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
        float dmgCheck = 0f; //superficial addition, but might help later.

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

            //if (whichPlayer == "Shanopi_A")
            //{
            //    grassyBoi.TakeDamage(3);
            //    Debug.Log("Shanopi took damage? It burns! o_o");
            //    //play a FWOOSH sound
            //}
            if (collision.tag == "Base Enemy")
            {
                grassyBoi.TakeDamage(3 * chargeLevel);
                Debug.Log("Shanopi took damage? It burns! o_o");
                dmgCheck = 3f;
                //play a FWOOSH sound
            }
            else if (whichPlayer == "Waterform")
            {
                grassyBoi.TakeDamage(0);
                Debug.Log("Waterform took no damage. You did literally nothing. You warmed him up I guess..?");
                dmgCheck = 0f;
                //play a shloop sound
            }
            else
            {
                //grassyBoi.TakeDamage(-1); might be fun for gaining fire HP
                Debug.Log("Hm. Either you hit yourself... or you've merged?");
                //dmgCheck = -1f;
                //play a crackling fire sound
            }

        }

        Debug.Log("Damage done from fireball: " + (chargeLevel * dmgCheck)); //determines how much damage that fireball would do to an enemy/player

        //area for merging/colliding with a droplet
        Droplet dripDrip = collision.GetComponent<Droplet>(); //grabs info from droplet
        if (dripDrip != null)
        {
            Debug.Log("collided with droplet?");

            Debug.Log("Multiplier: " + chargeLevel); //identifies what level the fireball/droplet is at
            float mergePower = 3 /*fireballDamage*/ * chargeLevel;
            //float mergeSpeed = 3 /*fireballSpeed*/ * chargeLevel;

            Debug.Log(mergePower); //confirm merge pew

            MergedProjectile instance = mergedProj.GetComponent<MergedProjectile>(); //grabs info and sends to projectile?
            //instance.mergeFullSpeed = mergeSpeed; //makes the projectile's full speed update with the newly calculated fern speed
            instance.mergeFullPower = mergePower; //makes the projectile's full speed update with the newly calculated fern speed
            instance.fireballFullSpeed = fireballSpeed;
            Instantiate(mergedProj, mergedSpawn.position, mergedSpawn.rotation); //launch it lol
        }

        Destroy(gameObject); //despawns
    }

}
