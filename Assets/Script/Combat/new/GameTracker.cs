using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker
{
    public bool gameWin = false;
    public int moneyRewards = 0;
    public int influenceRewards = 0;
    public int prestigeRewards = 0;
    public List<ItemName> rewards = new List<ItemName>();

    private GameTracker(){}
    public static GameTracker NewGameTracker(int money, int influence, int prestige, List<ItemName> rewards)
    {
        return new GameTracker() {
            moneyRewards = money,
            influenceRewards = influence,
            prestigeRewards = prestige,
            rewards = rewards};
    }
}
