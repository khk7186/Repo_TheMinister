using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    [System.Serializable]
    public class SerializedCharacter
    {
        public string CharacterArtCode;
        public string CharacterName;
        public List<string> Tags = new List<string>();
        public string health;
        public string loyalty;
        public string HireStage;
        public string characterType;
        public bool HaveAI = false;
        public bool OnCombatDuty = false;
        public bool OnDebateDuty = false;
        public bool OnGobangDuty = false;
        public SerializedInGameAI SerializedInGameAI = null;

        public static SerializedCharacter SerializingCharacter(Character character)
        {
            var output = new SerializedCharacter();
            output.CharacterArtCode = character.characterArtCode.ToString();
            output.CharacterName = character.name;
            //Tags
            output.Tags = new List<string>();
            foreach (var tag in character.tagList)
            {
                output.Tags.Add(tag.ToString());
            }
            //CharacterType
            output.HireStage = character.hireStage.ToString();
            output.characterType = character.characterType.ToString();
            output.loyalty = character.loyalty.ToString();
            output.health = character.health.ToString();
            //duty
            output.OnCombatDuty = character.OnDutyState[OndutyType.Combat];
            output.OnDebateDuty = character.OnDutyState[OndutyType.Debate];

            //InGameAISerialization
            if (character.InGameAI == null)
            {
                output.HaveAI = false;
                output.SerializedInGameAI = SerializedInGameAI.SerializingCharacterInGameAI(character);
                return output;
            }
            else
            {
                output.HaveAI = true;
            }
            return output;
        }

        public static Character DeserializingCharacter(SerializedCharacter character)
        {
            Character output = GameObject.Instantiate(Resources.Load<Character>("CharacterPrefab/DeserializeCharacter"));
            output.hireStage = (global::HireStage)Enum.Parse(typeof(global::HireStage), character.HireStage);
            output.tagList = new List<Tag>();
            output.CharacterName = character.CharacterName;
            output.characterArtCode = (CharacterArtCode)Enum.Parse(typeof(CharacterArtCode), character.CharacterArtCode);
            foreach (string tag in character.Tags)
            {
                output.tagList.Add((Tag)Enum.Parse(typeof(Tag), tag));
            }
            output.UpdateVariables();
            output.health = int.Parse(character.health);
            output.loyalty = int.Parse(character.loyalty);
            if (output.hireStage == global::HireStage.Hired)
            {
                output.transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
            }
            output.OnDutyState[OndutyType.Combat] = character.OnCombatDuty;
            output.OnDutyState[OndutyType.Debate] = character.OnDebateDuty;
            if (character.HaveAI)
            {
                SerializedInGameAI.DeserializingCharacterInGameAI(character.SerializedInGameAI, output);
                InGameCharacterStorage.LoadCharacter(output);
            }
            return (output);
        }
    }
}