using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CombatSceneController : MonoBehaviour
{
    CombatUI gameUI;
    BattleSystem gameBattleSystem;
    public Animator playerCharacter1;
    public Animator playerCharacter2;
    public Animator playerCharacter3;
    public Animator enemyCharacter1;
    public Animator enemyCharacter2;
    public Animator enemyCharacter3;

    public float duration = 0.5f;

    public bool OnAction = false;

    public Vector3 MiddleCameraPosition = new Vector3(8, 4, -10);
    public int CameraXShiftDistance = 6;
    private void Awake()
    {
        if (gameBattleSystem != null && gameBattleSystem.CurrentBattleState == BattleState.Start)
        {
            gameBattleSystem.StateAction();
        }
    }
    public void MoveTo(Animator character, Transform target)
    {
        MoveToTarget(character.transform, target);
    }
    public void CharacterAttack(Animator character)
    {
        //character.SetTrigger("Attack");
    }
    public void CharacterDefence(Animator character)
    {
        //character.SetTrigger("Defence");
    }
    public void CharacterAssasinate(Animator character)
    {
        //character.SetTrigger("Assasinate");
    }
    public void CharacterDamaged(Animator character)
    {
        //character.SetTrigger("Damaged");
    }
    private IEnumerator MoveToTarget(Transform character, Transform target)
    {
        var targetPosition = target.position;
        var startPosition = character.position;
        float time = 0;
        while (time < duration)
        {
            character.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
