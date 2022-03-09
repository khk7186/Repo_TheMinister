using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour, IPointerClickHandler
{
    public Tag tag = Tag.Null;
    public void AddAbilityToNextPlacement()
    {
        var game = FindObjectOfType<GoBangMainLoop>();
        if (GoBangMethod.TagToMethodEffect.ContainsKey(tag))
        {
            ArrayList AbilityInfo = GoBangMethod.TagToMethodEffect[tag];
            var thisMethod = (GoBangMethod)AbilityInfo[0];
            if (game.PlayerMethod != null && thisMethod == game.PlayerMethod)
            {
                CancelAbilityToNextPlacement();
            }
            else
            {
                game.PlayerMethod = thisMethod;
                game.playerEffect = (int)AbilityInfo[1];
            }
        }
    }

    public void CancelAbilityToNextPlacement()
    {
        var game = FindObjectOfType<GoBangMainLoop>();
        game.PlayerMethod = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AddAbilityToNextPlacement();
    }
}
