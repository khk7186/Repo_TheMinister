using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayerAnimator : MonoBehaviour
{
    public List<GameObject> _objectsToActive;
    public bool _enablePlayer = true;
    private void Start()
    {
        FindObjectOfType<Player>().GetComponent<Animator>().enabled = _enablePlayer;
        if (_enablePlayer == false) return;
        foreach (var obj in _objectsToActive)
        {
            obj.SetActive(true);
        }
    }
}
