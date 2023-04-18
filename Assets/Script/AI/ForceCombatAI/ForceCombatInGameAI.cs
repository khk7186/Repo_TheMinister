using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using PixelCrushers.DialogueSystem;

public class ForceCombatInGameAI : DefaultInGameAI,IStopPlayer
{
    public int stayblock;
    public int stayRounds = 3;
    private Collider2D trigger; 
    public int CurrentBlock => stayblock;
    public PathPoint[] RoitPoints;
    public List<PathPoint> TakenPoints = new List<PathPoint>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(StartCombat());
        }
    }
    public IEnumerator StartCombat()
    {
        StartConmunicate();
        //var eventTrigger = npcConversationTriggerGroup.GetComponent<GeneralEventTrigger>();
        //eventTrigger.battleType = BattleType.Combat;
        //eventTrigger.TriggerEvent();
        yield return null;
    }
    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            stayRounds -= 1;
            if (stayRounds <= 0)
            {
                Destroy(this);
            }
        }
    }
    public override void Setup(Character character)
    {
        this.character = character;
        SetSpine();
        List<Vector3Int> targetGrid =MovementGrid.PlayerMovementBlocks;
        int playerBlock = FindObjectOfType<Player>().GetComponent<CharacterMovement>().currentBlock;
        stayblock = (playerBlock + Random.Range(10, 15)) % targetGrid.Count;
        transform.position = movementGrid.GetCellCenterWorld(targetGrid[stayblock]);
        SetConversationDatabase();
    }
    protected override void OnMouseDown()
    {
        GetComponent<EventAfterConversation>().TryHire();
    }
    public override void SetConversationDatabase()
    {
        //npcConversationTriggerGroup.Setup(character.characterArtCode.ToString());
        var pref = Resources.Load<NPCConversationTriggerGroup>($"{ReturnAssetPath.ReturnNPCConversationTriggerGroupPath("Ç¿µÁ")}");
        npcConversationTriggerGroup = Instantiate<NPCConversationTriggerGroup>(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
    }
    protected override void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/ÄÐµ¶¿Í");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }
}
