using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoliticAssassinEvent
{
    public int totalRate = 10;
    public int successRate = 1;
    public int duration = 6;
    public PoliticAssassinEvent(int totalRate, int successRate)
    {
        this.totalRate = totalRate;
        this.successRate = successRate;
        this.duration = PoliticSystemManager.Instance?.AssassinDuration ?? 6;
    }

    public static PoliticAssassinEvent StartAssassin(PoliticCharacter politicCharacter, Character assasin)
    {
        int totalRate = politicCharacter.difficulty;
        int successRate = assasin.CharactersValueDict[CharacterValueType.´Ì];
        var output = new PoliticAssassinEvent(totalRate, successRate);
        return output;
    }
}
