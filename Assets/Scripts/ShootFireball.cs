using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform projectileSpawn;
    public GameObject projectile;
    public float launchSpeed = 0f;
    public float xSin;
    public float ySin; //sohcahtoa at some point
    public float dir;

    public float chargeTime; //how long flare holds a fireball for
    public float multiplier; //how powerful the fireball becomes
    
    // Start is called before the first frame update
    void Start()
    {
        launchSpeed = 5f; //initial launch speed
        dir = projectileSpawn.rotation.z; //for later?
        Debug.Log("Direction of projectile is: " + dir);
        chargeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //charges fireball
        {
            //while space is down, count time held and build up multiplier
            chargeTime = chargeTime + Time.deltaTime;
            //chargeTime++;
        }

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            Debug.Log("Power timer: " + chargeTime); //calculates fireball
            
            if (chargeTime <= 0.6f)
            {
                multiplier = 1f; //small
            }
            else if (chargeTime > 0.6f && chargeTime <= 1.0f)
            {
                multiplier = 2f; //medium
            }
            else if (chargeTime > 1f && chargeTime <= 1.5f)
            {
                multiplier = 3f; //large
            }
            else
            {
                multiplier = 4f; //dangerous
            }

            //when let go, deduce multiplier
            Pew(); //releases fireball
            chargeTime = 0;            
            
        }
    }

    void Pew()
    {
        Debug.Log("Multiplier: " + multiplier);
        projectile.transform.localScale *= multiplier; //changes fireball size
        Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        projectile.transform.localScale /= multiplier; //resets it back to orignal size


        rb.velocity = new Vector2(launchSpeed, 0); //temporary launch
    }
       
}
