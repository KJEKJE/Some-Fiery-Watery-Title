using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapShard : MonoBehaviour
{
    public bool isCollected = false;
    //public GameObject instance;

    public bool aquaCharged = false;
    public bool fireCharged = false;
    public Transform whoCollectedMe;




    //// Start is called before the first frame update
    ////void Start()
    ////{

    ////}

    //Update is called once per frame
    void Update()
    {
        if (isCollected ) //if both are true
        {
            if (fireCharged)
            {
                //whoCollectedMe = new Transform(); //want to have it so it attached to Flare + moves with him
            }
            else if (aquaCharged)
            {
                //whoCollectedMe = new Transform(); //want to have it so it attached to Waterform + moves with them
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag); //what did you hit?

        if (collision.tag == "Player 1") //Flare
        {
            fireCharged = true;
            Debug.Log("Key has been collected. Fire Charged.");
            isCollected = true;
            //plays a zap! sound
            
            //Destroy(gameObject); //despawns after touching Flare or Waterform
        }
        else if (collision.tag == "Player 2") //Waterform
        {
            aquaCharged = true;
            Debug.Log("Key has been collected. Aqua Charged.");
            isCollected = true;
            //plays a zap! sound
            
            //Destroy(gameObject); //despawns after touching Flare or Waterform
        }
        else
        {
            Debug.Log("zap.");
            //plays a bzzt sound
        }

        
        //MovementWaterform aquais = collision.GetComponent<MovementWaterform>(); //calls Gate script
        //if (aquais != null) //i.e. touching player2
        //{
        //    Debug.Log("Key has been collected.");
        //    isCollected = true;
        //    //GetComponent<Gate>().DoorOpened();

        //    if (instance != null) //checks if door is still there
        //    {
        //        Gate gate = instance.GetComponent<Gate>(); //calls Gate script
        //        Debug.Log(gate);

        //        if (gate != null)
        //        {
        //            gate.DoorOpened();
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("Door has already been broken ._.");
        //    }
        //}
                     
    }

    //void Despawn()
    //{
    //    //animation for later?
    //    Destroy(gameObject);
    //}
}
