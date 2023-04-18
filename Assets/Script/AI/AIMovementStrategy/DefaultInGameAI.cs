using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;
using UnityEditor.SearchService;

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
    Morning = 0,
    Noon = 1,
    Evening = 2,
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

        map = FindObjectOfType<Map>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Register();
            DontDestroyOnLoad(gameObject);
            SetLocation();
        }
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        Register();
    }
    private void Register()
    {
        if (Dice.Instance != null)
        {
            Dice.Instance.RegisterObserver(this);
        }
    }
    private void OnEnable()
    {
        //Debug.Log($"Register");
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Register();
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public virtual void OnNotify(object value, NotificationType notificationType)
    {
        Move();
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
        SetConversationDatabase();
    }

    public void SetLocation()
    {
        if (currentPathPoint == null)
        {
            var PM = PathManager.Instance;
            currentPathPoint = PathManager.OfferValidPoint();
            PM.takenPoints.Add(currentPathPoint);
        }
        transform.position = currentPathPoint.transform.position;
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
    public virtual void Move()
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