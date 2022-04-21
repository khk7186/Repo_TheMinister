using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAssetPath : MonoBehaviour
{
    public static string ReturnMainCharacterAssetPath(bool front)
    {
        string output = "";
        if (front)
        {
            output = "Character Spine/李袁陌/Front/";
        }
        else
        {
            output = "Character Spine/李袁陌/Back/";
        }
        return output;
    }
    public static string ReturnSpineAssetPath(CharacterArtCode characterArtCode, bool front)
    {
        string codeName = characterArtCode.ToString();
        string subforderName = front ? "Front" : "Back";
        var output = $"Character Spine/{codeName}/{subforderName}/{codeName}_{subforderName}_SkeletonData";
        return output;
    }
    public static string ReturnSpineControllerPath(CharacterArtCode characterArtCode, bool front)
    {
        string codeName = characterArtCode.ToString();
        string subforderName = front ? "Front" : "Back";
        var output = $"Character Spine/{codeName}/{subforderName}/{codeName}{subforderName}_Controller";
        return output;
    }
    public static string ReturnCombatCharacterUnitPrefPath()
    {
        string output = "CombatScene/CombatCharacterUnit";
        return output;
    }
    
    public static string ReturnItemPath(ItemName name)
    {
        return $"Art/ItemIcon/{name.ToString()}";
    }

    public static string ReturnCharacterSpritePath(CharacterArtCode characterArtCode, bool Idle = true)
    {
        string codeName = characterArtCode.ToString();
        string subforderName = Idle ? "Idle" : "Headshot";
        var output = $"Art/CharacterSprites/{subforderName}/{codeName}";
        return output;
    }

    public static string ReturnCharacterStatBackground(Rarerity rarerity)
    {
        var output = $"Art/人物卡/六大项/字体背景/{rarerity}";
        return output;
    }
}
