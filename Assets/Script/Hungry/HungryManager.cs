using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryManager : MonoBehaviour, IDiceRollEvent
{
    public static HungryManager Instance;
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
        foreach (Transform characterTransform in characterInv)
        {
            var character = characterTransform.gameObject.GetComponent<Character>();
            if (character.hireStage == HireStage.Away) continue;
            character.HungryEvent();
            character.FollowerLoyaltyEvent();
        }
    }
}
