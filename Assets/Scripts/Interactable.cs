using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public GameManager gameM;
    //public int ScoreValue = 0;

    public bool isHeld = false;
    public Transform shardHolder;
    //public float raycastDist; //not necessary yet. Would be if I was detecting a specific reach.
    
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D shardCheck = Physics2D.Raycast(grab)
        //if (shardHolder != null)
        //{

        //}
        if (isHeld)
        {
            gameObject.transform.parent = shardHolder;
            gameObject.transform.position = shardHolder.position;
            //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            gameObject.transform.parent = null; //detaches from parent
            //gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    public void SetZapShardHolder()
    {

    }
}
