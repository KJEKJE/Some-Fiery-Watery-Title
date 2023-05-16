using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public float dropletSpeed = 15f;
    //public bool isOpen = false;
    public Rigidbody2D rb;
    public string elemType = "water";
    public string statusEffect = "stun";

    void Start()
    {
        //dropletSpeed = GetComponent<ShootFireball>;
        rb.velocity = transform.right * dropletSpeed; //temporary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?

        HealthScript flareBoi = collision.GetComponent<HealthScript>(); //calls Gate script
        if (flareBoi != null)
        {            
            string whichPlayer = collision.name;

            if (collision.tag == "Base Enemy")/*(whichPlayer == "Shanopi_A")*/ //was the previous code
            {
                flareBoi.TakeDamage(2);
                Debug.Log("Shanopi took damage? It's fine enough ._.");
                //play a slurp sound
            }
            else if (whichPlayer == "Flare")
            {
                flareBoi.TakeDamage(4);
                Debug.Log("Flare took damage? AHHHHHHH >^<;");
                //play a FIZZLE sound
            }
            else
            {
                Debug.Log("Hm, either you hit yourself... or you've merged. Hehehe.");
                //play a bubbly sound
            }

        }

        //area for merging/colliding with a fireball

        Destroy(gameObject); //despawns
    }

}
