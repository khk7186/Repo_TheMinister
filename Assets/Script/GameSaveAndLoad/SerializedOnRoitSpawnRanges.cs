using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    [System.Serializable]
    public class SerializedOnRoitSpawnRanges
    {
        public string spawnRangesName;
        public int roitCharacterCount;
        public List<SerializedCharacter> serializedCharacters = new List<SerializedCharacter>();
        public List<string> roitCharacterStartPoints = new List<string>();
        public List<string> roitCharacterEndPoints = new List<string>();

        public static SerializedOnRoitSpawnRanges Serializing(RoitSpawnRange spawnRange)
        {
            var output = new SerializedOnRoitSpawnRanges();
            output.spawnRangesName = spawnRange.name;
            output.roitCharacterCount = spawnRange.CurrentRoit;
            foreach (RoitCharacter rc in spawnRange.roitCharacters)
            {
                var rcAI = rc.InGameAI as RoitInGameAI;
                output.serializedCharacters.Add(SerializedCharacter.SerializingCharacter(rc));
                output.roitCharacterStartPoints.Add(rcAI.startPoint.name);
                output.roitCharacterEndPoints.Add(rcAI.endPoint.name);
            }
            return output;
        }

        public void LoadRange(RoitSpawnRange spawnRange, SaveAndLoadManager manager)
        {
            spawnRange.takenStartPoint = new List<PathPoint>();
            for (int i = 0; i < roitCharacterCount; i++)
            {
                var characterData = serializedCharacters[i];
                var target = spawnRange.SpawnRoit();
                target.CharacterName = characterData.CharacterName;
                SerializedCharacter.DeserializingTags(characterData, target);
                SerializedCharacter.DeserializingStats(characterData, target);
                var rcAI = (RoitInGameAI)target.InGameAI;
                var startPoint = spawnRange.transform.Find(roitCharacterStartPoints[i]);
                rcAI.startPoint = startPoint.GetComponent<PathPoint>();
                spawnRange.takenStartPoint.Add(startPoint.GetComponent<PathPoint>());
                var endPoint = spawnRange.transform.Find(roitCharacterEndPoints[i]);
                rcAI.startPoint = endPoint.GetComponent<PathPoint>();
                rcAI.StartCoroutine(rcAI.OnStreetRator());
            }
        }
    }
}