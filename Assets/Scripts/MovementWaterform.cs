using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWaterform : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float waterformSpeed = 0f;
    public float timer;
    private float maxTimer = 1f;
    public bool isJumping = false;
    public float yVel = 0f;
    public Rigidbody2D rb; //rigidbody
    public GameObject player;
    public GameObject groundChecker;
    public SortingLayer sortLayer;

    // Start is called before the first frame update
    void Start()
    {
        waterformSpeed = 10f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE LEFT AND RIGHT
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * waterformSpeed, verticalMove * waterformSpeed/*rb.velocity.y*/);
            timer = 0.5f;
            Debug.Log("moving left?"); //register left!
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * waterformSpeed, verticalMove * waterformSpeed/*rb.velocity.y*/);
            timer = 0.5f;
            Debug.Log("moving right?"); //register left!
        }
        else
        {
            horizontalMove = 0;
            rb.velocity = new Vector2(horizontalMove * waterformSpeed, /*verticalMove * yVel*/ 0); //should be = to 0,0
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isJumping != true) //TO BE CHANGED//
        {
            verticalMove = Input.GetAxis("Vertical");
            //rb.velocity = new Vector2(horizontalMove * waterformSpeed, verticalMove * waterformSpeed);
            isJumping = true;
            yVel = 5f; //sets the height that it'll change by
            timer = 0; //trying again
            rb.velocity = new Vector2(horizontalMove * waterformSpeed, yVel); //boing.
            Debug.Log("pressed jump."); //register left!
        }

        if (Input.GetKey(KeyCode.DownArrow)) //TO BE CHANGED//
        {
            verticalMove = Input.GetAxis("Vertical");
            isJumping = false; //for now.
            yVel = 0f;
            rb.velocity = new Vector2(horizontalMove * waterformSpeed, verticalMove * waterformSpeed);
            timer = 0.5f;
            Debug.Log("moving down?"); //register left!
        }
    }

        //JUMPING//
     void FixedUpdate()
     {
        
        //JUMPING IN THE AIR//
        if (isJumping == true) //while in the air :D
        {
            if (yVel > -10f)
            {
                yVel = yVel - 0.1f; //decelerating in the air...
            }
            else if (yVel <= -10f)
            {
                yVel = -10f;
                Debug.Log("max falling!"); //still falling...
            }
            rb.velocity = new Vector2(horizontalMove * waterformSpeed, yVel); //boing.
            timer += Time.deltaTime; //checks for how long
        }

        
        

        

        //if (horizontalMove == 0 && verticalMove == 0)
        //{
        //    //Debug.Log("stopped moving.");
        //    timer -= Time.deltaTime;
        //    if (timer <= 0f)
        //    {
        //        timer = 0.5f;
        //    }
        //}

        //TurnAround(); not important atm
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name); //what did you hit?



    //    //private void DetectForGround()
    //    //{
    //    //    GetComponent(groundChecker);
    //    //    Debug.Log(sortLayer)
    //    //}
    //}
}
