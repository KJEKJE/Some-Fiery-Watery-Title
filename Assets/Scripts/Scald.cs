using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scald : MonoBehaviour
{
    public float scaldSpeed = 15f;
    //public bool isOpen = false;
    public Rigidbody2D rb;
    public string elemType = "merged";
    public string statusEffect = "burn";
    //public float stunChance = 2f; //note to add a stun chance based off speed of projectile. will be a base 2/10 stun rate.

    void Start()
    {
        //dropletSpeed = GetComponent<ShootFireball>;
        rb.velocity = transform.right * scaldSpeed; //temporary
        //rb.gravityScale = dropletSpeed; //lol this change is hilarious
        //rb.gravityScale = 1f; //great for a second projectile?
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?

        HealthScript scaldBoi = collision.GetComponent<HealthScript>(); //calls Gate script
        if (scaldBoi != null)
        {
            //string whichPlayer = collision.name;

            if (collision.tag == "Base Enemy")/*(whichPlayer == "Shanopi_A")*/ //was the previous code
            {
                scaldBoi.TakeDamage(2 + 3);
                Debug.Log("Merge Hit! Scald!");
                //play a slurp sound
            }
            else
            {
                Debug.Log("Hm, either you hit yourself... or you've merged. Hehehe.");
                //play a fizzle sound
            }

        }

        //area for merging/colliding with a wall or other enemy.

        Destroy(gameObject); //despawns
    }

}