using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.QuestMachine;

[System.Serializable]
public class PoliticAssassinEvent
{
    public int totalRate = 10;
    public int asssinValue = 1;
    public int duration = 1;
    public bool result = false;
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
        int asssinValue = assasin.CharactersValueDict[CharacterValueType.��];
        var output = new PoliticAssassinEvent(totalRate, asssinValue, politicCharacter);
        politicCharacter.Assassin = assasin;
        assasin.OnAssassinEvent = true;
        assasin.AssasinTarget = politicCharacter.GetComponentInParent<PoliticSlot>().slotID;
        assasin.Away(output.duration);
        return output;
    }
    public static PoliticAssassinEvent StartAssassinInLoad(PoliticCharacter politicCharacter, Character assasin, int duration)
    {
        int totalRate = politicCharacter.AssassinDifficulty;
        int asssinValue = assasin.CharactersValueDict[CharacterValueType.��];
        var output = new PoliticAssassinEvent(totalRate, asssinValue, politicCharacter);
        output.duration = duration;
        politicCharacter.Assassin = assasin;
        assasin.OnAssassinEvent = true;
        assasin.AssasinTarget = politicCharacter.GetComponentInParent<PoliticSlot>().slotID;
        assasin.Away(output.duration);
        return output;
    }
    public void GetResult()
    {
        result = Random.Range(0, totalRate) < asssinValue;
    }
    public static void EndAssassin(PoliticAssassinEvent assassinEvent)
    {
        assassinEvent.GetResult();
        if (assassinEvent.result == true)
        {
            PixelCrushers.MessageSystem.SendMessage(null, "Assassin", assassinEvent.politicCharacter.CharacterName, 1);
            assassinEvent.politicCharacter.Assassin.Back();
            GateHolderAnimationPlayer.AddAnimation(true, assassinEvent.politicCharacter.slot);
            GameObject.FindObjectOfType<PoliticActionUI>().StartAssassinSuccessAnimation(assassinEvent.politicCharacter.slot.page.name);
            assassinEvent.politicCharacter.Assassin.OnAssassinEvent = false;
            assassinEvent.politicCharacter.Assassin.AssasinTarget = string.Empty;
        }
        else
        {
            PressureEventHandler.PressureAdd(assassinEvent.politicCharacter.pressurePunishment);
            assassinEvent.politicCharacter.Assassin.ApplyHealth(-20);
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = $"��ɱ{assassinEvent.politicCharacter.CharacterName}ʧ��";
        }
        assassinEvent.politicCharacter.Assassin.OnAssassinEvent = false;
    }
}
