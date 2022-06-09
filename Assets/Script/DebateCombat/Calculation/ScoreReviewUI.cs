using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReviewUI : MonoBehaviour
{
    public RectTransform mainPannel;
    public Image Idle;
    public RectTransform SelectedCharacters;
    public TotalPointsUI totalScorePannel;
    public RectTransform scorePannel;
    public RectTransform multiPannel;
    public RectTransform pointCollectmultiPannel;
    public ScoreMessageUI messageUIPref;
    public Text currentPointCollectName;
    public Text currentScore;
    public Text currentMulti;
    public RectTransform stageOneTargetPoint;
    public RectTransform stageTwoTargetPoint;
    public RectTransform MessageQueue;
    public RectTransform ContinueMessage;
    private List<RectTransform> unreadScoreMessages = new List<RectTransform>();
    public void Setup(CharacterArtCode masterIdle, Character[] characters, DebatePointCollector[] debatePointCollectors)
    {
        Idle.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(masterIdle));
        var characterHeadUIs = SelectedCharacters.GetComponentsInChildren<RectTransform>();
        int index = 0;
        foreach (var character in characters)
        {
            characterHeadUIs[index].GetComponentInChildren<Image>().sprite
                = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false));
            index++;
        }
        index = 0;
        foreach (var debatePointCollector in debatePointCollectors)
        {
            var newMessage = Instantiate(messageUIPref, MessageQueue);
            newMessage.GetComponent<RectTransform>().localScale = Vector3.zero;
            string[] input
                = new string[] { debatePointCollector.ToString(),
                TopicPointsCalculator.CollectorToPoints[ debatePointCollector][1].ToString(),
                 TopicPointsCalculator.CollectorToPoints[ debatePointCollector][0].ToString()};
            RectTransform pStart = characterHeadUIs[index];
            newMessage.Setup(input, pStart);
            unreadScoreMessages.Add(newMessage.GetComponent<RectTransform>());
            index++;
            if (index >= 3)
            {
                index = 0;
            }
        }
    }
    public void Test()
    {
        StartCoroutine(StartReviewAnimation());
    }
    public IEnumerator StartReviewAnimation()
    {
        var UnreadQueue = MessageQueue.GetComponentsInChildren<ScoreMessageUI>();
        foreach (ScoreMessageUI message in UnreadQueue)
        {
            yield return message.StartMessageAnimation();
        }
        if (totalScorePannel == null)
            totalScorePannel = FindObjectOfType<TotalPointsUI>();
        yield return totalScorePannel.StartCoroutine(totalScorePannel.FinalCount());
        ContinueMessage.gameObject.SetActive(true);
        yield return WaitForClick();
    }
    public IEnumerator FinishAnimation()
    {
        yield return null;
    }
    public IEnumerator WaitForClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
