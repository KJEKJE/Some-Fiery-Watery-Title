using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform projectileSpawn;
    //public Transform projectileSpawn2;
    public GameObject projectile; //fireball
    public GameObject projectile2; //droplet
    public int projectileID;
    public float launchSpeed = 5f;
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
        //dir = projectileSpawn2.rotation.z; //for later?
        //Debug.Log("Direction of projectile is: " + dir); checks that the player is facing the right direction. not needed atm.
        chargeTime = 0;
        projectileID = 0; //i.e. fireball
    }

    // Update is called once per frame
    void Update()
    {
        //fireball//        
        if (Input.GetKey(KeyCode.X) || Input.GetMouseButton(0)) //charges fireball
        {
            if (projectile != null) //is a fireball on this character?
            {
                //while space is down, count time held and build up multiplier
                chargeTime = chargeTime + Time.deltaTime;
                projectileID = 1; //fireball
                //chargeTime++;
            }
            else
            {
                Debug.Log("Passed ok. It's Flare's move ^^");
            }
            
        }

        if (Input.GetKeyUp(KeyCode.X) || Input.GetMouseButtonUp(0)) 
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
            Pew(projectileID); //releases fireball
            chargeTime = 0;
            projectileID = 0;

        }

        //droplet//
        if (Input.GetKey(KeyCode.Space)) //charges droplet
        {
            if (projectile2 != null) //if an item is present in this slot
            {
                //while space is down, count time held and build up multiplier
                chargeTime = chargeTime + Time.deltaTime;
                projectileID = 2; //droplet
                //chargeTime++;
            }
            else
            {
                Debug.Log("Passed ok. It's Waterform's move ^^");
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Power timer: " + chargeTime); //calculates droplet

            if (chargeTime <= 0.6f)
            {
                multiplier = 1f; //short
            }
            else if (chargeTime > 0.6f && chargeTime <= 1.0f)
            {
                multiplier = 2f; //medium
            }
            else if (chargeTime > 1f && chargeTime <= 1.5f)
            {
                multiplier = 3f; //far
            }
            else
            {
                multiplier = 4f; //very far
            }

            //when let go, deduce multiplier
            Pew(projectileID); //releases droplet
            chargeTime = 0;
            projectileID = 0;

        }

    }

    void Pew(int projID)
    {
        //CHECK
        //how to pass through the fact that there's no item there?

            switch (projID)
            {
                case 1:
                    //Debug.Log("fireball.");

                    //float multiplier = launchSpeed * multiplier;
                    Debug.Log("It's a fireball! Multiplier: " + multiplier);


                    Fireball instance = projectile.GetComponent<Fireball>(); //info for the fireball
                    instance.chargeLevel = multiplier; //used for determining damage/size/etc.
                    
                    projectile.transform.localScale *= multiplier; //changes fireball size
                    Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
                    projectile.transform.localScale /= multiplier; //resets it back to orignal size

                //rb.velocity = new Vector2(launchSpeed, 0); //temporary launch
                                
                break;


                case 2:
                    //Debug.Log("droplet.");

                    Debug.Log("It's a droplet! Multiplier: " + multiplier);
                    float aquaDist = launchSpeed * multiplier;
                    Debug.Log(aquaDist); //confirm pew
                                         //projectile.transform.localScale *= multiplier; //changes fireball size

                    Droplet instance2 = projectile2.GetComponent<Droplet>();
                    instance2.dropletSpeed = aquaDist;
                    Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
                    //projectile.transform.localScale /= multiplier; //resets it back to orignal size


                    //projectile2.transform.position = new Vector2(aquaDist, 0); //temporary launch

                    //Debug.Log("fern.");

                //Debug.Log("Multiplier: " + multiplier);
                //float fernSpeed = launchSpeed * multiplier;
                //Debug.Log(fernSpeed); //confirm pew

                ////projectile.transform.localScale *= multiplier; //changes fern size (will update soon, just for reference.)

                //Fern instance = projectile.GetComponent<Fern>(); //grabs info and sends to projectile?
                //instance.fernFullSpeed = fernSpeed; //makes the projectile's full speed update with the newly calcukated fern speed
                //Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation); //launch it lol

                    break;

                default:
                    break;
            }
        
        

    }
       
}
