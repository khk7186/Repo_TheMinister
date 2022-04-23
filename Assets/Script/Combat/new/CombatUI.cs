using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CombatUI : MonoBehaviour
{
    public Transform playerInfoTransform;
    public FlagUI currentPlayer;
    public Transform enemyInfoTransform;
    public FlagUI currentEnemy;
    public FlagUI flagUI;
    public float duration = 1;
    public float range = 15;
    public Ease effect = Ease.Linear;

    public Character characterOnDisplay = null;

    public Image blackFrame;
    public Image redFrame;
    public float UItransDuration = 0.2f;

    public RectTransform CombatSign;
    public RectTransform ControlPannel;

    public void ShowNewCard(CombatCharacterUnit character)
    {
        bool NotOnDisplay = characterOnDisplay != character.character;

        if (character.IsFriend)
        {
            if (NotOnDisplay)
            {
                RemovePlayerCurrent();
                RemoveEnemyCurrent();
                var target = Instantiate(flagUI, playerInfoTransform);
                var targetRect = target.GetComponent<RectTransform>();
                targetRect.anchoredPosition = new Vector2(-459, 120);
                targetRect.anchorMin = new Vector2(0.5f, 0.5f);
                targetRect.anchorMax = new Vector2(0.5f, 0.5f);
                targetRect.pivot = new Vector2(0.5f, 0.5f);
                target.Setup(character.character);
                currentPlayer = target;
                characterOnDisplay = character.character;
                targetRect
                    .DOAnchorPosX(range, duration)
                    .SetEase(effect)
                        .SetDelay(0.1f)
                        .OnComplete(() =>
                        {
                            FindObjectOfType<CombatSceneController>().Animating = false;
                        });
            }
            else
            {
                var csc = FindObjectOfType<CombatSceneController>();
                csc.Animating = false;
            }
        }
        else if (!character.IsFriend)
        {
            if (NotOnDisplay)
            {
                RemoveEnemyCurrent();
                RemovePlayerCurrent();
                var target = Instantiate(flagUI, enemyInfoTransform);
                var targetRect = target.GetComponent<RectTransform>();
                targetRect.anchoredPosition = new Vector2(459, 120);
                targetRect.anchorMin = new Vector2(0.5f, 0.5f);
                targetRect.anchorMax = new Vector2(0.5f, 0.5f);
                targetRect.pivot = new Vector2(0.5f, 0.5f);
                target.Setup(character.character);
                currentEnemy = target;
                characterOnDisplay = character.character;
                targetRect
                    .DOAnchorPosX(-range, duration)
                    .SetEase(effect)
                        .SetDelay(0.1f)
                        .OnComplete(() =>
                        {
                            FindObjectOfType<CombatSceneController>().Animating = false;
                        });
            }
            else
            {
                var csc = FindObjectOfType<CombatSceneController>();
                csc.Animating = false;
            }
        }
    }

    private void RemovePlayerCurrent()
    {
        if (currentPlayer != null)
        {
            var current = currentPlayer.GetComponent<RectTransform>();
            current
            .DOAnchorPosY(400, duration / 2)
            .SetEase(effect)
            .SetDelay(0.1f)
            .OnComplete(() =>
            {
                Destroy(current.gameObject);
            }); ;
            return;
        }
        return;
    }
    private void RemoveEnemyCurrent()
    {
        if (currentEnemy != null)
        {
            var current = currentEnemy.GetComponent<RectTransform>();
            current
            .DOAnchorPosY(400, duration / 2)
                .SetEase(effect)
                .SetDelay(0.1f)
                .OnComplete(() =>
                {
                    Destroy(current.gameObject);
                });
            return;
        }
        return;
    }

    public void BlackFrameAnimation(bool open = false)
    {
        Debug.Log(open);
        float scale = open ? 1.5f : 1f;
        blackFrame.GetComponent<RectTransform>().DOScale(scale, UItransDuration).SetEase(Ease.OutSine);

        float pos = open ? 650 : 0;
        CombatSign.GetComponent<RectTransform>().DOAnchorPosY(pos, UItransDuration).SetEase(Ease.OutSine);

        float pannelPos = open ? 0 : 145;
        bool show = open ? true : false;
        ControlPannel.DOAnchorPosX(pannelPos, UItransDuration).SetEase(Ease.OutSine).OnComplete(() =>
        {
            ControlPannel.gameObject.SetActive(show);
        });

        float flagPos = open ? 0f : 230f;
        playerInfoTransform.GetComponent<RectTransform>().DOAnchorPosY(flagPos, UItransDuration).SetEase(Ease.OutSine);
        enemyInfoTransform.GetComponent<RectTransform>().DOAnchorPosY(flagPos, UItransDuration).SetEase(Ease.OutSine);
    }
}
