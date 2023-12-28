using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryTagManager : MonoBehaviour, IDiceRollEvent
{
    public static TemporaryTagManager Instance;
    public Transform characterInv;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Dice.Instance.RegisterObserver(Instance);
        characterInv = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (characterInv == null) return;
        foreach (Transform character in characterInv)
        {
            var list = character.GetComponent<Character>().temporaryTags;
            if (list != null || list.Count < 1) { return; }
            else
            {
                foreach (var tempTag in list)
                {
                    tempTag.timeLeft -= 1;
                    if (tempTag.timeLeft < 1)
                    {
                        list.Remove(tempTag);
                    }
                }
            }
        }
    }
}
