using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemergeController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float eleSpeed = 0f;
    public float timer = 50f; //how long potentially a merge could last. to add in a future case.

    public Rigidbody2D rb; //shanopi's rigidbody
    public GameObject mergePlayer; //shanopi's gameObject connection

    //projectile bits
    public Transform projectileSpawn; //spawner position
    public GameObject projectile; //fern gameObject
    public int projectileID; //will depend on different items
    public float launchSpeed = 6f; //faster!
    public float dir; //for later

    public float chargeTime; //how long they hold a mergeball for
    public float multiplier; //how powerful the mergeball becomes

    public Sprite scaldImage;
    public Sprite vapourImage;
    public Sprite steamImage;

    //for ref:
    //projID 1 = scald
    //projID 2 = perfect merge
    //projID 3 = steam
    //projID 4 = ...plasma? electricity?


    // Start is called before the first frame update
    void Start()
    {
        eleSpeed = 8f; //base speed will be quicker

        launchSpeed = 3f + 3f; //initial launch speed
        dir = projectileSpawn.rotation.z; //for later     
        chargeTime = 0;
        projectileID = 0; //i.e. multiple projectiles
    }

    // Update is called once per frame
    void Update()
    {
        //fireball//        
        if (Input.GetKey(KeyCode.M)) //charges mergeball for now
        {
            if (projectile != null) //is a mergeball on this character?
            {
                //while space is down, count time held and build up multiplier
                chargeTime = chargeTime + Time.deltaTime;
                projectileID = 1; //steam
                //chargeTime++;
            }
            else
            {
                Debug.Log("Passed ok. MERGE SHOOTING. RUN. o_o");
            }

        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("Power timer: " + chargeTime); //calculates fireball

            if (chargeTime <= 0.6f)
            {
                multiplier = 2f; //scald
                projectileID = 1; //steam
            }
            else if (chargeTime > 0.6f && chargeTime <= 1.0f)
            {
                multiplier = 2f; //perfect merge/vapour
                projectileID = 2; //steam
            }
            else if (chargeTime > 1.0f && chargeTime <= 1.5f)
            {
                multiplier = 3f; //steam
                projectileID = 2; //steam
            }
            else
            {
                multiplier = 2f; //might just be perfect merge but bigger
                projectileID = 3; //steam
            }

            //when let go, deduce multiplier
            MergePew(projectileID); //releases fireball
            chargeTime = 0;
            projectileID = 0;

        }
    }

    //pewpew
    private void MergePew(int projID)
    {
        //CHECK
        //how to pass through the fact that there's no item there?

        switch (projID)
        {
            case 1:
                Debug.Log("scald.");

                Debug.Log("Multiplier: " + multiplier);
                float scaldSpeed = launchSpeed * multiplier;
                Debug.Log(scaldSpeed); //confirm pew

                projectile.transform.localScale *= multiplier; //changes fern size (will update soon, just for reference.)

                MergedProjectile instance = projectile.GetComponent<MergedProjectile>(); //grabs info and sends to projectile?
                instance.scaldFullSpeed = scaldSpeed; //makes the projectile's full speed update with the newly calculated fern speed
                instance.scaldDamage = (multiplier - 1f); //higher hits will deal base spike PLUS the multiplier, essentially being an adder rather than a multiplier.
                instance.thisImage = scaldImage;
                

                Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation); //launch it lol

                projectile.transform.localScale /= multiplier; //resets it back to orignal size

                //rb.velocity = new Vector2(launchSpeed, 0); //temporary launch

                break;

            case 2:

                Debug.Log("vapour.");

                Debug.Log("Multiplier: " + multiplier);
                float vapourSpeed = launchSpeed * multiplier;
                Debug.Log(vapourSpeed); //confirm pew

                projectile.transform.localScale *= multiplier; //changes fern size (will update soon, just for reference.)

                MergedProjectile instance2 = projectile.GetComponent<MergedProjectile>(); //grabs info and sends to projectile?
                instance2.vapourFullSpeed = vapourSpeed; //makes the projectile's full speed update with the newly calculated fern speed
                instance2.vapourDamage = (multiplier - 1f); //higher hits will deal base spike PLUS the multiplier, essentially being an adder rather than a multiplier.
                instance2.thisImage = vapourImage; //updates the sprite image

                Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation); //launch it lol

                projectile.transform.localScale /= multiplier; //resets it back to orignal size

                break;
            
            case 3:

                Debug.Log("steam.");

                Debug.Log("Multiplier: " + multiplier);
                float steamSpeed = launchSpeed * multiplier;
                Debug.Log(steamSpeed); //confirm pew

                projectile.transform.localScale *= multiplier; //changes fern size (will update soon, just for reference.)

                MergedProjectile instance3 = projectile.GetComponent<MergedProjectile>(); //grabs info and sends to projectile?
                instance3.steamFullSpeed = steamSpeed; //makes the projectile's full speed update with the newly calculated fern speed
                instance3.steamDamage = (multiplier - 1f); //higher hits will deal base spike PLUS the multiplier, essentially being an adder rather than a multiplier.

                Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation); //launch it lol
                instance3.thisImage = steamImage;

                projectile.transform.localScale /= multiplier; //resets it back to orignal size

                break;

            default:
                break;
        }


    }
}
