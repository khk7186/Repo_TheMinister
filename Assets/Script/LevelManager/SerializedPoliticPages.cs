using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[Serializable]
public class SerializedPoliticPages
{
    public string pageName = string.Empty;
    public List<string> slotNames = new List<string>();
    public List<SerializedCharacter> serializedCharacters = new List<SerializedCharacter>();
    public List<int> assassinDifficulty = new List<int>();
    public List<int> BribeDifficulty = new List<int>();
    public List<int> AlreadyBribeAmount = new List<int>();
    public List<int> ImpeachTimes = new List<int>();

    public static SerializedPoliticPages Serialize(List<PoliticSlot> politicSlots, string pageName)
    {
        var output = new SerializedPoliticPages();
        output.pageName = pageName;
        for (int index = 0; index < politicSlots.Count; index++)
        {
            //new index for all list
            output.slotNames.Add(politicSlots[index].slotName);
            output.serializedCharacters.Add(null);
            output.assassinDifficulty.Add(0);
            output.BribeDifficulty.Add(0);
            output.AlreadyBribeAmount.Add(0);
            output.ImpeachTimes.Add(0);
            //end

            //Assign vars to index
            var targetGateHolder = politicSlots[index].GateHolder;
            if (targetGateHolder != null)
            {
                output.assassinDifficulty[index] = targetGateHolder.AssassinDifficulty;
                output.AlreadyBribeAmount[index] = targetGateHolder.BribeAlreadySpent;
                output.BribeDifficulty[index] = targetGateHolder.BribePrice;
                output.ImpeachTimes[index] = targetGateHolder.ImpeachTime;
            }
            var targetCharacterOnHold = politicSlots[index].characterOnHold;
            if (targetCharacterOnHold != null)
            {
                output.serializedCharacters[index] = SerializedCharacter.SerializingCharacter(targetGateHolder);
            }
            //end
        }
        return null;
    }
}
