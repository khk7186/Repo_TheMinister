using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAfterFirstTagReplace : MonoBehaviour
{
    public List<GameObject> _objectsToActive;
    public SpawnUI spawnUItarget;
    private IEnumerator Start()
    {
        Character character = SelectOnDuty.FindInventory().GetComponentInChildren<Character>();
        yield return new WaitUntil(() => character.tagList.Contains(Tag.无用之人));
        yield return new WaitUntil(() =>  spawnUItarget.CurrentTarget == null);
        foreach (var obj in _objectsToActive)
        {
            obj.SetActive(true);
        }
        yield return null;
    }
}
