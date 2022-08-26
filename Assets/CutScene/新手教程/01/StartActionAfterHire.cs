using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActionAfterHire : MonoBehaviour
{
    public List<GameObject> _objectsToActive;
    private IEnumerator Start()
    {
        var inv = SelectOnDuty.FindInventory();
        yield return new WaitUntil(() => inv.childCount == 2);
        foreach (var obj in _objectsToActive)
        {
            obj.SetActive(true);
        }
        yield return null;
    }
}
