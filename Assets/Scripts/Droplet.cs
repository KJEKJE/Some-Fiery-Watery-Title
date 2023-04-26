using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public float dropletSpeed = 15f;
    //public bool isOpen = false;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * dropletSpeed; //temporary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?

        MovementFlare flareBoi = collision.GetComponent<MovementFlare>(); //calls Gate script
        if (flareBoi != null)
        {
            //flareBoi.TakeDamage();
            Debug.Log("Flare took damage?");
        }

        Destroy(gameObject); //despawns
    }

}
