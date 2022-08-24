using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDiceAgain : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<Dice>().rolling = false;
    }
}
