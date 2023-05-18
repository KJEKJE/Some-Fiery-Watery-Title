using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public MovementWaterform jumpingInfo;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = GetComponent<MovementWaterform>().isWaterformGrounded; //always calls to match what waterform's movements determine and vice versa
        if (jumpingInfo.isWaterformGrounded != true && jumpingInfo.isJumping)
        {
            isGrounded = false;
            jumpingInfo.isWaterformGrounded = false;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?

        //HealthScript flareBoi = collision.GetComponent<HealthScript>(); //calls Gate script
        //MovementWaterform jumpingTraits = collision.GetComponent<MovementWaterform>();

        if (collision.tag == "Bushes" && jumpingInfo.isJumping) //the ground lol
        {
            isGrounded = true;
            jumpingInfo.isWaterformGrounded = true;

            jumpingInfo.verticalMove = Input.GetAxis("Vertical");
            jumpingInfo.isJumping = false; //for now.
            jumpingInfo.yVel = 0f;
            jumpingInfo.rb.velocity = new Vector2(jumpingInfo.horizontalMove * jumpingInfo.waterformSpeed, jumpingInfo.verticalMove * jumpingInfo.waterformSpeed);
            jumpingInfo.timer = 0.5f;
            Debug.Log("touching grass?"); //register left!
        }
        else if (collision.tag != "Bushes" && jumpingInfo.isJumping == true)
        {
            isGrounded = false;
            jumpingInfo.isWaterformGrounded = false;
        }
        else
        {
            isGrounded = false;
            jumpingInfo.isWaterformGrounded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("leaving.");
        Debug.Log(collision.tag);

        if (collision.tag == "Bushes")
        {
            isGrounded = false;
            jumpingInfo.isWaterformGrounded = false;
        }
    }
}
