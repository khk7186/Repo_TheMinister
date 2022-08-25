using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTopicAfterPlaceCharacters : MonoBehaviour
{
    public GameObject conversation;
    public SpawnUI spawnUItarget;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => SelectOnDuty.GetOndutyAll(OndutyType.Combat).Count != 0);
        yield return new WaitUntil(() => spawnUItarget.CurrentTarget == null);
        conversation.SetActive(true);
    }
}
