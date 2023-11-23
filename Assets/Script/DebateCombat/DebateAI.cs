using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class DebateAI : MonoBehaviour
{
    public static List<DebateCharacterCard> MakeDecision(DebateUnit unit, DebateTopic topic)
    {
        if (unit.debatePlan == null)
        {
            return DefaultSelect(unit, topic);
        }
        else
        {
            List<DebateCharacterCard> output = new List<DebateCharacterCard>();
            var selects = unit.debatePlan.NextPlan();
            Debug.Log(string.Join(",", selects));
            foreach (var targetName in selects)
            {
                var aim = unit.characterCards.FirstOrDefault(x => x.character.CharacterName == targetName);
                if (aim != null) { output.Add(aim); }
            }
            return output;
        }

    }
    public static List<DebateCharacterCard> DefaultSelect(DebateUnit unit, DebateTopic topic)
    {
        List<DebateCharacterCard> output = new List<DebateCharacterCard>();
        List<DebateCharacterCard> characterCards = unit.characterCards;
        int currentMax = 0;
        DebateCharacterCard currentCard = null;
        foreach (DebateCharacterCard characterCard in characterCards)
        {
            if (characterCard.character.loyalty > characterCard.UseCount)
            {
                var testValue = ScoreReviewEvent.TestReview(new List<Character[]>() { new Character[] { characterCard.character } }, topic);
                if (testValue > currentMax)
                {
                    currentMax = testValue;
                    currentCard = characterCard;
                }
            }
        }
        output.Add(currentCard);
        return output;
    }
}
