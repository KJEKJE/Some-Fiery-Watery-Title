using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    
    
    // Start is called before the first frame update
    public void DoorOpened()
    {
        Debug.Log("Door has been opened.");
        isOpen = true;

        Despawn();
    }

    void Despawn()
    {
        //animation for later?
        Destroy(gameObject);
    }
}
