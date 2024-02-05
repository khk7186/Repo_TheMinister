using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoliticFaction
{
    public string factionName = string.Empty;
    public string factionJobTitle = string.Empty;
    public string factionStory = string.Empty;
    public FactionType factionType;
    public int level = 0;
    public int friendly = 0;
    public List<string> messages = new List<string>();
}
