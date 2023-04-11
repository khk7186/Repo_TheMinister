using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System.Linq;
using Spine.Unity;
using UnityEngine.SceneManagement;
using System;

public class Map : MonoBehaviour, IDiceRollEvent
{
    public static Map Instance;
    public float Radius = 1.5f;
    public int DayTime = 0;
    public int Day = 0;
    public Grid movementGrid;
    public int mapCount => MovementGrid.EnemyInnerMovementBlocks.Count;
    private int PlayerNextBlockToMove = 0;
    [SerializeField] private int PlayerCurrentBlock = 0;
    [SerializeField] private Transform Player;
    [SerializeField] private float delayPerMove = 1f;
    [SerializeField]
    private List<Building> ActivatedBuildings = new List<Building>();
    public bool GameStart = false;
    private bool OnMove => PlayerNextBlockToMove != PlayerCurrentBlock;

    public float duration = 10f;
    public int HorseMovementBuff = 1;

    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private static CharacterMovement PlayerMovement;
    public bool OnStory = false;
    private void Awake()
    {
        FindPlayer();
        if (Instance != null && Instance != this)
        {
            Dice.Instance.CancelObserver(this);
            Destroy(gameObject);
            return;
        }
        int block = PlayerMovement.currentBlock % MovementGrid.PlayerMovementBlocks.Count;
        Player.position = movementGrid.GetCellCenterWorld(MovementGrid.PlayerMovementBlocks[block]);
        PlayerNextBlockToMove = PlayerCurrentBlock;
        SetBuildings();
    }
    private void Start()
    {
        FirstDayReset();
        Dice.Instance.RegisterObserver(Instance);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SetBuildings();
        }
    }

    private void OnEnable()
    {
        if (Instance!= this) { Instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    private void FindPlayer()
    {
        Player = FindObjectOfType<Player>()?.transform;
        if (Player == null)
        {
            Player = Instantiate(Resources.Load<GameObject>("MainGame/李袁陌")).transform; PlayerAnimator = Player.GetComponentInChildren<SkeletonMecanim>().GetComponent<Animator>();
            PlayerMovement = Player.GetComponent<CharacterMovement>();
            PlayerMovement.currentBlock = PlayerCurrentBlock;
            PlayerMovement.finalBlock = PlayerCurrentBlock;
        }
        if (PlayerMovement == null)
        {
            PlayerMovement = Player.GetComponent<CharacterMovement>();
        }
    }
    public void FirstDayReset()
    {
        FindObjectOfType<CharacterSpawnPool>().RotateAllCharacters();
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            //PlayerAnimator.SetTrigger("Move");
            DayTimePlus();
            if (OnStory)
            {
                if (PlayerMovement.currentBlock>= PlayerMovement.finalBlock)
                {
                    OnStory = false;
                }
            }
            if (!OnStory)
            {
                PlayerMovement.finalBlock += (int)value * HorseMovementBuff;
            }
            StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        AudioManager.Play("走路", true);
        yield return PlayerMovement.MoveToLocationOld();
        AudioManager.Stop("走路");
        FindObjectOfType<Dice>().rolling = false;
        SetBuildings();
        HorseMovementBuff = 1;
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
        if (PlayerNextBlockToMove + 1 >= MovementGrid.PlayerMovementBlocks.Count)
        {
            PlayerNextBlockToMove = -1;
        }
        PlayerNextBlockToMove += 1;
        var targetPosition = movementGrid.GetCellCenterWorld(MovementGrid.GetPlayerBlock(PlayerNextBlockToMove));
        var startPosition = character.position;
        float time = 0;
        while (time < duration)
        {
            character.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
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
            if (b == null) { continue; }
            b.GetComponent<InteractAsset>().Active = activate;
        }
    }
    public void SetBuildings()
    {
        SetActivateBuildingsInteracteble(ActivatedBuildings, false);
        ActivatedBuildings.Clear();
        var list = InteractebleBuildingCheck();
        SetActivateBuildingsInteracteble(list, true);
        ActivatedBuildings = list;
    }

    //@param doFront
    //@param doLeft
    public void ChangeSide(bool doFront, bool doLeft)
    {
        PlayerAnimator.SetTrigger("Stop");
        string side = doFront ? "Front" : "Back";
        string SDApath = $"{ReturnAssetPath.ReturnMainCharacterAssetPath(doFront)}李袁陌_{side}_SkeletonData";
        string controllerPath = $"{ReturnAssetPath.ReturnMainCharacterAssetPath(doFront)}李袁陌_{side}_Controller";
        PlayerAnimator.GetComponent<SkeletonMecanim>().skeletonDataAsset = Resources.Load<SkeletonDataAsset>(SDApath);
        PlayerAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
        Vector3 target = PlayerAnimator.transform.localScale;
        target = new Vector3((doLeft ? 0.7f : -0.7f), target.y, target.z);
        PlayerAnimator.transform.localScale = target;
        PlayerAnimator.GetComponent<SkeletonMecanim>().Initialize(true);
        PlayerAnimator.SetTrigger(PlayerMovement.isMoving ? "Move" : "Stop");

    }
}
