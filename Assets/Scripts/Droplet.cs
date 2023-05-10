using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public float dropletSpeed = 15f;
    //public bool isOpen = false;
    public Rigidbody2D rb;
    public string elemType = "water";

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
            flareBoi.TakeDamage(2);
            Debug.Log("Flare took damage?");
        }

        Destroy(gameObject); //despawns
    }

}
