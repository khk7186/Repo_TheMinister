using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ScoreMessageUI : MonoBehaviour
{
    public RectTransform mainPannel;
    public float showDuration = 0.1f;
    public Text messageText;
    public Text scoreText;
    public Text multiText;

    public void Setup(string[] text)
    {
        messageText.text = text[0];
        scoreText.text = text[1];
        multiText.text = text[2];
    }
    public IEnumerator ShowAnimation()
    {
        mainPannel.localScale = new Vector2(10, 10);
        mainPannel.DOScale(2,showDuration);
        yield return null;
    }
}
