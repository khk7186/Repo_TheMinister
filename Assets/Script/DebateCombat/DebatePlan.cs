using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebatePlan : MonoBehaviour
{
    public string ownerName = string.Empty;
    [Serializable]
    private struct Plan
    {
        [SerializeField]
        public List<string> planInfo;
    }
    [SerializeField]
    private List<Plan> PlanOrder = new List<Plan>();
    public int Index = -1;
    public List<string> NextPlan()
    {
        Index += 1;
        if (Index >= PlanOrder.Count) return null;
        return PlanOrder[Index].planInfo;
    }
}

