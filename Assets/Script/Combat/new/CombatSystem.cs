using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatSystem
{
    Queue CombatQueue = new Queue();
    public static CombatSystem NewCombatSystem()
    {
        var combat = new CombatSystem();
        var allCCUinGame = GameObject.FindObjectsOfType<CombatCharacterUnit>().ToList();
        combat.MakeQueue(allCCUinGame);
        return new CombatSystem();
    }
    public void MakeQueue(List<CombatCharacterUnit> ccus)
    {
        
        foreach (CombatCharacterUnit ccu in ccus)
        {
            if (CombatQueue.Count != 0)
            {
                CombatQueue.Enqueue(ccu);
            }   
        }
    }

    public void InsertIntoCombatQueue(CombatCharacterUnit ccu)
    {
        Action ccuAction = ccu.currentAction;
        int speed = ccu.character.CharactersValueDict[CharacterValueType.´Ì];
        for (int i = 0; i < CombatQueue.Count; i++)
        {
            //if (ccuAction > )
        }
    }
}
