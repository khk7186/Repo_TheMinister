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
        public List<Tag> Tags;
    }

    public List<CharacterTemp> CharacterTemps;
    public Transform Host;
    public GeneralEventTrigger generalEventTrigger;
    public bool SetOnEnable = false;
    public bool Debate = false;
    public int Digit = 0;

    public void OnEnable()
    {
        if (SetOnEnable && CharacterTemps.Count>0)
        {
            Set();
        }
    }
    public void Set()
    {
        foreach (var item in CharacterTemps)
        {
            List<Character> characters = new List<Character>();
            var character = new Character
            {
                CharacterName = item.CharacterName,
                characterArtCode = item.ArtCode,
                tagList = item.Tags
            };
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
