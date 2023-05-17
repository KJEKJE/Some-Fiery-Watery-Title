using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] private GameManager gameScoreValue;

    // Start is called before the first frame update
    public void DoorOpened()
    {
        Debug.Log("Door has been opened.");
        isOpen = true;
        
        gameScoreValue.ScoreUpdate(5); //just adds 5 to score. nothing else!

        Despawn();
    }

    void Despawn()
    {
        //animation for later?
        Destroy(gameObject);
    }
}
