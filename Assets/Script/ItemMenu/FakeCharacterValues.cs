using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCharacterValues : MonoBehaviour
{
    private static Dictionary<CharacterValueType, int> fakeCharacterValues;
    public static void SetFakeCharacterValues()
    {
        CharacterInfoUI characterInfoUI = FindObjectOfType<CharacterInfoUI>();
        fakeCharacterValues = new Dictionary<CharacterValueType, int>()
    {  {CharacterValueType.Îä,0 },
       {CharacterValueType.ÊØ,0 },
       {CharacterValueType.´Ì,0 },
       {CharacterValueType.ÖÇ,0 },
       {CharacterValueType.²Å,0 },
       {CharacterValueType.Ä±,0 } };
        OnSwitchAssets OSA = FindObjectOfType<OnSwitchAssets>();
        Character character = OSA.character;
        List<Tag> tagList = new List<Tag>();
        Debug.Log(OSA.selectedTag);
        tagList.AddRange(character.tagList);
        var debugList = "";
        foreach (Tag tag in tagList)
        {
            debugList += tag.ToString() + ",";
        }
        Debug.Log(debugList);
        tagList.Remove(OSA.selectedTag);
        debugList = "";
        foreach (Tag tag in tagList)
        {
            debugList += tag.ToString() + ",";
        }
        Debug.Log(debugList);
        tagList.Add(OSA.replacementTag);
        debugList = "";
        foreach (Tag tag in tagList)
        {
            debugList += tag.ToString() + ",";
        }
        Debug.Log(debugList);
        foreach (Tag tag in tagList)
        {
            List<int> varlist = Player.TagInfDict[tag];
            fakeCharacterValues[CharacterValueType.ÖÇ] += varlist[0];
            fakeCharacterValues[CharacterValueType.²Å] += varlist[1];
            fakeCharacterValues[CharacterValueType.Ä±] += varlist[2];
            fakeCharacterValues[CharacterValueType.Îä] += varlist[3];
            fakeCharacterValues[CharacterValueType.´Ì] += varlist[4];
            fakeCharacterValues[CharacterValueType.ÊØ] += varlist[5];
        }
        characterInfoUI.SetValues(fakeCharacterValues);
        characterInfoUI.SetValueColors(
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.ÖÇ])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.²Å])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.Ä±])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.Îä])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.´Ì])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.ÊØ])]
            );
    }


}
