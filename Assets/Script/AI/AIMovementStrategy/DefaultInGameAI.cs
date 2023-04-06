using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Spine.Unity;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;

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
public class DefaultInGameAI : MonoBehaviour, IAIMovementStrategy, IDiceRollEvent
{
    private Map map;
    public string Name = "";
    public PathPoint currentPathPoint;
    [SerializeField] private List<AIInteractType> types;
    public int NightBlock;
    public int DayMaxBlock, DayMinBlock;
    public bool inner = true;
    public int CurrentLocation;
    public int NextBlockToMove;
    public int TargetLocation;
    public Character character;
    public NPCPopUI npcPopUI;
    public int TryMax = 10;
    public int TryChance = 3;

    [SerializeField] private bool OnNight => map ? map.DayTime == 2 : false;
    public Animator animator;
    //private string NPCJsonPath = "JSON/AIOnMapMovement";
    public Grid movementGrid;
    public NPCConversationTriggerGroup npcConversationTriggerGroup;
    protected void Awake()
    {
        movementGrid = FindObjectOfType<MovementGrid>().GetComponent<Grid>();
        inner = Random.Range(0, 2) == 0 ? false : true;
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<IDiceSubject>())
        {
            subject.RegisterObserver(this);
        }
        map = FindObjectOfType<Map>();
        transform.position = currentPathPoint.transform.position;
        
    }
    private void Start()
    {
        Debug.Log(PathManager.Instance == null);
        PathManager.Instance.takenPoints.Add(currentPathPoint);
    }
    public virtual void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            Move();
        }
    }
    public void SetSpine()
    {
        SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
            ($"{ReturnAssetPath.ReturnSpineAssetPath(character.characterArtCode, true)}");
        animator.GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
        string controllerPath = $"{ReturnAssetPath.ReturnSpineControllerPath(character.characterArtCode, true)}";
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
        animator.GetComponent<SkeletonMecanim>().Initialize(true);
    }
    public virtual void Setup(Character character)
    {
        this.character = character;
        SetSpine();
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
        transform.position = movementGrid.GetCellCenterWorld(MovementGrid.GetAIBlock(this, CurrentLocation));
        SetConversationDatabase();
        if (npcConversationTriggerGroup == null)
        {
            Debug.Log(character.characterArtCode);
        }
    }
    //public void Move()
    //{
    //    //int steps;
    //    if (OnNight)
    //    {
    //        TargetLocation = NightBlock;
    //    }
    //    else
    //    {
    //        TargetLocation = Random.Range(DayMinBlock, DayMaxBlock + 1);
    //    }
    //    var movement = GetComponent<CharacterMovement>();
    //    movement.finalBlock = TargetLocation;
    //    StartCoroutine(movement.MoveToLocation());
    //    //StartCoroutine(MoveManyStep(steps));
    //}
    public void Move()
    {
        PathPointHandler pathPointHandler = new PathPointHandler(currentPathPoint, gameObject);
        pathPointHandler.PlanPath();
        StartCoroutine(WaitUntilRespond(pathPointHandler));
    }
    public IEnumerator WaitUntilRespond(PathPointHandler handler)
    {
        yield return new WaitUntil(() => handler.Ready == true);
        currentPathPoint = handler.targetPoint;
        var movement = GetComponent<CharacterMovement>();
        movement.RegisterStoper();
        StartCoroutine(movement.MoveToLocation(currentPathPoint.transform.position));
    }
    protected virtual void OnMouseDown()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
        StartConmunicate();
    }
    protected virtual void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/{character.characterArtCode.ToString()}");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }

    public void SetInner(bool inner)
    {
        this.inner = inner;
    }
    public virtual void SetConversationDatabase()
    {
        //npcConversationTriggerGroup.Setup(character.characterArtCode.ToString());
        var pref = Resources.Load<NPCConversationTriggerGroup>($"{ReturnAssetPath.ReturnNPCConversationTriggerGroupPath(character.characterArtCode.ToString())}");
        npcConversationTriggerGroup = Instantiate<NPCConversationTriggerGroup>(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
        //GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
        //GetComponentInChildren<EventAfterConversation>().EnemyUnitACardList[0] =(character);
    }
}