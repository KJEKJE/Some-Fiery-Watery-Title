using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergedProjectile : MonoBehaviour
{
    //excess code//

    //public bool isOpen = false;
    //public MovementShanopi itemRef;

    //public float fernFullSpeed = 3f;
    public float dropletFullSpeed = 15f;
    public float fireballFullSpeed = 10f;
    public int fireballDamage = 3; //will be instanced soon
    public int dropletDamage = 3; //will be instanced soon

    public Rigidbody2D rb;
    public string elemType = "merged"; //will change eventually
    public string statusEffect = "explosive"; //likely to keep?

    private int mergeDamage;
    private float mergeSpeed;

    void Start()
    {
        //fernSpeed = fernSpeed * itemRef.multiplier;
        mergeDamage = fireballDamage + dropletDamage;
        rb.velocity = transform.right * mergeSpeed; //temporary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?

        HealthScript mergeBoi = collision.GetComponent<HealthScript>(); //calls health script from a player
        if (mergeBoi != null)
        {
            string whichPlayer = collision.name;

            if (whichPlayer == "Shanopi_A")
            {
                mergeBoi.TakeDamage(mergeDamage);
                Debug.Log("OHHHHHKAY that'll hurt ^^;");
                //play an explosion :]
            }
            //else if (whichPlayer == "Flare")
            //{
            //    mergeBoi.TakeDamage(1);
            //    Debug.Log("Flare took damage? Not very effective..");
            //    //play a fwoosh sound
            //}
            else
            {
                Debug.Log("umm, you hit yourself? impressive.");
                //play a fizzle sound
            }

        }

        Destroy(gameObject); //despawns
    }

}
