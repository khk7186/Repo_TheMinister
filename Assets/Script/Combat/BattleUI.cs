using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour
{
    public BattleCharacterHeadUI PlayerCh1;
    public BattleCharacterHeadUI PlayerCh2;
    public BattleCharacterHeadUI PlayerCh3;
    public BattleCharacterHeadUI EnemyCh1;
    public BattleCharacterHeadUI EnemyCh2;
    public BattleCharacterHeadUI EnemyCh3;

    public Transform InfoBoard;
    public Text ScoreBoard;

    public Transform AbilityList;

    //Buttons 
    public Transform Attak;
    public Transform Defence;
    public Transform Assassinate;
    public Transform Surrender;
    public Transform Confirm;

    public void Setup(List<Character> playerList, List<Character> enemyList , BattleType battleType)
    {
        PlayerCh1.Setup(playerList[0], battleType);
        PlayerCh2.Setup(playerList[1], battleType);
        PlayerCh3.Setup(playerList[2], battleType);
        EnemyCh1.Setup(playerList[0], battleType);
        EnemyCh2.Setup(playerList[1], battleType);
        EnemyCh3.Setup(playerList[2], battleType);
    }
    public void SetUp(BattleCharacterHeadUI headUI, bool IsPlayer)
    {
        if (IsPlayer)
        {
            if (headUI != PlayerCh1) PlayerCh1.SelectThis(false);
            if (headUI != PlayerCh2) PlayerCh2.SelectThis(false);
            if (headUI != PlayerCh3) PlayerCh3.SelectThis(false);
        }
    }

    public static void SwitchCharacter()
    {
        FindObjectOfType<BattleUI>();
    }
}
