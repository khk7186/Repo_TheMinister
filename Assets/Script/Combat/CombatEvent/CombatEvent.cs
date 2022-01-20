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
            target.StateAction();
        }
    }

    private List<Character> EnemyTest()
    {
        Character character = Resources.Load<Character>("CharacterPrefab/Character");
        var targetList = new List<Character>();
        targetList.Add(Instantiate(character));
        targetList.Add(Instantiate(character));
        targetList.Add(Instantiate(character));
        return targetList;
    }
}
