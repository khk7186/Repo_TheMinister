using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public Tag tag = Tag.Null;
    public void AddAbilityToNextPlacement()
    {
        var game = FindObjectOfType<GoBangMainLoop>();
        if (GoBangMethod.TagToMethodEffect.ContainsKey(tag))
        {
            ArrayList AbilityInfo = GoBangMethod.TagToMethodEffect[tag];
            game.PlayerMethod = (GoBangMethod)AbilityInfo[0];
            game.playerEffect = (int)AbilityInfo[1];
        }
    }
    public void CancelAbilityToNextPlacement()
    {
        var game = FindObjectOfType<GoBangMainLoop>();
        game.PlayerMethod = null;
    }
}
