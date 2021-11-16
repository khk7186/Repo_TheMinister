using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ConfirmPhase
{
    False,
    True,
    Null
}

public class Confirm: MonoBehaviour
{
    public Button confirm;
    public Button cancel;
    public Text text;

    public void SetUp(string confirmContext)
    {
        text.text = confirmContext;
    }

}

