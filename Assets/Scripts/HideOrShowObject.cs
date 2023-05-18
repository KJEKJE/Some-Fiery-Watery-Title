using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOrShowObject : MonoBehaviour
{
    public GameObject thisCharacter;
    public bool isDisabled = false;

    public void HideCharacter()
    {
        isDisabled = true;
        thisCharacter.SetActive(false);
    }
    public void ShowCharacter()
    {
        isDisabled = false;
        thisCharacter.SetActive(true);
    }
}
