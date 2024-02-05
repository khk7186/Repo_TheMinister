using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FactionType
{
    无党派,
    李党,
    九千岁,
    士族门阀,
    于党,
    刘党
}
public class PoliticFactionUIMaster : MonoBehaviour
{
    public static PoliticFactionUIMaster Instance;
    public SOPoliticFaction model = null;
    public PoliticFactionInfoUI infoUI = null;
    public PoliticFactionMenuUI menuUI = null;
    public List<PoliticFaction> factions => model.politicFactions;
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    public void Reset()
    {
        factions.Clear();
    }
    public void Setup()
    {
       menuUI.Setup(factions);
    }
    public void OpenInfo()
    {

    }
}
