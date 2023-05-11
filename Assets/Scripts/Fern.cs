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

        HealthScript wateryBoi = collision.GetComponent<HealthScript>(); //calls Gate script
        if (wateryBoi != null)
        {
            wateryBoi.TakeDamage(2);
            Debug.Log("Waterform took damage?");
        }

        Destroy(gameObject); //despawns
    }

}
