using System.Collections.Generic;
public interface IAICombatStrategy
{
    public void MakeDecision(Dictionary<Action, int> targetDic);
}
