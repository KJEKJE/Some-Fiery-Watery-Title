using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fern : MonoBehaviour
{
    public float fernFullSpeed = 3f;
    public float fernSpikeDmg = 1f;
    //public bool isOpen = false;
    public Rigidbody2D rb;
    public string elemType = "grass";
    public string statusEffect = "barb";
    //public float barbChance = 2f; //note to add a barb chance based off speed of projectile. will be a base 2/10 barbed rate.

    //public MovementShanopi itemRef;

    void Start()
    {
        //fernSpeed = fernSpeed * itemRef.multiplier;
        rb.velocity = transform.right * fernFullSpeed; //temporary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?
        float dmgCheck = 0f; //superficial addition, but might help later.

        HealthScript wateryBoi = collision.GetComponent<HealthScript>(); //calls health script from a player
        if (wateryBoi != null)
        {
            string whichPlayer = collision.name;

            if (whichPlayer == "Waterform")
            {
                wateryBoi.TakeDamage(2 + fernSpikeDmg);
                Debug.Log("Waterform took damage? It hurts! >_<");
                dmgCheck = (2 + fernSpikeDmg);
                //play a slurp sound
            }
            else if (whichPlayer == "Flare")
            {
                wateryBoi.TakeDamage(1 + fernSpikeDmg);
                Debug.Log("Flare took damage? Not very effective..");
                dmgCheck = (1 + fernSpikeDmg);
                //play a fwoosh sound
            }
            else
            {
                Debug.Log("umm, either you hit yourself... or they've merged. And you might've just lost.");
                //play a fizzle sound
            }
            
        }
        Debug.Log("Damage done from fern: " + (dmgCheck));
        //area for merging/colliding with another projectile

        Destroy(gameObject); //despawns
    }

}
