using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    [Serializable]
    public class SerializedMapData
    {
        public int DayTime = 0;
        public int Day = 0;

        public static SerializedMapData SerializingMapData(Map map)
        {
            var output = new SerializedMapData();
            output.DayTime = map.DayTime;
            output.Day = map.Day; 
            return output;
        }
    }
}