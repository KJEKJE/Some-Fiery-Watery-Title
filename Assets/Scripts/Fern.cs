using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fern : MonoBehaviour
{
    public float fernFullSpeed = 3f;
    //public bool isOpen = false;
    public Rigidbody2D rb;
    public string elemType = "grass";
    public string statusEffect = "barb";
    //public MovementShanopi itemRef;

    void Start()
    {
        //fernSpeed = fernSpeed * itemRef.multiplier;
        rb.velocity = transform.right * fernFullSpeed; //temporary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?

        HealthScript wateryBoi = collision.GetComponent<HealthScript>(); //calls health script from a player
        if (wateryBoi != null)
        {
            string whichPlayer = collision.name;

            if (whichPlayer == "Waterform")
            {
                wateryBoi.TakeDamage(2);
                Debug.Log("Waterform took damage? It hurts! >_<");
                //play a slurp sound
            }
            else if (whichPlayer == "Flare")
            {
                wateryBoi.TakeDamage(1);
                Debug.Log("Flare took damage? Not very effective..");
                //play a fwoosh sound
            }
            else
            {
                Debug.Log("umm, either you hit yourself... or they've merged. And you might've just lost.");
                //play a fizzle sound
            }

        }

        Destroy(gameObject); //despawns
    }

}
