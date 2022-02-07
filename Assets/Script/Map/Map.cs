using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Map : MonoBehaviour, IObserver
{
    public float Radius = 1.5f;
    public static int Week = 0;
    public static int Day = 6;
    private List<Block> map = new List<Block>();
    private int nextBlockToMove = 0;
    [SerializeField] private int currentBlock = 0;
    [SerializeField] private Transform Player;
    [SerializeField] private float delayPerMove = 1f;
    private List<Building> ActivatedBuildings = new List<Building>();

    [SerializeField] private float duration = 10f;
    [SerializeField] private Animator PlayerAnimator;

    public Transform currentTransform => (map.Count > 0) ? map[currentBlock].transform : null;

    private void Awake()
    {
        map = GetComponentsInChildren<Block>().ToList();
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
        Player.position = map[currentBlock].transform.position;
        nextBlockToMove = currentBlock;
        SetBuildings();
    }
    private void Start()
    {

    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            PlayerAnimator.SetTrigger("Move");
            Week += 1;
            Day = 1;
            StartCoroutine(MoveManyStep((int)value));
        }
    }

    private IEnumerator MoveAStep()
    {
        if (nextBlockToMove + 1 >= map.Count)
        {
            nextBlockToMove = -1;
        }
        nextBlockToMove += 1;
        var targetPosition = map[nextBlockToMove].transform.position;
        var startPosition = Player.position;
        float time = 0;
        while (time < duration)
        {
            Player.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        if (currentBlock == nextBlockToMove)
        {
            PlayerAnimator.SetTrigger("Stop");
            FindObjectOfType<Dice>().rolling = false;
        }
    }

    public IEnumerator MoveManyStep(int number)
    {
        currentBlock = (currentBlock + number) % (map.Count );
        for (int i = 0; i < number; i++)
        {
            var targetPosition = map[nextBlockToMove].transform.position;
            StartCoroutine(MoveAStep());
            yield return new WaitForSeconds(duration);
        }
        Debug.Log((currentBlock, nextBlockToMove,map.Count));
        SetBuildings();
    }

    //private IEnumerator MoveAndDelay(int steps)
    //{

    //    for (int i = 0; i < steps; i++)
    //    {
    //        MoveAStep();
    //        yield return new WaitForSeconds(delayPerMove);
    //    }
    //    SetBuildings();
    //}

    public List<Building> InteractebleBuildingCheck()
    {

        var colliders = Physics2D.OverlapCircleAll(Player.transform.position, Radius);
        var buildingList = new List<Building>();
        foreach (Collider2D collider2D in colliders)
        {
            if (collider2D.TryGetComponent<Building>(out Building building))
            {
                buildingList.Add(building);
            }
        }
        return buildingList;
    }

    public void SetActivateBuildingsInteracteble(List<Building> buildings, bool activate)
    {
        foreach (Building b in buildings)
        {
            b.GetComponent<InteractAsset>().Active = activate;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Player.transform.position, Radius);
    }
    public void SetBuildings()
    {
        SetActivateBuildingsInteracteble(ActivatedBuildings, false);
        ActivatedBuildings.Clear();
        var list = InteractebleBuildingCheck();
        SetActivateBuildingsInteracteble(list, true);
        ActivatedBuildings = list;
    }


}
