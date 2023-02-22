using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaKey : MonoBehaviour
{
    public bool isCollected = false;
    public GameObject instance;


    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    //public void KeyGot()
    //{

    //    //Key has been collected?

    //    //Despawn();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //what did you hit?
        

        Movement2 aquais = collision.GetComponent<Movement2>(); //calls Gate script
        if (aquais != null) //i.e. touching player2
        {
            Debug.Log("Key has been collected.");
            isCollected = true;
            //GetComponent<Gate>().DoorOpened();

            if (instance != null) //checks if door is still there
            {
                Gate gate = instance.GetComponent<Gate>(); //calls Gate script
                Debug.Log(gate);

                if (gate != null)
                {
                    gate.DoorOpened();
                }
            }
            else
            {
                Debug.Log("Door has already been broken ._.");
            }
            

            Destroy(gameObject); //despawns after touching player 2 AND gate is down
        }

    }

    //void Despawn()
    //{
    //    //animation for later?
    //    Destroy(gameObject);
    //}
}
