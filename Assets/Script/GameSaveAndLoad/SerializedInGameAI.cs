using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    [System.Serializable]
    public class SerializedInGameAI
    {
        public string pathPointName;

        public bool isFront;
        public bool isRight;
        public static SerializedInGameAI SerializingCharacterInGameAI(Character character)
        {
            var output = new SerializedInGameAI();
            output.pathPointName = character.InGameAI.currentPathPoint.name;
            output.isFront = character.InGameAI.GetComponent<SideChanger>().isFront;
            output.isRight = character.InGameAI.GetComponent<SideChanger>().isRight;
            return output;
        }

        public static DefaultInGameAI DeserializingCharacterInGameAI(SerializedInGameAI serializedInGameAI, Character character)
        {
            var inGameAI = character.SpawnInGameAI();
            inGameAI.Deserializing = true;
            var pm = UnityEngine.GameObject.FindObjectOfType<PathManager>().transform;
            inGameAI.currentPathPoint = pm.Find(serializedInGameAI.pathPointName).GetComponent<PathPoint>();
            inGameAI.SetLocation();
            inGameAI.GetComponent<SideChanger>().changeSide(serializedInGameAI.isFront, serializedInGameAI.isRight);
            return inGameAI;
        }
    }
}