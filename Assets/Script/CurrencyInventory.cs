using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyInventory : MonoBehaviour
{
    public int Money = 250;
    public float GovernorSupport = 0.2f;
    public float CivilSupport = 0.2f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
