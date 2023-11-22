using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Spine.Unity;
using UnityEngine.Events;

public enum CharacterStat
{
    weak = 0,
    normal = 1,
    strong = 2,
}
public class CombatCharacterUnit : MonoBehaviour
{
    int order = 0;
    public Character character;
    public bool IsFriend = false;
    public int armor = 0;
    public static int minimumDamage = 1;
    public static Grid grid;

    public CharacterStat stat = CharacterStat.normal;
    public CombatAction currentAction = CombatAction.NoSelect;
    public CombatCharacterUnit target = null;
    public bool SelfDefending = false;
    private const int IsometricRangePerYUnit = 1;
    public CombatCharacterUnit Defender = null;
    SortingGroup sg = null;
    public HealthBar healthBar;
    public Vector3Int cellPosition;
    public CombatPlan plan = null;
    private void Awake()
    {
        if (grid == null)
        {
            grid = GameObject.FindGameObjectWithTag("MovementGrid").GetComponent<Grid>();
        }
        sg = GetComponent<SortingGroup>();
    }
    private void Start()
    {
        GetComponent<CharacterMovement>().enabled = true;
        if (!IsFriend)
        {

            var characterPlan = character.GetComponent<CombatPlan>();
            if (characterPlan != null)
            {
                this.plan = characterPlan;
            }
        }
    }

    public static CombatCharacterUnit NewCombatCharacterUnit(Character character, bool isFriend)
    {
        var pref = Resources.Load<CombatCharacterUnit>(ReturnAssetPath.ReturnCombatCharacterUnitPrefPath(character.characterArtCode.ToString()));
        var output = Instantiate(pref);
        output.character = character;
        output.IsFriend = isFriend;
        output.SetupIdle();
        output.Reset();
        if (!output.IsFriend)
        {
            Destroy(output.GetComponent<CombatInteractableUnit>());
        }
        return output;
    }
    public void Reset()
    {
        armor = 0;
        stat = CharacterStat.normal;
        currentAction = CombatAction.NoSelect;
        target = null;
        SelfDefending = false;
        Defender = null;
    }
    public void SetupIdle()
    {
        var sc = GetComponent<SideChanger>();
        if (!IsFriend)
        {
            if (sc != null)
            {
                Debug.Log("enemy");
                sc.changeSide(true, false);
            }
        }
        else
        {
            if (sc != null)
            {
                Debug.Log("player");
                sc.changeSide(false, true);
            }
        }
        healthBar = Instantiate(Resources.Load<HealthBar>("CombatScene/HealthBar"), MainCanvas.FindMainCanvas());
        healthBar.followCharacter = this.transform;
        healthBar.Setup(character.health);
    }

    public void SetGridPosition(Vector3Int cellPosition)
    {
        this.cellPosition = cellPosition;
        transform.position = grid.GetCellCenterWorld(cellPosition);
    }

    void Update()
    {
        SortingGroup sg = GetComponent<SortingGroup>();
        sg.sortingOrder = 20 - (int)(transform.position.y * IsometricRangePerYUnit);
    }
    public void ChooseTarget()
    {
        switch (currentAction)
        {
            default:
                break;
            case CombatAction.Attack:
            case CombatAction.Assassin:

                break;
            case CombatAction.Defence:
                break;
        }
    }
    IEnumerator TryGetTarget()
    {
        yield return null;
    }
    public void MakeTurn()
    {

        DoDamage();
    }
    public void ModifyStat()
    {
        CharacterStat NextStat = stat;
        switch (currentAction)
        {
            default:
                break;
            case CombatAction.Defence:
                if (SelfDefending)
                {
                    NextStat = CharacterStat.strong;
                }
                else
                {
                    NextStat = (CharacterStat)((((int)stat + 1) >= 2) ? 2 : ((int)stat + 1));
                }
                break;
            case CombatAction.Assassin:
                NextStat = (CharacterStat)((((int)stat - 1) <= 0) ? 0 : ((int)stat - 1));
                break;
        }
        stat = NextStat;
    }
    public void DoDefence()
    {

        if (target == this)
        {
            stat = CharacterStat.strong;
        }
        else
        {
            target.Defender = this;
        }
    }
    public void DoDamage()
    {
        if (character != null && target != null)
        {
            switch (currentAction)
            {
                default:
                    break;
                case CombatAction.Attack:
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.Œ‰]);
                    break;
                case CombatAction.Assassin:
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.Œ‰]);
                    break;
            }
        }
    }
    public void TakeDamge(int damage, bool asDefender = false)
    {
        string screenSakeType = "Attack";
        string audioName = " ‹…À";
        if (Defender == null || Defender.character.health <= 0 || asDefender == true)
        {
            int result = 0;
            switch (stat)
            {
                case CharacterStat.weak:
                    result = damage > 0 ? damage * 2 : minimumDamage * 2;
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.normal:
                    result = damage > 0 ? damage : minimumDamage;
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.strong:
                    var tempDmg = damage - character.CharactersValueDict[CharacterValueType. ÿ];
                    result = tempDmg > 0 ? damage : 0;
                    character.FightHealthModify(result);
                    audioName = "µ÷øπ";
                    break;
            }
            healthBar.Setup(character.health);
            if (result >= 5) screenSakeType = "HardAttack";
            if (character.health <= 0)
            {
                StartCoroutine(DeathAnimation());
            }
            else
            {
                StartCoroutine(DefenceAction(audioName, screenSakeType));
            }
        }
        else if (target != null)
        {
            Defender.TakeDamge(damage, true);
        }
    }
    public int TryArmor(int damage)
    {
        int result = armor - damage;
        if (result > 0)
        {
            armor = result;
            return 0;
        }
        else
        {
            armor = 0;
            return -result;
        }
    }
    public void NewTurn()
    {
        stat = CharacterStat.normal;
        target = null;
        Defender = null;
        currentAction = CombatAction.NoSelect;
    }
    public IEnumerator DefenceAction(string audioName, string screenSakeType)
    {
        yield return new WaitForSeconds(0.22f);
        GetComponent<CharacterModelController>().PlayAnimation("def");
        AudioManager.Play(audioName);
        ScreenShakeTrigger.TryScreenShake(screenSakeType);
    }
    public IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(0.22f);
        GetComponent<CharacterModelController>().PlayAnimation("dead");
        AudioManager.Play("À¿Õˆ");
        ScreenShakeTrigger.TryScreenShake("Death");
        yield return new WaitForSeconds(0.5f);
        DeathAction();
    }
    public void DeathAction()
    {

        if (IsFriend)
        {
            var trigger = FindObjectOfType<GeneralEventTrigger>();
            trigger.LostCharacters.Add(character);
        }
        DestroyHealthBar();
        if (character.hireStage != HireStage.Hired)
        {
            if (character.hireStage == HireStage.NotInMap)
            {
                Destroy(character.gameObject);
            }
            else
            {
                character.hireStage = HireStage.Defeated;
                character.health = 1;
                character.loyalty = 5;
                if (character.characterType == CharacterType.Roit)
                {
                    RegularQuestEventHandler.WinCombatMessage();
                    RoitInGameAI rc = character.InGameAI as RoitInGameAI;
                    rc.DeathAction();
                }
            }
        }
        CheckGameEnd();
        gameObject.SetActive(false);
    }
    public void SurrenderAction()
    {
        if (!IsFriend)
        {
            if (character.hireStage != HireStage.Hired)
            {
                if (character.hireStage == HireStage.NotInMap)
                {
                    Destroy(character.gameObject);
                }
                else
                {
                    character.hireStage = HireStage.Defeated;
                    character.loyalty = 5;
                    RegularQuestEventHandler.WinCombatMessage();
                }
            }
        }

        CheckGameEnd();
        gameObject.SetActive(false);
    }
    public void DestroyHealthBar()
    {
        Destroy(healthBar.gameObject);
    }

    public void CheckGameEnd()
    {
        int enemy = 0, player = 0;
        int result = 0;
        foreach (var ccu in FindObjectsOfType<CombatCharacterUnit>())
        {
            if (ccu == this) continue;
            if (ccu.IsFriend) player++;
            else enemy++;
        }
        var trigger = FindObjectOfType<GeneralEventTrigger>();
        if (enemy == 0)
        {
            result = 1;
        }
        else if (player == 0)
        {
            result = -1;
        }
        if (result != 0)
        {
            var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
            if (result == 1)
            {
                endCtrl.Win();
            }
            else
            {
                endCtrl.Lose();
            }
        }
    }

}
