using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCPStateCheckHandler
{
    public MoneyCollectPoint MCP;
    public List<RoitSpawnRange> ranges = new List<RoitSpawnRange>();
    public bool onRoit
    {
        get
        {
            if (ranges == null || ranges.Count <=0) return false;
            foreach (RoitSpawnRange range in ranges)
            {
                if (range.onRoit) return true;
            }
            return false;
        }
    }
    public MCPStateCheckHandler(MoneyCollectPoint MCP)
    {
        this.MCP = MCP;
    }
}
