using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateConfirm : MonoBehaviour
{
    public void StartDebate()
    {
        FindObjectOfType<DebateMainEventManager>().StartDebate();
    }
    
}
