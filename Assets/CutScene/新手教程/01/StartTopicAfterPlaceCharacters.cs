using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTopicAfterPlaceCharacters : MonoBehaviour
{
    public GameObject conversation;
    public SpawnUI spawnUItarget;
    public int count = 1;
    public GameObject toBeSetOff = null;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => SelectOnDuty.GetOndutyAll(OndutyType.Combat).Count == count);
        yield return new WaitUntil(() => spawnUItarget.CurrentTarget == null);
        toBeSetOff.SetActive(false);
        conversation.SetActive(true);
    }
}
