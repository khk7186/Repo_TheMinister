using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGrid : MonoBehaviour
{
    public static List<Vector3Int> PlayerMovementBlocks = new List<Vector3Int>();
    public static List<Vector3Int> EnemyInnerMovementBlocks = new List<Vector3Int>();
    public static List<Vector3Int> EnemyOutterMovementBlocks = new List<Vector3Int>();
    public static Dictionary<int, bool[]> EnemyStandBlockDict = new Dictionary<int, bool[]>();

    public static Vector3Int GetPlayerBlock(int blockNumber)
    {
        Vector3Int block = Vector3Int.zero;
        if (blockNumber >= 0)
        {
            block = PlayerMovementBlocks[blockNumber];
        }
        return block;
    }
    public static Vector3Int GetAIBlock(DefaultInGameAI gameAI, int blockNumber)
    {
        if (EnemyStandBlockDict.TryGetValue(gameAI.CurrentLocation, out bool[] value))
        {
            int careValue = gameAI.inner ? 0 : 1;
            value[careValue] = false;
            careValue = gameAI.inner ? 1 : 0;
            if (value[careValue] == false)
            {
                EnemyStandBlockDict.Remove(gameAI.CurrentLocation);
            }
        }
        Vector3Int result = CheckAIBlock(gameAI, blockNumber);
        return result;
    }
    public static Vector3Int CheckAIBlock(DefaultInGameAI gameAI, int blockNumber)
    {
        Vector3Int block = Vector3Int.zero;
        bool[] OnBlockStat;
        if (EnemyStandBlockDict.TryGetValue(blockNumber, out OnBlockStat))
        {
            if (gameAI != null)
            {
                List<Vector3Int> targetpath = gameAI.inner ? EnemyInnerMovementBlocks : EnemyOutterMovementBlocks;
                int carevalue = gameAI.inner ? 0 : 1;
                //if current path not available
                if (OnBlockStat[carevalue])
                {
                    // if other path not available do next path index
                    if (OnBlockStat[gameAI.inner ? 1 : 0])
                    {
                        block = CheckAIBlock(gameAI, blockNumber + 1);
                    }
                    // if other path available
                    else
                    {
                        block = targetpath[blockNumber];
                        OnBlockStat[gameAI.inner ? 1 : 0] = true;
                        gameAI.SetInner(!gameAI.inner);
                        EnemyStandBlockDict[blockNumber] = OnBlockStat;
                    }
                }
                //if current path available
                else
                {
                    block = targetpath[blockNumber];
                    OnBlockStat[carevalue] = true;
                    EnemyStandBlockDict[blockNumber] = OnBlockStat;
                }
            }
        }
        else
        {
            bool inner = Random.Range(0f, 10f) > 5f;
            gameAI.SetInner(inner);
            block = inner ? EnemyInnerMovementBlocks[blockNumber] : EnemyOutterMovementBlocks[blockNumber];
            OnBlockStat = new bool[2] { false, false };
            OnBlockStat[inner ? 0 : 1] = true;
            EnemyStandBlockDict.Add(blockNumber, OnBlockStat);
        }
        return block;
    }
    


}
