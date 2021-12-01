using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmUI: MonoBehaviour
{
    public Button confirm;
    public Button cancel;
    public Text text;

    public void SetUp(string confirmContext)
    {
        text.text = confirmContext;
    }

    public void Finish()
    {
        Destroy(gameObject);
    }
}

