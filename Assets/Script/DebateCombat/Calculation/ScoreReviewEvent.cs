using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScoreReviewEvent : MonoBehaviour
{
    public DebateTopic topic;
    public List<Character[]> characters;
    public int[] finalScore = new int[2] { 0, 0 };
    public ScoreReviewUI scoreReviewUI;
    public int playerIndex = 0;
    public List<DebatePointCollector> debatePointCollectors = new List<DebatePointCollector>();
    List<CharacterArtCode> idleImage;
    public float ReviewShiftDuration = 0.5f;
    public List<DebateUnit> loseOrder = new List<DebateUnit>();
    public static void NewReview(List<Character[]> characters,
                                                    DebateTopic topic, List<CharacterArtCode> idleImage)
    {
        GameObject.FindObjectOfType<BlinkEffect>().gameObject.SetActive(false);
        GameObject.FindObjectOfType<DebateConfirm>().gameObject.SetActive(false);
        ScoreReviewEvent review = new GameObject("ScoreReviewEvent").AddComponent<ScoreReviewEvent>();
        review.characters = characters;
        review.topic = topic;
        review.playerIndex = 0;
        review.idleImage = idleImage;
        review.StartCoroutine(review.ShowReview());

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
    public IEnumerator ShowReview()
    {
        List<int> Result = new List<int>() { 0, 0, 0, 0 };
        scoreReviewUI = Resources.Load<ScoreReviewUI>("DebateScene/ScoreReviewUI");
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].Length == 0)
            {
                continue;
            }
            StartReview();
            var currentUI = Instantiate(scoreReviewUI, MainCanvas.FindMainCanvas());
            currentUI.Setup(idleImage[playerIndex], characters[playerIndex], debatePointCollectors);
            var currentRect = currentUI.GetComponent<RectTransform>();
            currentRect.localPosition = new Vector2(900, 0);
            yield return new WaitForSeconds(ReviewShiftDuration * 0.5f);
            currentRect.DOAnchorPosX(0, ReviewShiftDuration);
            yield return currentUI.StartReviewAnimation();
            Result[i] = currentUI.totalScore;
            currentRect.DOAnchorPosX(-900, ReviewShiftDuration);
            playerIndex++;
        }
        yield return new WaitForSeconds(ReviewShiftDuration);
        var effectAnimation = FindObjectOfType<DebateEffectAnimationController>();
        var damageList = effectAnimation.Setup(Result);
        yield return effectAnimation.StartCoroutine(effectAnimation.PlayRoutine());
        GameObject.FindObjectOfType<BlinkEffect>().gameObject.SetActive(true);
        GameEndCheck();
    }
    public void GameEndCheck()
    {
        var allUnits = FindObjectsOfType<DebateUnit>();
        var GET = FindObjectOfType<GeneralEventTrigger>();
        bool playerHaveTopScore = true;
        int playerScore = allUnits.First(x => x.isPlayer).Points;
        foreach (var unit in allUnits)
        {
            if (unit.Points > playerScore)
            {
                playerHaveTopScore = false;
                break;
            }
        }
        if (FindObjectOfType<DebateMainEventManager>().topicPool.Count == 0)
        {
            var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
            if (playerHaveTopScore) endCtrl.Win(); else endCtrl.Lose();
            Debug.Log("EndByOutOfTopic");
            return;
        }
        foreach (var unit in allUnits)
        {
            if (unit.Points <= 0)
            {
                if (unit.index == 0)
                {
                    var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
                    if (playerHaveTopScore) endCtrl.Win(); else endCtrl.Lose();
                    Debug.Log("EndByLostEnemy");
                    return;
                }
                else
                {
                    SetLoseCharacterOnCommitted(unit);
                    loseOrder.Add(unit);
                    characters[unit.index] = new Character[0] { };
                    unit.UnitDown();
                }
            }
            if (loseOrder.Count >= allUnits.Length - 1)
            {
                var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
                if (playerHaveTopScore) endCtrl.Win(); else endCtrl.Lose();
            }
        }
    }
    public void SetLoseCharacterOnCommitted(DebateUnit unit)
    {
        if (unit.isPlayer) return;
        foreach (Character character in unit.characters)
        {
            if (character.InGameAI == null)
            {
                Destroy(character.gameObject);
                continue;
            }
            character.hireStage = HireStage.Committed;
            character.loyalty = 20;
        }
    }
    public static int TestReview(List<Character[]> characters, DebateTopic topic)
    {
        var output = 0;
        var review = new ScoreReviewEvent();
        review.playerIndex = 0;
        review.characters = characters;
        review.topic = topic;
        review.StartReview();
        int point = 0, multi = 0;
        foreach (DebatePointCollector collector in review.debatePointCollectors)
        {
            var sample = TopicPointsCalculator.CollectorToPoints[collector];
            point += sample[1];
            multi += sample[0];
        }
        output = point * multi;
        Destroy(review);
        return output;
    }
    private void StartReview()
    {
        finalScore[0] = 0;
        finalScore[1] = 0;
        debatePointCollectors = new List<DebatePointCollector>() { };
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
            TryGetPoints(DebatePointCollector.感同身受, TopicPointsCalculator.CalculatPoints(DebatePointCollector.感同身受, topic, playerCharacres, topic.tagRequest));
        TryGetPoints(DebatePointCollector.地位超然, TopicPointsCalculator.CalculatPoints(DebatePointCollector.地位超然, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.言语粗鄙, TopicPointsCalculator.CalculatPoints(DebatePointCollector.地位超然, topic, playerCharacres, null));
        foreach (CharacterValueType valueType in topic.characterValue)
        {
            TryGetPoints(DebatePointCollector.权威, TopicPointsCalculator.CalculatPoints(DebatePointCollector.权威, topic, playerCharacres, new ArrayList { valueType, otherPlayerCharacters }));
            TryGetPoints(DebatePointCollector.词不对板, TopicPointsCalculator.CalculatPoints(DebatePointCollector.词不对板, topic, playerCharacres, valueType));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.权威))
        {
            TryGetPoints(DebatePointCollector.力压众异, TopicPointsCalculator.CalculatPoints(DebatePointCollector.力压众异, topic, playerCharacres, otherPlayerCharacters));
            TryGetPoints(DebatePointCollector.国士无双, TopicPointsCalculator.CalculatPoints(DebatePointCollector.国士无双, topic, playerCharacres, new ArrayList { otherPlayerCharacters, topic.tagRequest, topic.rarerity }));
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
        TryGetPoints(DebatePointCollector.乱心, TopicPointsCalculator.CalculatPoints(DebatePointCollector.乱心, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.绣花枕头, TopicPointsCalculator.CalculatPoints(DebatePointCollector.绣花枕头, topic, playerCharacres, otherPlayerCharacters));
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
        debatePointCollectors.Add(collector);
    }
}
