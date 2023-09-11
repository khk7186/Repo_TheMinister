using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    [System.Serializable]
    public class SerializedRoitData
    {
        public List<SerializedOnRoitSpawnRanges> OnRoitSpawnRanges = new List<SerializedOnRoitSpawnRanges>();

        public static SerializedRoitData Serializing(RoitManager roitManager)
        {
            var output = new SerializedRoitData();
            foreach (RoitSpawnRange rsr in roitManager.spawnRanges)
            {
                if (rsr.onRoit)
                {
                    output.OnRoitSpawnRanges.Add(SerializedOnRoitSpawnRanges.Serializing(rsr));
                }
            }
            return output;
        }



    }
}