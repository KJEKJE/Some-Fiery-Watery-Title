using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float playerHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 15f; //set it to a base 15 for now
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

    private void TakeDamage(int ouch)
    {
        Debug.Log("Took " + ouch + " damage.");
        playerHealth = playerHealth +- ouch;
        Debug.Log("Player now has " + playerHealth + " HP left.");
    }
}
