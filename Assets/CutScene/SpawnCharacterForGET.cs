using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnCharacterForGET : MonoBehaviour
{
    [System.Serializable]
    public struct CharacterTemp
    {
        public string CharacterName;
        public CharacterArtCode ArtCode;
        public List<string> TagNames;
    }
    public List<CharacterTemp> CharacterTemps;
    public Transform Host;
    public GeneralEventTrigger generalEventTrigger;
    public bool SetOnEnable = false;
    public bool Debate = false;

    public void OnEnable()
    {
        if (SetOnEnable && CharacterTemps.Count > 0)
        {
            Set();
            Debug.Log("set");
        }
    }
    public void Set()
    {
        for (int i = 0; i < CharacterTemps.Count; i++)
        {
            var item = CharacterTemps[i];
            List<Character> characters = new List<Character>();
            List<Tag> tags = new List<Tag>();
            foreach (var tagName in item.TagNames)
            {
                tags.Add((Tag)Enum.Parse(typeof(Tag), tagName));
            }
            var character = new GameObject(item.CharacterName).AddComponent(typeof(Character)) as Character;
            character.CharacterName = item.CharacterName;
            character.characterArtCode = item.ArtCode;
            character.tagList = tags;
            characters.Add(character);
            if (Host != null)
            {
                character.transform.parent = Host;
            }
            else
            {
                character.transform.parent = generalEventTrigger.transform;
            }
            if (Debate)
            {
                generalEventTrigger.enemyCharactersCardsList.Add(characters.ToArray());
            }
        }
    }

}
