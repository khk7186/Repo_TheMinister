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
        foreach (Transform character in characterInv)
        {
            character.gameObject.GetComponent<Character>().HungryEvent();
            character.gameObject.GetComponent<Character>().FollowerLoyaltyEvent();
        }
    }
}
