using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
