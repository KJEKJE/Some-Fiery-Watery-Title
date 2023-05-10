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

        Debug.Log("Damage done from fireball: " + chargeLevel); //determines how much damage that fireball would do to an enemy/player

        Destroy(gameObject); //despawns
    }

}
