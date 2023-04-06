using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour, IDiceRollEvent
{
    public static PathManager Instance;
    public PathPoint[] points;
    public List<PathPoint> takenPoints = new List<PathPoint>();
    public List<PathPointHandler> handlers = new List<PathPointHandler>();
    public float timeRemaining = 0.5f;
    public float maxSpeed;
    public delegate void PointValidRequest();
    public Queue<PointValidRequest> RequestQueue = new Queue<PointValidRequest>();
    public List<IStopAllCoroutine> RegistedCoroutines = new List<IStopAllCoroutine>();
    private bool PlayerMoving
    {
        get
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
            return player.isMoving;
        }
    }

    public int NumbersOfRequest = 0;

    public void OnEnable()
    {
        Instance = this;
    }
    public void Awake()
    {
        Instance = this;
    }
    public void Reset()
    {
        handlers.Clear();
        StopAllCoroutines();
    }
    public void Start()
    {
        points = FindObjectsOfType<PathPoint>();
        foreach (var subject in GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IDiceSubject>())
        {
            subject.RegisterObserver(this);
        }
    }

    public void RegistHandler(PathPointHandler handler)
    {
        handlers.Add(handler);
    }

    public void UnregistHandler(PathPointHandler handler)
    {
        handlers.Remove(handler);
    }
    public IEnumerator ProcessRuntimeRator()
    {
        float waitingTime = 0;
        while (true)
        {
            PullRequest();
            waitingTime += Time.deltaTime;
            if (PlayerMoving)
            {
                if (RequestQueue.Count > 0)
                {
                    for (int i = 0; i < RequestQueue.Count; i++)
                    {
                        ProcessRequest(RequestQueue.Dequeue());
                        yield return null;
                    }
                }
                else if (waitingTime < timeRemaining) yield return new WaitForSeconds(0.01f);
            }
            else
            {
                Debug.Log("NumbersOfRequest : " + NumbersOfRequest + " |  handlers:" + handlers.Count);
                break;
            }
        }
        NumbersOfRequest = 0;
    }
    public IEnumerator StopAllMovement()
    {
        foreach (IStopAllCoroutine coroutine in RegistedCoroutines)
        {
            coroutine.StopAllCoroutine();
            yield return null;
        }
        Debug.Log("NumbersOfRequest : " + NumbersOfRequest + " |  handlers:" + handlers.Count);
        NumbersOfRequest = 0;
    }
    public static bool CheckIfPointTaken(PathPoint targetPoint)
    {
        var final = PathManager.Instance.takenPoints.Contains(targetPoint);
        return final;
    }

    public void NextPointValidation(PathPointHandler handler)
    {
        NumbersOfRequest += 1;
        bool Empty = !CheckIfPointTaken(handler.targetPoint);
        if (Empty == true)
        {
            handler.Ready = true;
            return;
        }
        else
        {
            handler.PlanPath();
        }
    }

    public void PullRequest()
    {
        foreach (PathPointHandler pph in handlers)
        {
            if (pph.request != null && pph.Ready == false)
            {
                RequestQueue.Enqueue(pph.request);
            }
        }
    }

    public void ProcessRequest(PointValidRequest request)
    {
        request.Invoke();
    }

    public void OnNotify(object value, NotificationType notificationType)
    {
        //Reset();
        timeRemaining = CharacterMovement.playerSpeed * (int)value / 2;
        Debug.Log("timeRemaining : "+timeRemaining);
        StartCoroutine(ProcessRuntimeRator());
    }
}
