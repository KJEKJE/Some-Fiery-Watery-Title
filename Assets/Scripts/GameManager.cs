using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //public Score gameScore; //get the score info
    public Text scoreText; //adding score text here instead. easier
    public float currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = "Score: " + (currentScore.ToString());
        Debug.Log("Level Start!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void DeathChecker()
    {
        RestartLevel(); //confirms a death/game over
    }

    private void RestartLevel()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene("DemoLevel");
    }

    public void ScoreUpdate(int addScore)
    {
        currentScore += addScore; //adds to current score depending on the circumstance.
        scoreText.text = "Score: " + (currentScore.ToString());
    }
}
