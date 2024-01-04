using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralTrackingInfo : MonoBehaviour
{
    public Text characterNameText = null;
    public Text messageText = null;
    public Text timeLeftText = null;
    public void Setup(string characterName, string message, int timeLeft)
    {
        characterNameText.text = characterName;
        messageText.text = message;
        timeLeftText.text = $"行动仍需{timeLeft}回合";
    }
}
