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
    public float CameraXShiftDistance = 6;
    public float CameraYShiftDistance = 1;

    public bool Animating = false;
    public bool lining = false;
    public int CameraAdjast = 0;
    public CombatCharacterUnit CurrentOnActionCCU = null;

    public int CameraSizeOrigin = 16;
    public int CameraSizeFocus = 14;
    private bool OnFocus = false;
    private bool FocusAnimation = false;
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
    public static void MoveCamera(int adjast)
    {
        var csc = FindObjectOfType<CombatSceneController>();
        csc.CameraAdjast = adjast;
        csc.MoveCamera();
    }
    public void MoveCamera()
    {
        var targetPosition = MiddleCameraPosition;
        targetPosition.x += CameraAdjast * CameraXShiftDistance;
        targetPosition.y += CameraAdjast * CameraYShiftDistance;
        StartCoroutine(CameraMovement(targetPosition));
    }

    public static void CameraFocus(bool focus)
    {
        var csc = FindObjectOfType<CombatSceneController>();
        csc.StartFocusing(focus);
    }

    public void StartFocusing(bool focus)
    {
        StartCoroutine(CameraFocusRator(focus));
    }
    IEnumerator CameraFocusRator(bool focus)
    {
        var cam = Camera.main;
        float time = 0;
        bool SizeDiff = (OnFocus != focus);
        var sizeNow = cam.orthographicSize;
        if (SizeDiff)
        {
            FocusAnimation = !FocusAnimation;
            var memory = FocusAnimation;
            OnFocus = focus;
            Debug.Log(1);
            while (time < duration && FocusAnimation == memory)
            {
                //focus camera
                float size = CameraSizeOrigin;
                if (focus)
                {
                    size = Mathf.Lerp(sizeNow, CameraSizeFocus, time / duration);
                }
                else
                {
                    size = Mathf.Lerp(sizeNow, CameraSizeOrigin, time / duration);
                }
                cam.orthographicSize = size;
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
    IEnumerator CameraMovement(Vector3 targetPos)
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
