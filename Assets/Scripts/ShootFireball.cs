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
    
    // Start is called before the first frame update
    void Start()
    {
        launchSpeed = 5f; //initial launch speed
        dir = projectileSpawn.rotation.z; //for later?
        Debug.Log("Direction of projectile is: " + dir);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pew();
        }
    }

    void Pew()
    {
        Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        rb.velocity = new Vector2(launchSpeed, 0); //temporary launch
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
