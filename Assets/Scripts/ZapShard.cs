using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapShard : MonoBehaviour
{
    public bool isCollected = false;
    //public GameObject instance;

    public bool aquaCharged = false;
    public bool fireCharged = false;
    //public Transform whoCollectedMe;
    //public Interactable shardCollector;

    //public bool isHeld = false;
    public Transform shardHolder;
    public float cooldown = 0f;



    //// Start is called before the first frame update
    ////void Start()
    ////{

    ////}

    //Update is called once per frame
    void Update()
    {

        if (cooldown <= 0f) //shard held item cooldown
        {
            if (isCollected) //if both are true
            {
                if (fireCharged)
                {
                    //whoCollectedMe = new Transform(); //want to have it so it attached to Flare + moves with him
                    //gameObject.transform.parent = shardHolder;
                    gameObject.transform.position = shardHolder.position;
                }
                else if (aquaCharged)
                {
                    //whoCollectedMe = new Transform(); //want to have it so it attached to Waterform + moves with them
                    //gameObject.transform.parent = shardHolder;
                    gameObject.transform.position = shardHolder.position;
                }
                else
                {
                    Debug.Log("wait... who collected you?");
                }
            }
            else
            {
                gameObject.transform.parent = null; //detaches from user
            }
        }
        else
        {
            Debug.Log("cooling down...");
            cooldown -= Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.E)) //drops item
        {
            //resets parameters
            shardHolder = null;

            aquaCharged = false;
            fireCharged = false;

            isCollected = false;
            gameObject.transform.parent = null; //detaches from user

            Debug.Log("Shard has been dropped. Starting cooldown.");
            cooldown = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        

        if (cooldown <= 0)
        {
            Debug.Log(collision.tag); //what did you hit?

            if (collision.tag == "Player 1") //Flare
            {
                fireCharged = true;
                Debug.Log("Key has been collected. Fire Charged.");
                //shardHolder = collision;

                shardHolder = collision.GetComponent<Transform>().GetChild(3);
                Debug.Log(shardHolder);

                gameObject.transform.parent = shardHolder;

                //Transform flareHasShard = collision.GetComponent<Transform>();
                //flareHasShard = shardHolder;

                isCollected = true;
                //plays a zap! sound

                //Destroy(gameObject); //despawns after touching Flare or Waterform
            }
            else if (collision.tag == "Player 2") //Waterform
            {
                aquaCharged = true;
                Debug.Log("Key has been collected. Aqua Charged.");

                shardHolder = collision.GetComponent<Transform>().GetChild(3);
                Debug.Log(shardHolder);

                gameObject.transform.parent = shardHolder;

                isCollected = true;
                //plays a zap! sound

                //Destroy(gameObject); //despawns after touching Flare or Waterform
            }
            else
            {
                Debug.Log("zap.");
                //plays a bzzt sound
            }

        }
        else
        {
            Debug.Log("zap. zap.");
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
