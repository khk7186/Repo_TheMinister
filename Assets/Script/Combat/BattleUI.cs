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

    public BattleCharacterHeadUI PlayerCurrentCharacter;
    public BattleCharacterHeadUI EnemyCurrentCharacter;

    public Transform InfoBoard;
    public Text ScoreBoard;

    public Transform AbilityList;

    public BattleSelectedCharacterUI playerSideImage;
    public BattleSelectedCharacterUI enemySideImage;

    public BattleType battleType;
    //Buttons 
    public Transform Attak;
    public Transform Defence;
    public Transform Assassinate;
    public Transform Surrender;
    public Transform Confirm;
    public void Setup(List<Character> playerList, List<Character> enemyList, BattleType battleType)
    {
        //TODO: foreach character spawn new headui.
        PlayerCh1.Setup(playerList[0], battleType, transform, true);
        PlayerCh2.Setup(playerList[1], battleType, transform, true);
        PlayerCh3.Setup(playerList[2], battleType, transform, true);
        EnemyCh1.Setup(playerList[0], battleType, transform, false);
        EnemyCh2.Setup(playerList[1], battleType, transform, false);
        EnemyCh3.Setup(playerList[2], battleType, transform, false);
        this.battleType = battleType;
        if (PlayerCurrentCharacter == null)
        {
            SelectCurrentCharacter(PlayerCh1);
        }
    }
    public void SelectCurrentCharacter(BattleCharacterHeadUI target)
    {
        if (target.IsPlayer)
        {
            characterSwitch(PlayerCh1, target);
            characterSwitch(PlayerCh2, target);
            characterSwitch(PlayerCh3, target);
            playerSideImage.Setup(target.character,battleType);
        }
        else
        {
            characterSwitch(EnemyCh1, target);
            characterSwitch(EnemyCh2, target);
            characterSwitch(EnemyCh3, target);
            enemySideImage.Setup(target.character,battleType);
        }
    }
    public void characterSwitch(BattleCharacterHeadUI subject, BattleCharacterHeadUI compare)
    {
        bool result = (subject == compare);
        subject.SelectThis(result);
        if (result == true)
        {
            if (subject.IsPlayer) PlayerCurrentCharacter = subject;
            else EnemyCurrentCharacter = subject;
        }
    }

#if UNITY_EDITOR
    private void Start()
    {
    }
#endif
}
