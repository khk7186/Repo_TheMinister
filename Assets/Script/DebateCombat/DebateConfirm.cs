using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateConfirm : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void StartDebate()
    {
        FindObjectOfType<DebateMainEventManager>().StartDebate();
    }

}
