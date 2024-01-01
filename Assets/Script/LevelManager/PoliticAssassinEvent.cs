using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        int totalRate = politicCharacter.AssassinDifficulty;
        int asssinValue = assasin.CharactersValueDict[CharacterValueType.¥Ã];
        var output = new PoliticAssassinEvent(totalRate, asssinValue, politicCharacter);
        politicCharacter.Assassin = assasin;
        assasin.Away(output.duration);
        return output;
    }
    public static void EndAssassin(PoliticAssassinEvent assassinEvent)
    {
        bool result = Random.Range(0, assassinEvent.totalRate) < assassinEvent.asssinValue;
        if (result == true)
        {
            GateHolderAnimationPlayer.AddAnimation(true, assassinEvent.politicCharacter.slot);
        }
        else
        {
            PressureEventHandler.PressureAdd(assassinEvent.politicCharacter.pressurePunishment);
            assassinEvent.politicCharacter.Assassin.ApplyHealth(-20);
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = $"¥Ã…±{assassinEvent.politicCharacter.CharacterName} ß∞‹";
        }
    }

}
