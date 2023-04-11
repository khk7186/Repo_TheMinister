using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class CombatSceneController : MonoBehaviour
{
    BattleSystem gameBattleSystem;

    public List<Vector3Int> friendList = new List<Vector3Int>()
    { new Vector3Int(-1, -2, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0) };
    public List<Vector3Int> enemyList = new List<Vector3Int>()
    { new Vector3Int(2, -2, 0), new Vector3Int(2, -1, 0), new Vector3Int(2, 0, 0) };

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += InitializeScene;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= InitializeScene;
    }
    private void SetLevel()
    {
        var map = GameObject.FindObjectOfType<Map>();

    }
    private void InitializeScene(Scene scene, LoadSceneMode mode)
    {
        InitializeEnvirment();
        var trigger = FindObjectOfType<GeneralEventTrigger>();
        InitializeCCUs(trigger.playerCharacters);
        InitializeCCUs(trigger.enemyCharacters);
        var ccus = FindObjectsOfType<CombatCharacterUnit>();
        int PlayerOrder = 0;
        int EnemyOrder = 0;
        foreach (var ccu in ccus)
        {
            switch (ccu.IsFriend)   
            {
                case true:
                    ccu.SetGridPosition(friendList[PlayerOrder]);
                    PlayerOrder++;
                    break;
                case false:
                    ccu.SetGridPosition(enemyList[EnemyOrder]);
                    EnemyOrder++;
                    break;
            }
        }
    }
    private void InitializeEnvirment()
    {
        var area = AreaControl.instant.CurrentArea;
        SOAssetDB sOAssetDB = Resources.Load<SOAssetDB>("Data/AssetDatabase");
        AreaControl areaControl = AreaControl.instant;
        Map map = Map.Instance;
        var asset = sOAssetDB.LoadCombatEnv(areaControl.CurrentArea, (TimeInDay)map.DayTime);
        Instantiate(asset);
    }
    private List<CombatCharacterUnit> InitializeCCUs(List<Character> characters)
    {
        foreach (var character in characters)
        {
            if (character != null)
            {
                //Debug.Log(character.characterArtCode);
                CombatCharacterUnit.NewCombatCharacterUnit(character, character.hireStage == HireStage.Hired);
            }
        }
        var output = new List<CombatCharacterUnit>();
        return output;
    }
    private void Start()
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
            //var targetDir = unit.IsFriend ? -1 : 1;
            //if (csc.CameraAdjast != targetDir)
            //{
            //    csc.CameraAdjast = targetDir;
            //    csc.MoveCamera();
            //}
            csc.Animating = true;
            var combatUI = FindObjectOfType<CombatUI>();

            /*ctl k u this line for properuse*/
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
