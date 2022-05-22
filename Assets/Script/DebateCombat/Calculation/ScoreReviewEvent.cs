using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReviewEvent : MonoBehaviour
{
    public DebateTopic topic;
    public List<Character[]> characters;
    public int[] finalScore = new int[2] { 0, 0 };
    public ScoreReviewUI scoreReviewUI;
    public int playerIndex;
    public DebatePointCollector[] debatePointCollectors = new DebatePointCollector[] { };

    public static void NewReview(ScoreReviewUI scoreReviewUI, List<Character[]> characters, DebateTopic topic, int playerIndex)
    {
        ScoreReviewEvent review = new GameObject("ScoreReviewEvent").AddComponent<ScoreReviewEvent>();
        review.scoreReviewUI = scoreReviewUI;
        review.characters = characters;
        review.topic = topic;
        review.playerIndex = playerIndex;
        review.StartReview();
        review.StartCoroutine(review.StartUpdateUI());
    }
    private IEnumerator StartUpdateUI()
    {
        foreach (DebatePointCollector debatePointCollector in debatePointCollectors)
        {
            yield return StartCoroutine(scoreReviewUI.NextPointCollecter(debatePointCollector));
            yield return new WaitForSeconds(0.1f);
        }
        yield return scoreReviewUI.FinishAnimation();
        yield return WaitForMouseDown();
        Destroy(gameObject);
    }
    private IEnumerator WaitForMouseDown()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                yield break;
            }
            yield return null;
        }
    }
    private void StartReview()
    {
        var otherPlayerCharacters = characters.FindAll(x => x != characters[playerIndex]);
        var playerCharacres = characters[playerIndex];
        TryGetPoints(DebatePointCollector.大家闺秀, TopicPointsCalculator.CalculatPoints(DebatePointCollector.大家闺秀, topic, playerCharacres, null));
        if (!debatePointCollectors.Contains(DebatePointCollector.大家闺秀))
            TryGetPoints(DebatePointCollector.闺秀, TopicPointsCalculator.CalculatPoints(DebatePointCollector.闺秀, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.大才子, TopicPointsCalculator.CalculatPoints(DebatePointCollector.大才子, topic, playerCharacres, null));
        if (!debatePointCollectors.Contains(DebatePointCollector.大才子))
            TryGetPoints(DebatePointCollector.才子, TopicPointsCalculator.CalculatPoints(DebatePointCollector.才子, topic, playerCharacres, null));
        foreach (Tag tag in topic.tagRequest)
        {
            TryGetPoints(DebatePointCollector.有理有据, TopicPointsCalculator.CalculatPoints(DebatePointCollector.有理有据, topic, playerCharacres, tag));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.有理有据))
            TryGetPoints(DebatePointCollector.感同身受, TopicPointsCalculator.CalculatPoints(DebatePointCollector.感同身受, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.地位超然, TopicPointsCalculator.CalculatPoints(DebatePointCollector.地位超然, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.言语粗鄙, TopicPointsCalculator.CalculatPoints(DebatePointCollector.地位超然, topic, playerCharacres, null));
        foreach (CharacterValueType valueType in topic.characterValue)
        {
            TryGetPoints(DebatePointCollector.权威, TopicPointsCalculator.CalculatPoints(DebatePointCollector.权威, topic, playerCharacres, new ArrayList() { valueType, otherPlayerCharacters }));
            TryGetPoints(DebatePointCollector.词不对板, TopicPointsCalculator.CalculatPoints(DebatePointCollector.词不对板, topic, playerCharacres, otherPlayerCharacters));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.权威))
        {
            TryGetPoints(DebatePointCollector.力压众异, TopicPointsCalculator.CalculatPoints(DebatePointCollector.力压众异, topic, playerCharacres, otherPlayerCharacters));
            TryGetPoints(DebatePointCollector.国士无双, TopicPointsCalculator.CalculatPoints(DebatePointCollector.国士无双, topic, playerCharacres, null));
        }
        TryGetPoints(DebatePointCollector.乱纪, TopicPointsCalculator.CalculatPoints(DebatePointCollector.乱纪, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.一枝独秀, TopicPointsCalculator.CalculatPoints(DebatePointCollector.一枝独秀, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.在其位, TopicPointsCalculator.CalculatPoints(DebatePointCollector.在其位, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.披靡, TopicPointsCalculator.CalculatPoints(DebatePointCollector.披靡, topic, playerCharacres, CharacterValueType.智));
        TryGetPoints(DebatePointCollector.披靡, TopicPointsCalculator.CalculatPoints(DebatePointCollector.披靡, topic, playerCharacres, CharacterValueType.才));
        TryGetPoints(DebatePointCollector.披靡, TopicPointsCalculator.CalculatPoints(DebatePointCollector.披靡, topic, playerCharacres, CharacterValueType.谋));
        foreach (Character[] otherCharacters in otherPlayerCharacters)
        {
            TryGetPoints(DebatePointCollector.破绽, TopicPointsCalculator.CalculatPoints(DebatePointCollector.破绽, topic, playerCharacres, otherCharacters));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.破绽))
            TryGetPoints(DebatePointCollector.破绽百出, TopicPointsCalculator.CalculatPoints(DebatePointCollector.破绽百出, topic, playerCharacres, otherPlayerCharacters));
        else
        {
            if (topic.characterValue.Contains(CharacterValueType.谋))
                TryGetPoints(DebatePointCollector.早有谋划, TopicPointsCalculator.CalculatPoints(DebatePointCollector.早有谋划, topic, playerCharacres, otherPlayerCharacters));
            else
                TryGetPoints(DebatePointCollector.内幕, TopicPointsCalculator.CalculatPoints(DebatePointCollector.内幕, topic, playerCharacres, otherPlayerCharacters));
        }
        TryGetPoints(DebatePointCollector.乱心, TopicPointsCalculator.CalculatPoints(DebatePointCollector.乱心, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.绣花枕头, TopicPointsCalculator.CalculatPoints(DebatePointCollector.绣花枕头, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.子不语, TopicPointsCalculator.CalculatPoints(DebatePointCollector.子不语, topic, playerCharacres, null));
        if (!debatePointCollectors.Contains(DebatePointCollector.一枝独秀))
            TryGetPoints(DebatePointCollector.以众敌寡, TopicPointsCalculator.CalculatPoints(DebatePointCollector.以众敌寡, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.尽诚竭节, TopicPointsCalculator.CalculatPoints(DebatePointCollector.尽诚竭节, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.不臣之心, TopicPointsCalculator.CalculatPoints(DebatePointCollector.不臣之心, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.强自镇定, TopicPointsCalculator.CalculatPoints(DebatePointCollector.强自镇定, topic, playerCharacres, otherPlayerCharacters));
    }

    private void TryGetPoints(DebatePointCollector collector, int[] points)
    {
        if (points == null)
            return;
        if (points[0] == 0 && points[1] == 0)
            return;
        finalScore[0] += points[0];
        finalScore[1] += points[1];
        debatePointCollectors.Append(collector);
    }
}
