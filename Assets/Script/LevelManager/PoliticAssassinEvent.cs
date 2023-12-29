using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoliticAssassinEvent
{
    public int totalRate = 10;
    public int asssinValue = 1;
    public int duration = 6;
    public PoliticCharacter politicCharacter = null;
    public PoliticAssassinEvent(int totalRate, int successRate, PoliticCharacter politicCharacter)
    {
        this.totalRate = totalRate;
        this.asssinValue = successRate;
        this.duration = PoliticSystemManager.Instance?.AssassinDuration ?? 6;
        this.politicCharacter = politicCharacter;
    }

    public static PoliticAssassinEvent StartAssassin(PoliticCharacter politicCharacter, Character assasin)
    {
        int totalRate = politicCharacter.difficulty;
        int asssinValue = assasin.CharactersValueDict[CharacterValueType.´Ì];
        var output = new PoliticAssassinEvent(totalRate, asssinValue, politicCharacter);
        assasin.Away(output.duration);
        return output;
    }
    public static void EndAssassin(PoliticAssassinEvent assassinEvent)
    {
        bool result = Random.Range(0, assassinEvent.totalRate) < assassinEvent.asssinValue;
        if (result == true)
        {
            
        }
    }
}
