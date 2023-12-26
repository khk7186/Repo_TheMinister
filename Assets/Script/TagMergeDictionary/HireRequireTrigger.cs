using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireRequireTrigger : MonoBehaviour
{
    public Character character;
    private void Start()
    {
        character = GetComponent<DefaultInGameAI>().character;
    }
    public void OnMouseEnter()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("OverUI");
            return;
        }
        if (character == null) return;
        CharacterHireRequireDescriptionUI.Show(character);
    }
    public void OnMouseExit()
    {
        if (character == null) return;
        CharacterHireRequireDescriptionUI.Hide();
    }
}
