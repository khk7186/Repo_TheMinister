using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;
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
    public int CurrentLocation;
    public int NextBlockToMove;
    public int TargetLocation;
    public Character character;
    public NPCPopUI npcPopUI;
    //private string NPCJsonPath = "JSON/AIOnMapMovement";
    public Grid movementGrid;
    public NPCConversationTriggerGroup npcConversationTriggerGroup;
    protected bool NotClickable = false;
    public bool Deserializing = false;

    protected void Awake()
    {
        map = FindObjectOfType<Map>();
        GetComponent<Collider2D>().enabled = false;
        //CapsuleCollider2D
    }
    private void Start()
    {
        StartAction();

        GetComponent<Collider2D>().enabled = true;
    }
    public virtual void StartAction()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().name == "SampleScene 1")
        {
            Register();
            if (Deserializing) return;
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
        //if (character != null)
        //{
        //    if (character.hireStage == HireStage.Defeated)
        //    {
        //        GetComponent<CharacterMovement>().ModelDieAnimation();
        //    }
        //}
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        StopAllCoroutines();
    }
    public virtual void OnNotify(object value, NotificationType notificationType)
    {
        if (InGameCharacterStorage.Instance.OffForTheme) return;
        Move();
    }
    public virtual void Setup(Character character)
    {
        this.character = character;
        SetConversationDatabase();
    }
    public virtual void SetLocation()
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
        //NotClickable = true;
        yield return new WaitUntil(() => handler.Ready == true);
        currentPathPoint = handler.targetPoint;
        var movement = GetComponent<CharacterMovement>();
        movement.RegisterStoper();
        yield return StartCoroutine(movement.MoveToLocation(currentPathPoint.transform.position));
        //NotClickable = false;
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

    public virtual void SetConversationDatabase()
    {
        //npcConversationTriggerGroup.Setup(character.characterArtCode.ToString());
        var pref = Resources.Load<NPCConversationTriggerGroup>($"{ReturnAssetPath.ReturnNPCConversationTriggerGroupPath(character.characterArtCode.ToString())}");
        npcConversationTriggerGroup = Instantiate<NPCConversationTriggerGroup>(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
        //GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
        //GetComponentInChildren<EventAfterConversation>().EnemyUnitACardList[0] =(character);
    }
    public virtual void PlayDeathAnimation()
    {
        var characterMovement = GetComponent<CharacterMovement>();
        var model = characterMovement.modelController;
        model.SetTrigger("Death");
        Destroy(character.gameObject.gameObject);
        StartCoroutine(Clean());
    }
    IEnumerator Clean()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}