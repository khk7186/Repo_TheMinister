using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoliticFaction
{
    public string factionName = string.Empty;
    public int level = 0;
    public int love = 0;
    public List<string> messages = new List<string>();
}
