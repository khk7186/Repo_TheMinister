using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGrid : MonoBehaviour
{
    public static List<Vector3Int> PlayerMovementBlocks = new List<Vector3Int>()
        {
            new Vector3Int(95,52,0),
            new Vector3Int(95,47,0),
            new Vector3Int(95,42,0),
            new Vector3Int(95,37,0),
            new Vector3Int(95,32,0),
            new Vector3Int(95,27,0),
            new Vector3Int(95,17,0),
            new Vector3Int(95,12,0),
            new Vector3Int(95,7,0),
            new Vector3Int(95,2,0),
            new Vector3Int(95,-3,0),
            new Vector3Int(95,-8,0),
            new Vector3Int(95,-13,0),
            new Vector3Int(95,-18,0),
            new Vector3Int(95,-23,0),
            new Vector3Int(95,-28,0),
            new Vector3Int(95,-33,0),
            new Vector3Int(98,-35,0),
            new Vector3Int(102,-35,0),
            new Vector3Int(107,-35,0),
            new Vector3Int(112,-35,0),
            new Vector3Int(122,-35,0),
            new Vector3Int(127,-35,0),
            new Vector3Int(133,-35,0),
            new Vector3Int(142,-35,0),
            new Vector3Int(145,-32,0),
            new Vector3Int(145,-23,0),
            new Vector3Int(145,-21,0),
            new Vector3Int(148,-21,0),
            new Vector3Int(153,-21,0),
            new Vector3Int(156,-21,0),
            new Vector3Int(160,-17,0),
            new Vector3Int(160,-13,0),
            new Vector3Int(160,-7,0),
            new Vector3Int(160,-3,0),
            new Vector3Int(160,3,0),
            new Vector3Int(162,8,0),
            new Vector3Int(162,15,0),
            new Vector3Int(168,15,0),
            new Vector3Int(169,18,0),
            new Vector3Int(169,27,0),
            new Vector3Int(169,32,0),
            new Vector3Int(169,36,0),
            new Vector3Int(167,40,0),
            new Vector3Int(162,40,0),
            new Vector3Int(160,42,0),
            new Vector3Int(160,47,0),
            new Vector3Int(160,52,0),
            new Vector3Int(160,57,0),
            new Vector3Int(157,59,0),
            new Vector3Int(152,59,0),
            new Vector3Int(148,59,0),
            new Vector3Int(147,64,0),
            new Vector3Int(142,64,0),
            new Vector3Int(141,69,0),
            new Vector3Int(137,69,0),
            new Vector3Int(132,65,0),
            new Vector3Int(127,65,0),
            new Vector3Int(121,59,0),
            new Vector3Int(117,59,0),
            new Vector3Int(137,59,0),
            new Vector3Int(112,59,0),
            new Vector3Int(107,59,0),
            new Vector3Int(102,59,0),
            new Vector3Int(97,59,0),
            new Vector3Int(94,56,0),
        };
    public static List<Vector3Int> EnemyInnerMovementBlocks = new List<Vector3Int>() 
        {
            new Vector3Int(92,52,0),
            new Vector3Int(98,52,0),
            new Vector3Int(92,50,0),
            new Vector3Int(98,50,0),
            new Vector3Int(98,47,0),
            new Vector3Int(91,47,0),
            new Vector3Int(91,44,0),
            new Vector3Int(98,44,0),
            new Vector3Int(98,40,0),
            new Vector3Int(91,40,0),
            new Vector3Int(92,36,0),
            new Vector3Int(99,36,0),
            new Vector3Int(91,32,0),
            new Vector3Int(98,32,0),
            new Vector3Int(98,28,0),
            new Vector3Int(92,28,0),
            new Vector3Int(98,23,0),
            new Vector3Int(92,23,0),
            new Vector3Int(92,19,0),
            new Vector3Int(98,19,0),
            new Vector3Int(98,14,0),
            new Vector3Int(92,14,0),
            new Vector3Int(92,9,0),
            new Vector3Int(98,9,0),
            new Vector3Int(92,4,0),
            new Vector3Int(98,4,0),
            new Vector3Int(92,0,0),
            new Vector3Int(98,0,0),
            new Vector3Int(92,-5,0),
            new Vector3Int(98,-5,0),
            new Vector3Int(92,-10,0),
            new Vector3Int(98,-10,0),
            new Vector3Int(92,-15,0),
            new Vector3Int(98,-15,0),
            new Vector3Int(92,-20,0),
            new Vector3Int(98,-20,0),
            new Vector3Int(92,-25,0),
            new Vector3Int(98,-25,0),
            new Vector3Int(92,-30,0),
            new Vector3Int(98,-30,0),
            new Vector3Int(98,-33,0),
            new Vector3Int(92,-35,0),
            new Vector3Int(92,-40,0),
            new Vector3Int(97,-40,0),
            new Vector3Int(103,-40,0),
            new Vector3Int(103,-33,0),
            new Vector3Int(108,-33,0),
            new Vector3Int(108,-40,0),
            new Vector3Int(113,-33,0),
            new Vector3Int(113,-40,0),
            new Vector3Int(118,-33,0),
            new Vector3Int(118,-40,0),
            new Vector3Int(123,-33,0),
            new Vector3Int(123,-40,0),
            new Vector3Int(128,-33,0),
            new Vector3Int(128,-40,0),
            new Vector3Int(133,-40,0),
            new Vector3Int(133,-33,0),
            new Vector3Int(139,-33,0),
            new Vector3Int(139,-40,0),
            new Vector3Int(148,-33,0),
            new Vector3Int(148,-28,0),
            new Vector3Int(141,-28,0),
            new Vector3Int(141,-23,0),
            new Vector3Int(149,-23,0),
            new Vector3Int(154,-23,0),
            new Vector3Int(154,-18,0),
            new Vector3Int(156,-14,0),
            new Vector3Int(163,-14,0),
            new Vector3Int(156,-10,0),
            new Vector3Int(163,-10,0),
            new Vector3Int(163,-4,0),
            new Vector3Int(156,-4,0),
            new Vector3Int(156,1,0),
            new Vector3Int(163,1,0),
            new Vector3Int(163,6,0),
            new Vector3Int(156,6,0),
            new Vector3Int(163,11,0),
            new Vector3Int(156,11,0),
            new Vector3Int(156,16,0),
            new Vector3Int(166,19,0),
            new Vector3Int(168,11,0),
            new Vector3Int(173,19,0),
            new Vector3Int(173,24,0),
            new Vector3Int(166,24,0),
            new Vector3Int(166,30,0),
            new Vector3Int(173,30,0),
            new Vector3Int(167,35,0),
            new Vector3Int(173,35,0),
            new Vector3Int(173,42,0),
            new Vector3Int(167,36,0),
            new Vector3Int(167,43,0),
            new Vector3Int(163,43,0),
            new Vector3Int(163,37,0),
            new Vector3Int(157,37,0),
            new Vector3Int(163,63,0),
            new Vector3Int(156,44,0),
            new Vector3Int(163,44,0),
            new Vector3Int(156,48,0),
            new Vector3Int(163,48,0),
            new Vector3Int(163,53,0),
            new Vector3Int(156,53,0),
            new Vector3Int(163,57,0),
            new Vector3Int(156,57,0),
            new Vector3Int(153,57,0),
            new Vector3Int(153,63,0),
            new Vector3Int(145,60,0),
            new Vector3Int(149,64,0),
            new Vector3Int(140,65,0),
            new Vector3Int(144,69,0),
            new Vector3Int(138,74,0),
            new Vector3Int(137,66,0),
            new Vector3Int(132,61,0),
            new Vector3Int(132,69,0),
            new Vector3Int(128,60,0),
            new Vector3Int(128,68,0),
            new Vector3Int(124,58,0),
            new Vector3Int(124,64,0),
            new Vector3Int(120,63,0),
            new Vector3Int(120,56,0),
            new Vector3Int(115,56,0),
            new Vector3Int(115,63,0),

        };
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
