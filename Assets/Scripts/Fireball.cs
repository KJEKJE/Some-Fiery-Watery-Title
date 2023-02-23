using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed = 10f;
    public bool isOpen = false;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * fireballSpeed; //temporary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?
        
        Gate gate = collision.GetComponent<Gate>(); //calls Gate script
        if (gate != null)
        {
            gate.DoorOpened();
        }

        Destroy(gameObject); //despawns
    }

}
