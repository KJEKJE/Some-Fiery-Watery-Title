using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public HealthScript player; //F
    //public Transform player2; //W
    public Text HPText;
    //public Text score2Text;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.playerHealth);
        HPText.text = "HP: " + player.playerHealth.ToString("0");
        //Debug.Log(player2.position.z);
    }
}
