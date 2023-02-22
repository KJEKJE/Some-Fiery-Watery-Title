using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * fireballSpeed; //temporary
    }

}
