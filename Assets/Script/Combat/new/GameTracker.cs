using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker
{
    public bool gameWin = false;
    public int moneyRewards = 0;
    public int pressureRewards = 0;
    public List<ItemName> rewards = new List<ItemName>();

    private GameTracker(){}
    public static GameTracker NewGameTracker(int money, int pressureRewards, List<ItemName> rewards)
    {
        return new GameTracker() {
            moneyRewards = money,
            pressureRewards = pressureRewards,
            rewards = rewards};
    }
}
