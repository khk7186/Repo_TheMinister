using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Spine.Unity;
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
    static Grid grid;

    public CharacterStat stat = CharacterStat.normal;
    public Action currentAction = Action.Attack;
    public CombatCharacterUnit target = null;
    public bool SelfDefending = false;
    private const int IsometricRangePerYUnit = 1;
    public CombatCharacterUnit Defender = null;
    SortingGroup sg = null;

    private void Awake()
    {
        if (character == null)
        {
            character = GetComponent<Character>();
        }
        if (grid == null)
        {
            grid = GameObject.FindGameObjectWithTag("MovementGrid").GetComponent<Grid>();
        }
        sg = GetComponent<SortingGroup>();
    }

    public static CombatCharacterUnit NewCombatCharacterUnit(Character character, bool isFriend)
    {
        var pref = Resources.Load<CombatCharacterUnit>(ReturnAssetPath.ReturnCombatCharacterUnitPrefPath());
        var output = Instantiate(pref);
        output.character = character;
        output.IsFriend = isFriend;
        output.SetupIdle();
        output.Reset();
        return output;
    }
    public void Reset()
    {
        armor = 0;
        stat = CharacterStat.normal;
        currentAction = Action.NoSelect;
        target = null;
        SelfDefending = false;
        Defender = null;
    }
    public void SetupIdle()
    {
        SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
            (ReturnAssetPath.ReturnSpineAssetPath(character.characterArtCode, !IsFriend));
        GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
        RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>
            (ReturnAssetPath.ReturnSpineControllerPath(character.characterArtCode, !IsFriend));
        GetComponent<Animator>().runtimeAnimatorController = controller;
        GetComponent<SkeletonMecanim>().Initialize(true);
        if (!IsFriend)
        {
            var newScale = transform.localScale;
            newScale = new Vector3(-newScale.x, newScale.y, newScale.z);
            transform.localScale = newScale;
        }
    }

    public void SetGridPosition(Vector3Int cellPosition)
    {
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
            case Action.Attack:
            case Action.Assassinate:

                break;
            case Action.Defence:
                break;
        }
    }
    IEnumerator TryGetTarget()
    {
        yield return null;
    }
    public void MakeTurn()
    {
        ModifyStat();
        DoDamage();
    }
    public void ModifyStat()
    {
        CharacterStat NextStat = stat;
        switch (currentAction)
        {
            default:
                break;
            case Action.Defence:
                if (SelfDefending)
                {
                    NextStat = CharacterStat.strong;
                }
                else
                {
                    NextStat = (CharacterStat)((((int)stat + 1) >= 2) ? 2 : ((int)stat + 1));

                }
                break;
            case Action.Assassinate:
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
                case Action.Attack:
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.Îä]);
                    break;
                case Action.Assassinate:
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.Îä]);
                    break;
            }
        }
    }
    public void TakeDamge(int damage, bool asDefender = false)
    {
        if (Defender == null || asDefender == true)
        {
            int result;
            switch (stat)
            {
                case CharacterStat.weak:
                    result = TryArmor(damage > 0 ? damage * 2 : minimumDamage * 2);
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.normal:
                    result = TryArmor(damage > 0 ? damage : minimumDamage);
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.strong:
                    result = TryArmor(damage > 0 ? damage / 2 : minimumDamage);
                    character.FightHealthModify(result);
                    break;
            }
            if (character.health <= 0)
            {
                DeathAction();
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
        currentAction = Action.NoSelect;
    }
    public void DeathAction()
    {
        if (IsFriend)
        {
            var trigger = FindObjectOfType<GeneralEventTrigger>();
            trigger.LostCharacters.Add(character);
        }
        gameObject.SetActive(false);
        CheckGameEnd();
    }

    public void CheckGameEnd()
    {
        int enemy = 0, player = 0;
        foreach (var ccu in FindObjectsOfType<CombatCharacterUnit>())
        {
            if (ccu.IsFriend) player++;
            else enemy++;
        }
        var trigger = FindObjectOfType<GeneralEventTrigger>();
        if (enemy == 0)
        {
            trigger.gameTracker.gameWin = true;
        }
        else if (player == 0)
        {
            trigger.gameTracker.gameWin = false;
        }
        Debug.Log(enemy);
        trigger.TiggerEnd();
    }
}
