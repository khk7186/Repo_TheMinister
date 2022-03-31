using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatUI : MonoBehaviour
{
    public Transform playerInfoTransform;
    public CharacterUI currentPlayer;
    public Transform enemyInfoTransform;
    public CharacterUI currentEnemy;
    public CharacterUI characterUI;
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
                var target = Instantiate(characterUI, playerInfoTransform);
                var targetRect = target.GetComponent<RectTransform>();
                targetRect.anchoredPosition = new Vector2(-170, 0);
                targetRect.anchorMin = new Vector2(0, 0.5f);
                targetRect.anchorMax = new Vector2(0, 0.5f);
                targetRect.pivot = new Vector2(0, 0.5f);
                target.character = character.character;
                target.Setup();
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
                var target = Instantiate(characterUI, enemyInfoTransform);
                var targetRect = target.GetComponent<RectTransform>();
                targetRect.anchoredPosition = new Vector2(170, 0);
                targetRect.anchorMin = new Vector2(1, 0.5f);
                targetRect.anchorMax = new Vector2(1, 0.5f);
                targetRect.pivot = new Vector2(1, 0.5f);
                target.character = character.character;
                target.Setup();
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
            .DOAnchorPosX(-range, duration / 2)
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
            .DOAnchorPosX(range, duration / 2)
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
