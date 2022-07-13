using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Text.RegularExpressions;
public class ScoreMessageUI : MonoBehaviour
{
    public RectTransform mainPannel;
    public RectTransform pointPannel;
    public RectTransform multiPannel;
    public float showDuration = 0.25f;
    public Text messageText;
    public Text scoreText;
    public Text multiText;
    public RectTransform startPoint;
    public AnimationCurve stageOneCurve, stageTwoCurve;

    public void Setup(string[] text, RectTransform startPoint)
    {
        messageText.text = text[0];
        scoreText.text = text[1];
        multiText.text = text[2];
        this.startPoint = startPoint;
    }

    public IEnumerator StageOneAnimation()
    {
        mainPannel.SetParent(startPoint);
        mainPannel.anchoredPosition = new Vector2(30, -30);
        mainPannel.localScale = new Vector2(0, 0);
        mainPannel.DOScale(1, showDuration);
        float time = 0f;
        var finalTransform = FindObjectOfType<ScoreReviewUI>().stageOneTargetPoint;
        mainPannel.SetParent(finalTransform);
        var stageOnePoint = new Vector2(50, -50);
        var Origin = mainPannel.anchoredPosition;
        while (time < showDuration)
        {
            time += Time.deltaTime;
            float targetX = Mathf.Lerp(Origin.x, stageOnePoint.x, time / showDuration);
            float targetY = Mathf.Lerp(Origin.y, stageOnePoint.y, time / showDuration);
            mainPannel.anchoredPosition = new Vector2(targetX, targetY);
            yield return null;
        }
        yield return null;
    }
    public IEnumerator StageTwoAnimation()
    {
        mainPannel.DOScale(0.3f, showDuration);
        float time = 0f;
        var finalTransform = FindObjectOfType<ScoreReviewUI>().stageTwoTargetPoint;
        var index = finalTransform.childCount;
        mainPannel.SetParent(finalTransform);
        var Origin = mainPannel.anchoredPosition;
        var finalX = 100;
        var finalY = -100 - 20 * index;
        var targetPos = new Vector2(finalX, finalY);
        var pointOrigin = pointPannel.anchoredPosition;
        var pointFinal = new Vector3(249, 65, 0);
        var multiOrigin = multiPannel.anchoredPosition;
        var multiFinal = new Vector3(195, 65, 0);
        while (time < showDuration)
        {
            time += Time.deltaTime;
            float targetX = Mathf.Lerp(Origin.x, targetPos.x, time / showDuration);
            float targetY = Mathf.Lerp(Origin.y, targetPos.y, time / showDuration);
            mainPannel.anchoredPosition = new Vector2(targetX, targetY);
            pointPannel.anchoredPosition = Vector3.Lerp(pointOrigin, pointFinal, time / showDuration);
            multiPannel.anchoredPosition = Vector3.Lerp(multiOrigin, multiFinal, time / showDuration);
            yield return null;
        }
        yield return null;
    }
    public IEnumerator StartMessageAnimation()
    {
        yield return StageOneAnimation();
        yield return new WaitForSeconds(showDuration);
        var totalPannel = FindObjectOfType<TotalPointsUI>();
        totalPannel.StartCoroutine(totalPannel.StartAnimate(int.Parse(scoreText.text), int.Parse(multiText.text.Replace("¡Á", ""))));
        StartCoroutine(StageTwoAnimation());
    }
}
