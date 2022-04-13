using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public enum AIInteractType
{
    Combat,
    Hire,
    Trade,
    Gobang,
    Debate,
    Talk
}
public enum TimeInDay
{
    Morning,
    Noon,
    Evening,
}
public class DefaultInGameAI : MonoBehaviour, IAIMovementStrategy, IObserver
{
    private Map map;
    public string Name = "";
    [SerializeField] private List<AIInteractType> types;
    public int NightBlock;
    public int DayMaxBlock, DayMinBlock;
    public bool inner = true;
    public int CurrentLocation;
    public int NextBlockToMove;
    public int TargetLocation;
    public Character character;
    public NPCPopUI npcPopUI;
    [SerializeField] private bool OnNight => map ? map.DayTime == 2 : false;
    public Animator animator;
    //private string NPCJsonPath = "JSON/AIOnMapMovement";
    public Grid movementGrid;
    private bool pointerHere = false;

    private void Awake()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
        map = FindObjectOfType<Map>();
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            Move();
        }
    }
    public void Setup(Character character)
    {
        this.character = character;
        NightBlock = Random.Range(0, map.mapCount);
        int tryMax = NightBlock + (Random.Range(0, 1) == 0 ? -1 : 1) * Random.Range(4, 10) % map.mapCount;
        if (tryMax < 0)
        {
            DayMaxBlock = tryMax + map.mapCount;
        }
        else if (tryMax > map.mapCount)
        {
            DayMaxBlock -= map.mapCount;
        }
        int tryMin = DayMinBlock - Random.Range(3, 10);
        DayMinBlock = (tryMin < 0) ? tryMin + map.mapCount : tryMin;
        CurrentLocation = OnNight ? NightBlock : Random.Range(DayMinBlock, DayMaxBlock);
        transform.position = map.map[CurrentLocation].transform.position;
    }
    public void Move()
    {
        int steps;
        if (OnNight)
        {
            TargetLocation = NightBlock;
        }
        else
        {
            TargetLocation = Random.Range(DayMinBlock, DayMaxBlock + 1);
        }
        if (TargetLocation < CurrentLocation)
        {
            steps = (TargetLocation + map.mapCount - CurrentLocation);
        }
        else
        {
            steps = (TargetLocation - CurrentLocation);
        }
        if (Mathf.Abs(steps) > map.mapCount / 2)
        {
            if (steps > map.mapCount / 2)
            {
                steps = -(map.mapCount - steps);
            }
            else if (steps <= map.mapCount / 2)
            {
                steps = (map.mapCount - steps);
            }
        }
        StartCoroutine(MoveManyStep(steps));
    }
    private IEnumerator MoveAStepForward()
    {
        if (NextBlockToMove + 1 >= map.mapCount)
        {
            NextBlockToMove = -1;
        }
        NextBlockToMove += 1;
        var targetPosition = map.map[NextBlockToMove].transform.position;
        //var targetPosition = movementGrid.GetCellCenterWorld(MovementGrid.GetAIBlock(this, NextBlockToMove));
        var startPosition = transform.position;
        float time = 0;
        while (time < map.duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / map.duration * 3f);
            time += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator MoveAStepBackward()
    {
        if (NextBlockToMove - 1 < 0)
        {
            NextBlockToMove = 70;
        }
        NextBlockToMove -= 1;
        var targetPosition = map.map[NextBlockToMove].transform.position;
        var startPosition = transform.position;
        float time = 0;
        while (time < map.duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / map.duration * 3f);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator MoveManyStep(int steps)
    {
        CurrentLocation = (CurrentLocation + steps) % (map.mapCount);
        if (steps <= 0)
        {
            for (int i = 0; i < Mathf.Abs(steps); i++)
            {
                StartCoroutine(MoveAStepBackward());
                yield return new WaitForSeconds(map.duration / 3f);
            }

        }
        else if (steps > 0)
        {
            for (int i = 0; i < steps; i++)
            {
                StartCoroutine(MoveAStepForward());
                yield return new WaitForSeconds(map.duration / 3f);
            }
        }


        //map.TurnCheck();
        animator.SetTrigger("Stop");
    }

    private void OnMouseDown()
    {
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                pointerHere = true;
            }
        }
    }
    private void OnMouseUp()
    {
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (npcPopUI == null)
                {
                    string path = "NPCInteractiveUI/InteractiveUI/Menu";
                    npcPopUI = Instantiate(Resources.Load<NPCPopUI>(path), MainCanvas.FindMainCanvas().transform);
                    if (npcPopUI != null)
                    {
                        npcPopUI.Setup(character, types, transform);
                    }
                }
            }
        }
        else pointerHere = false;
    }
    //set inner as <param>inner
    public void SetInner(bool inner)
    {
        this.inner = inner;
    }
}
