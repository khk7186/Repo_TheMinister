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
            output = "Character Spine/Prefabs/Characters/MainCharacter/Front/";
        }
        else
        {
            output = "Character Spine/Prefabs/Characters/MainCharacter/Back/";
        }
        return output;
    }
    public static string ReturnSpineAssetPath(CharacterArtCode characterArtCode, bool front)
    {
        string codeName = characterArtCode.ToString();
        string subforderName = front ? "Front" : "Back";
        var output = $"Character Spine/{codeName}/{subforderName}/{codeName}_{subforderName}_SkeletonData";
        Debug.Log(output);
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
}
