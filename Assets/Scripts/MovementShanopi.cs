using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShanopi : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float shanopiSpeed = 0f;
    public float timer;
    public Rigidbody2D rb; //shanopi's rigidbody
    public GameObject enemy; //shanopi's gameObject connection

    //projectile bits
    public Transform projectileSpawn; //spawner position
    public GameObject projectile; //fern gameObject
    public int projectileID; //will depend on different items
    public float launchSpeed = 3f; //
    public float dir; //for later

    public float chargeTime; //how long flare holds a fireball for
    public float multiplier; //how powerful the fireball becomes

    // Start is called before the first frame update
    void Start()
    {
        shanopiSpeed = 5f; //base speed

        launchSpeed = 3f; //initial launch speed
        dir = projectileSpawn.rotation.z; //for later     
        chargeTime = 0;
        projectileID = 0; //i.e. fern
    }

    // Update is called once per frame
    void Update()
    {
        //fireball//        
        if (Input.GetKey(KeyCode.F)) //charges fireball
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
                Debug.Log("Passed ok. Shanopi's shooting? ^^");
            }

        }

        if (Input.GetKeyUp(KeyCode.F))
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
            ShanoPew(projectileID); //releases fireball
            chargeTime = 0;
            projectileID = 0;

        }
    }

    //pewpew
    private void ShanoPew(int projID)
    {
        //CHECK
        //how to pass through the fact that there's no item there?

        switch (projID)
        {
            case 1:
                Debug.Log("fern.");

                Debug.Log("Multiplier: " + multiplier);
                float fernSpeed = launchSpeed * multiplier;
                Debug.Log(fernSpeed); //confirm pew

                //projectile.transform.localScale *= multiplier; //changes fern size (will update soon, just for reference.)

                Fern instance = projectile.GetComponent<Fern>(); //grabs info and sends to projectile?
                instance.fernFullSpeed = fernSpeed; //makes the projectile's full speed update with the newly calcukated fern speed
                instance.fernSpikeDmg = (multiplier - 1f); //higher hits will deal base spike PLUS the multiplier, essentially being an adder rather than a multiplier.
                Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation); //launch it lol

                //projectile.transform.localScale /= multiplier; //resets it back to orignal size

                //rb.velocity = new Vector2(launchSpeed, 0); //temporary launch

                break;

            case 2:
                //Debug.Log("droplet.");

                //Debug.Log("Multiplier: " + multiplier);
                //float aquaDist = launchSpeed * multiplier;
                //Debug.Log(aquaDist); //confirm pew
                //                     //projectile.transform.localScale *= multiplier; //changes fireball size
                //Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
                ////projectile.transform.localScale /= multiplier; //resets it back to orignal size


                ////projectile2.transform.position = new Vector2(aquaDist, 0); //temporary launch

                break;

            default:
                break;
        }


    }
}
