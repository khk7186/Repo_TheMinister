using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Map : MonoBehaviour, IObserver
{
    public float Radius = 1.5f;
    public int DayTime = 0;
    public int Day = 0;
    public List<Block> map = new List<Block>();
    public int mapCount => map.Count;
    private int PlayerNextBlockToMove = 0;
    [SerializeField] private int PlayerCurrentBlock = 0;
    [SerializeField] private Transform Player;
    [SerializeField] private float delayPerMove = 1f;
    private List<Building> ActivatedBuildings = new List<Building>();
    private bool OnMove => PlayerNextBlockToMove != PlayerCurrentBlock;

    public float duration = 10f;
    [SerializeField] private Animator FrontPlayerAnimator;
    [SerializeField] private Animator BackPlayerAnimator;

    public Transform currentTransform => (map.Count > 0) ? map[PlayerCurrentBlock].transform : null;

    private void Awake()
    {
        map = GetComponentsInChildren<Block>().ToList();
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
        Player.position = map[PlayerCurrentBlock].transform.position;
        PlayerNextBlockToMove = PlayerCurrentBlock;
        SetBuildings();
    }
    private void Start()
    {

    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            FrontPlayerAnimator.SetTrigger("Move");
            BackPlayerAnimator.SetTrigger("Move");
            DayTimePlus();
            StartCoroutine(MoveManyStep((int)value, Player));
        }
    }

    private void DayTimePlus()
    {
        if (DayTime >= 2)
        {
            Day++;
            DayTime = 0;
        }
        else DayTime++;
    }

    private IEnumerator MoveAStep(Transform character)
    {
        if (PlayerNextBlockToMove + 1 >= map.Count)
        {
            PlayerNextBlockToMove = -1;
        }
        PlayerNextBlockToMove += 1;
        var targetPosition = map[PlayerNextBlockToMove].transform.position;
        var startPosition = character.position;
        float time = 0;
        while (time < duration)
        {
            character.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator MoveManyStep(int number,Transform character)
    {
        PlayerCurrentBlock = (PlayerCurrentBlock + number) % (map.Count);
        for (int i = 0; i < number; i++)
        {
            StartCoroutine(MoveAStep(character));
            yield return new WaitForSeconds(duration);
            TurnCheck();
        }
        if (FrontPlayerAnimator.gameObject.activeSelf) FrontPlayerAnimator.SetTrigger("Stop");
        if (BackPlayerAnimator.gameObject.activeSelf) BackPlayerAnimator.SetTrigger("Stop");

        FindObjectOfType<Dice>().rolling = false;
        SetBuildings();
    }

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

    public void TurnCheck()
    {
        switch (PlayerNextBlockToMove)
        {
            default:
                break;
            case 18:
            case 30:
            case 40:
                FrontPlayerAnimator.SetTrigger("Stop");
                BackPlayerAnimator.SetTrigger("Stop");
                FrontPlayerAnimator.gameObject.SetActive(false);
                BackPlayerAnimator.gameObject.SetActive(true);
                BackPlayerAnimator.transform.localScale = new Vector2(-0.7f, 0.7f);
                if (OnMove)
                {
                    BackPlayerAnimator.SetTrigger("Move");
                }
                break;
            case 69:
            case 62:
                FrontPlayerAnimator.SetTrigger("Stop");
                BackPlayerAnimator.SetTrigger("Stop");
                FrontPlayerAnimator.gameObject.SetActive(true);
                BackPlayerAnimator.gameObject.SetActive(false);
                FrontPlayerAnimator.transform.localScale = new Vector2(-0.7f, 0.7f);
                if (OnMove)
                {
                    FrontPlayerAnimator.SetTrigger("Move");
                }
                //right front
                break;
            case 59:
            case 53:
            case 57:
            case 47:
            case 63:
            case 61:
                FrontPlayerAnimator.SetTrigger("Stop");
                BackPlayerAnimator.SetTrigger("Stop");
                FrontPlayerAnimator.gameObject.SetActive(true);
                BackPlayerAnimator.gameObject.SetActive(false);
                FrontPlayerAnimator.transform.localScale = new Vector2(0.7f, 0.7f);
                if (OnMove)
                {
                    FrontPlayerAnimator.SetTrigger("Move");
                }
                //front left
                break;
            case 42:
            case 27:
            case 49:
            case 56:
            case 58:
            case 33:
                FrontPlayerAnimator.SetTrigger("Stop");
                BackPlayerAnimator.SetTrigger("Stop");
                FrontPlayerAnimator.gameObject.SetActive(false);
                BackPlayerAnimator.gameObject.SetActive(true);
                BackPlayerAnimator.transform.localScale = new Vector2(0.7f, 0.7f);
                if (OnMove)
                {
                    BackPlayerAnimator.SetTrigger("Move");
                }
                //back left
                break;
        }
    }
}
