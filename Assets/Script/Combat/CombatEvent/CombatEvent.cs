using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CombatEvent : MonoBehaviour
{
    public BattleSystem battleSystemPref;
    private void OnMouseDown()
    {
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            var target = Instantiate(battleSystemPref);
            target.PlayerCharacters = SelectOnDuty.GetOndutyAll();
            target.EnemyCharacters = EnemyTest();
            target.battleAI = AITest();
            target.StateAction();
        }
    }
    private List<Character> EnemyTest()
    {
        Character character = Resources.Load<Character>("CharacterPrefab/Character");
        var targetList = new List<Character>();
        for (int i = 0; i <3; i++)
        {
            var target = Instantiate(character);
            targetList.Add(target);
            DontDestroyOnLoad(target);
        }
        return targetList;
    }

    private BaseBattleAI AITest()
    {
        return new BaseBattleAI();
    }
}
