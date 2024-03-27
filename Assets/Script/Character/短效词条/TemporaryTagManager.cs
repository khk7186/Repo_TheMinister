using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    private void OnEnable()
    {
        Dice.Instance.RegisterObserver(Instance);
        characterInv = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (characterInv == null) return;
        Debug.Log($"about to checking {characterInv.GetComponentsInChildren<Character>().Length} characters");
        foreach (var character in characterInv.GetComponentsInChildren<Character>())
        {
            var list = character.temporaryTags;
            if (list == null || list.Count < 1) { Debug.Log("list == null"); continue; }
            else
            {
                Debug.Log($"Changing for {character.CharacterName}");
                var removeList = new List<TemporaryTag>();
                foreach (var tempTag in list)
                {
                    tempTag.timeLeft -= 1;
                    if (tempTag.timeLeft < 1)
                    {
                        removeList.Add(tempTag);
                    }
                }
                character.UpdateVariables();
                foreach (var tempTag in removeList)
                {
                    list.Remove(tempTag);
                }
            }
        }
    }
}
