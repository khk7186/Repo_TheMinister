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
        public Rarerity rarerity;

        public int waitTime = 0;
        public int alreadyWait = 0;
        public string spawnAfterAwayGuestName;
        public static SerializedCharacter SerializingCharacter(Character character)
        {
            var output = new SerializedCharacter();
            output.CharacterArtCode = character.characterArtCode.ToString();
            output.CharacterName = character.CharacterName;
            output.rarerity = character.rarerity;
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
            if (character.InGameAI != null)
            {
                output.HaveAI = true;
                output.SerializedInGameAI = SerializedInGameAI.SerializingCharacterInGameAI(character);
            }
            //AwayTime
            if (character.characterAwaitTribute != null)
            {
                output.waitTime = character.waitTime;
                output.alreadyWait = character.alreadyWait;
                if (character.spawnAfterAway != null)
                {
                    output.spawnAfterAwayGuestName = character.spawnAfterAway.guestName;
                }
            }

            return output;
        }
        public static Character DeserializingCharacter(SerializedCharacter characterData)
        {
            Character output = GameObject.Instantiate(Resources.Load<Character>("CharacterPrefab/DeserializeCharacter"));
            output.hireStage = (global::HireStage)Enum.Parse(typeof(global::HireStage), characterData.HireStage);
            output.CharacterName = characterData.CharacterName;
            output.characterArtCode = (CharacterArtCode)Enum.Parse(typeof(CharacterArtCode), characterData.CharacterArtCode);
            DeserializingTags(characterData, output);
            DeserializingStats(characterData, output);
            if (output.hireStage == global::HireStage.Hired || output.hireStage == global::HireStage.Away)
            {
                output.transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
                if (output.hireStage == global::HireStage.Away)
                {
                    var spawnAfterAwayDB = Resources.Load<SOSpawnAfterAwayDB>("Data/SpawnAfterAwayDB");
                    output.Away(output.waitTime - output.alreadyWait, spawnAfterAwayDB.Find(characterData.spawnAfterAwayGuestName));
                }
            }
            output.OnDutyState[OndutyType.Combat] = characterData.OnCombatDuty;
            output.OnDutyState[OndutyType.Debate] = characterData.OnDebateDuty;
            if (characterData.HaveAI)
            {
                SerializedInGameAI.DeserializingCharacterInGameAI(characterData.SerializedInGameAI, output);
                InGameCharacterStorage.LoadCharacter(output);
            }
            output.UpdateVariables();
            output.rarerity = characterData.rarerity;
            return (output);
        }

        public static void DeserializingTags(SerializedCharacter serializedCharacter, Character character)
        {
            character.tagList = new List<Tag>();
            foreach (string tag in serializedCharacter.Tags)
            {
                character.tagList.Add((Tag)Enum.Parse(typeof(Tag), tag));
            }
            character.UpdateVariables();
        }
        public static void DeserializingStats(SerializedCharacter serializedCharacter, Character character)
        {
            character.health = int.Parse(serializedCharacter.health);
            character.loyalty = int.Parse(serializedCharacter.loyalty);
        }
    }
}