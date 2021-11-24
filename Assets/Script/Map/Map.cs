using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Map : MonoBehaviour, IObserver
{
    public static int Week = 1;
    public static int Day = 6;
    private List<Block> map = new List<Block>();
    [SerializeField] private int currentBlock = 0;
    [SerializeField] private Transform Player;
    [SerializeField] private float delayPerMove = 1f;
    private List<Building> ActivatedBuildings = new List<Building>();

    public Transform currentTransform => (map.Count > 0) ? map[currentBlock].transform : null;

    private void Awake()
    {
        map = GetComponentsInChildren<Block>().ToList();
        FindObjectOfType<Dice>().RegisterObserver(this);
        SetBuildings();
    }
    private void Start()
    {
        Player.position = map[0].transform.position;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.MovePlayer)
        {
            Week += 1;
            Day = 1;
            StartCoroutine(MoveAndDelay((int)value));
        }
    }

    private void MoveAStep()
    {
        if (currentBlock+1 >= map.Count)
        {
            currentBlock = 0;
        }
        else
        {
            currentBlock += 1;
        }
        Player.position = map[currentBlock].transform.position;

    }

    public void MoveAStep(int number)
    {
        for (int i = 0; i < number; i++)
        {
            MoveAStep();
        }
        SetBuildings();
    }

    private IEnumerator MoveAndDelay(int steps)
    {

        for (int i = 0; i < steps; i++)
        {
            MoveAStep();
            yield return new WaitForSeconds(delayPerMove);
        }
        SetBuildings();
    }

    public List<Building> InteractebleBuildingCheck()
    {

        var colliders = Physics2D.OverlapCircleAll(Player.transform.position, 1.5f);
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
        Gizmos.DrawWireSphere(Player.transform.position, 1.5f);
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
