using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public GameObject player;
    public float playerHealth = 15f;
    [SerializeField] private GameManager game;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //playerHealth = 15f; //set it to a base 15 for now
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TakeDamage(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TakeDamage(3);
        }
    }

    public void TakeDamage(int ouch)
    {
        //identify who's health it is?
        Debug.Log("Took " + ouch + " damage.");
        playerHealth = playerHealth +- ouch;

        if (playerHealth <= 0) //HP is reduced to 0
        {
            Debug.Log("Player now has " + playerHealth + " HP left.");
            playerHealth = 0; //sets to 0, is considered ded
            Debug.Log("Player is defeated. " + playerHealth + " HP.");

            if (tag == "Player 1" || tag == "Player 2") //implies one of the players has been defeated.
            {
                game.DeathChecker(); //checking for death
            }
            else
            {
                Destroy(gameObject); //hopefully doesn't cause a break. one way to find out! ^^;
            }
            
        }
        else
        {
            Debug.Log("Player now has " + playerHealth + " HP left.");
        }        
        
    }


}
