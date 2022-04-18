using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System.Linq;
using Spine.Unity;
public class Map : MonoBehaviour, IObserver
{
    public float Radius = 1.5f;
    public int DayTime = 0;
    public int Day = 0;
    //public List<Block> map = new List<Block>();
    public Grid movementGrid;
    public int mapCount => MovementGrid.EnemyInnerMovementBlocks.Count;
    private int PlayerNextBlockToMove = 0;
    [SerializeField] private int PlayerCurrentBlock = 0;
    [SerializeField] private Transform Player;
    [SerializeField] private float delayPerMove = 1f;
    private List<Building> ActivatedBuildings = new List<Building>();
    private bool OnMove => PlayerNextBlockToMove != PlayerCurrentBlock;

    public float duration = 10f;

    [SerializeField] private Animator PlayerAnimator;



    private void Awake()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
        Player.position = movementGrid.GetCellCenterWorld(MovementGrid.PlayerMovementBlocks[PlayerCurrentBlock]);
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
            PlayerAnimator.SetTrigger("Move");
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
            FindObjectOfType<MainUI>().SetupTime();
        }
        else
        {
            DayTime++;
        }
    }

    private IEnumerator MoveAStep(Transform character)
    {
        yield return StartCoroutine(TurnCheck());
        if (PlayerNextBlockToMove + 1 >= MovementGrid.PlayerMovementBlocks.Count)
        {
            PlayerNextBlockToMove = -1;
        }
        PlayerNextBlockToMove += 1;
        //var targetPosition = map[PlayerNextBlockToMove].transform.position;
        var targetPosition = movementGrid.GetCellCenterWorld(MovementGrid.GetPlayerBlock(PlayerNextBlockToMove));
        var startPosition = character.position;
        float time = 0;
        while (time < duration)
        {
            character.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        //if (!OnMove)
        //{
        //    PlayerAnimator.SetTrigger("Stop");
        //}
    }

    public IEnumerator MoveManyStep(int number, Transform character)
    {
        PlayerCurrentBlock = (PlayerCurrentBlock + number) % (MovementGrid.PlayerMovementBlocks.Count);
        for (int i = 0; i < number; i++)
        {

            yield return StartCoroutine(MoveAStep(character));
        }
        FindObjectOfType<Dice>().rolling = false;
        SetBuildings();
        PlayerAnimator.SetTrigger("Stop");
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

    public IEnumerator TurnCheck()
    {
        switch (PlayerNextBlockToMove)
        {
            default:
                break;
            case 18:
            case 30:
            case 40:
                ChangeSide(false, false);
                //back right
                break;
            case 69:
            case 62:
                ChangeSide(true, false);
                //right front
                break;
            case 59:
            case 53:
            case 57:
            case 47:
            case 63:
            case 61:
                ChangeSide(true, true);
                //front left
                break;
            case 42:
            case 27:
            case 49:
            case 56:
            case 58:
            case 33:
                ChangeSide(false, true);
                //back left
                break;
        }
        yield return null;
    }
    //@param doFront
    //@param doLeft
    private void ChangeSide(bool doFront, bool doLeft)
    {
        //bool isMoving = PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Move");
        PlayerAnimator.SetTrigger("Stop");
        string side = doFront ? "Front" : "Back";
        string SDApath = $"{ReturnAssetPath.ReturnMainCharacterAssetPath(doFront)}ÀîÔ¬Ä°_{side}_SkeletonData";
        string controllerPath = $"{ReturnAssetPath.ReturnMainCharacterAssetPath(doFront)}ÀîÔ¬Ä°_{side}_Controller";
        PlayerAnimator.GetComponent<SkeletonMecanim>().skeletonDataAsset = Resources.Load<SkeletonDataAsset>(SDApath);
        PlayerAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
        Vector3 target = PlayerAnimator.transform.localScale;
        target = new Vector3((doLeft ? 0.7f : -0.7f), target.y, target.z);
        PlayerAnimator.transform.localScale = target;
        PlayerAnimator.GetComponent<SkeletonMecanim>().Initialize(true);
        PlayerAnimator.SetTrigger(OnMove ? "Move" : "Stop");
        //if (OnMove)
        //{
        //    PlayerAnimator.SetTrigger("Move");
        //}
        //else
        //{
        //    PlayerAnimator.SetTrigger("Stop");
        //}
    }
}
