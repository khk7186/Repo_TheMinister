using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOQuest")]
public class SOQuest : ScriptableObject
{
    [System.Serializable]
    public struct QuestStat
    {
        public string QuestID;
        public bool Unlocked;
        public bool Completed;
    }
    [System.Serializable]
    public struct QuestSave
    {
        public List<QuestStat> Save;
    }
    [SerializeField]
    public List<QuestSave> QuestList;
}
