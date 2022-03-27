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

    public bool Animating = false;
    public bool lining = false;
    public int CameraAdjast = 0;
    public CombatCharacterUnit CurrentOnActionCCU = null;
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
    public static void ShowCard(CombatCharacterUnit unit)
    {
        var csc = FindObjectOfType<CombatSceneController>();
        if (csc.Animating == false)
        {
            var targetDir = unit.IsFriend ? -1 : 1;
            if (csc.CameraAdjast != targetDir)
            {
                csc.CameraAdjast = targetDir;
                csc.MoveCamera();
            }
            var combatUI = FindObjectOfType<CombatUI>();
            csc.Animating = true;
            combatUI.ShowNewCard(unit);
        }
    }
    public void MoveCamera()
    {
        var targetPosition = MiddleCameraPosition;
        targetPosition.x += CameraAdjast * 6;
        StartCoroutine(CameraMovement(targetPosition, 1f));
    }
    IEnumerator CameraMovement(Vector3 targetPos, float duration)
    {
        var cam = Camera.main.transform;
        float time = 0;
        int currentDir = CameraAdjast;
        while (time < duration && currentDir == CameraAdjast)
        {
            var newPos = Vector3.Lerp(cam.position, targetPos, time / duration);
            cam.position = newPos;
            time += Time.deltaTime;
            yield return null;
        }
    }
    //private IEnumerator CameraMovement(Vector3 targetPos, float speed)
    //{
    //    var currentPos = transform.position;
    //    var distance = Vector3.Distance(currentPos, targetPos);
    //    // TODO: make sure speed is always > 0
    //    var duration = distance / speed;
    //    var cam = Camera.main.transform;

    //    var timePassed = 0f;
    //    while (timePassed < duration)
    //    {
    //        // always a factor between 0 and 1
    //        var factor = timePassed / duration;

    //        cam.position = Vector3.Lerp(currentPos, targetPos, factor);

    //        // increase timePassed with Mathf.Min to avoid overshooting
    //        timePassed += Mathf.Min(Time.deltaTime, duration - timePassed);

    //        // "Pause" the routine here, render this frame and continue
    //        // from here in the next frame
    //        yield return null;
    //    }

    //    cam.position = targetPos;

    //    // Something you want to do when moving is done
    //}
}
