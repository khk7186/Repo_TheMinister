using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    Map map;
    public string Name = "";
    private List<AIInteractType> types;
    public int NightBlock;
    public int DayMaxBlock, DayMinBlock;
    public int CurrentLocation;
    public int NextBlockToMove;
    public int TargetLocation;
    [SerializeField] private bool OnNight => Map.DayTime == 2;
    public Animator FrontAnimator;
    public Animator BackAnimator;
    private string NPCJsonPath = "JSON/AIOnMapMovement";
    private void Awake()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
    }
    private void Start()
    {
        map = FindObjectOfType<Map>();
        transform.position = map.map[CurrentLocation].transform.position;
        //TextAsset json = Resources.Load<TextAsset>(NPCJsonPath);
        //var npcList = JsonUtility.FromJson<List<int>>(json.text);
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            Move();
        }
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
            steps = (TargetLocation+map.mapCount - CurrentLocation);
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
        var startPosition = transform.position;
        float time = 0;
        while (time < map.duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / map.duration);
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
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / map.duration);
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
                yield return new WaitForSeconds(map.duration);
            }
            
        }
        else if (steps > 0)
        {
            for (int i = 0; i < steps; i++)
            {
                StartCoroutine(MoveAStepForward());
                yield return new WaitForSeconds(map.duration);
            }
        }


        //map.TurnCheck();
        if (FrontAnimator.gameObject.activeSelf) FrontAnimator.SetTrigger("Stop");
        if (BackAnimator.gameObject.activeSelf) BackAnimator.SetTrigger("Stop");
    }


}
