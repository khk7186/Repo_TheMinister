using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RightClickToHide : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            AudioManager.Play("·­Ò³");
            if (TryGetComponent(out UnityUIQuestJournalUI questUI))
            {
                questUI.Hide();
            }
            else
            {
                FindObjectOfType<UnityUIQuestHUD>(true).Show();
                gameObject.SetActive(false);
            }
        }
    }
}
