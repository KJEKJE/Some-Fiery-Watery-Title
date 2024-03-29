using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFlare : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float flareSpeed = 0f;
    public float timer;
    public Rigidbody2D rb; //rigidbody
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        flareSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //left/right
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed/*rb.velocity.y*/);
            timer = 0.5f;
            Debug.Log("moving left?"); //register left!
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed/*rb.velocity.y*/);
            timer = 0.5f;
            Debug.Log("moving right?"); //register left!
        }
        else
        {
            horizontalMove = 0; //stop moving.
            //verticalMove = 0; //stop moving.
            rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed); //should be = to 0,0
        }

        if (Input.GetKey(KeyCode.W))
        {
            verticalMove = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed);
            timer = 0.5f;
            Debug.Log("moving up?"); //register left!
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalMove = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed);
            timer = 0.5f;
            Debug.Log("moving down?"); //register left!
        }
        else
        {
            //horizontalMove = 0; //stop moving.
            verticalMove = 0; //stop moving.
            rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed); //should be = to 0,0
        }


        if (horizontalMove == 0 && verticalMove == 0)
        {
            //Debug.Log("stopped moving.");
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0.5f;
            }
        }

        //TurnAroundBee(); not important atm
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Gate gate = collision.GetComponent<Gate>(); //calls Gate script
        //if (gate != null)
        //{
        //    gate.DoorOpened();
        //}

        horizontalMove = 0; //stop moving.
        verticalMove = 0; //stop moving.
        rb.velocity = new Vector2(horizontalMove * flareSpeed, verticalMove * flareSpeed); //should be = to 0,0
    }
}
