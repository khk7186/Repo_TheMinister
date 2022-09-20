using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnEnabled : MonoBehaviour
{
    public List<GameObject> disables;
    private void OnEnable()
    {
        foreach (GameObject go in disables)
        {
            go.SetActive(false);
        }
    }
}
