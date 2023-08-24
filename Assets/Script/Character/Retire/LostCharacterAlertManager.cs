using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostCharacterAlertManager : MonoBehaviour
{
    public CharacterRetireNotice retireNoticePrefab;
    public CharacterRetireNotice deathNoticePrefab;
    public static void CallRetireAlert(Character character)
    {
        var notice = Instantiate(FindObjectOfType<LostCharacterAlertManager>().retireNoticePrefab,MainCanvas.FindMainCanvas());
        notice.Setup(character);
        notice.Show();
    }
    public static void CallDeathAlert(Character character)
    {
        var notice = Instantiate(FindObjectOfType<LostCharacterAlertManager>().deathNoticePrefab, MainCanvas.FindMainCanvas());
        notice.Setup(character);
        notice.Show();
    }
}
