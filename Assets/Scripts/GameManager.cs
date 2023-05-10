using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Level Start!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("Reloading Scene...");
            SceneManager.LoadScene("DemoLevel");
        }
    }
}
