using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    public class QuestFinishPlayMark : MonoBehaviour
    {
        public bool MarkOnEnable = true;
        public QuestGiverAI questGiverAI = null;

        public void OnEnable()
        {
            if (MarkOnEnable)
            {
                Mark();
            }
        }

        public void Mark()
        {
            if (questGiverAI == null)
            {
                Debug.LogError("No Quest Giver AI Linked");
                return;
            }
            questGiverAI.triggered = true;
        }
    }
}