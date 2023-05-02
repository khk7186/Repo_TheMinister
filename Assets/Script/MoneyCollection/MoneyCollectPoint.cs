using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollectPoint : MonoBehaviour
{
    public static MoneyCollectManager manager => MoneyCollectManager.Instance;
    public int value = 100;
    public MCPStateCheckHandler StateChecker;
    public bool OnRoit => StateChecker.onRoit;
    public int Value
    {
        get
        {
            if (OnRoit)
            {
                return (int)(1f - manager.MoneyDecreaseOnRoit) * value;
            }
            return value;
        }
    }
    public string Name = "商行";
    public string State = "良好";
    public Collider2D Trigger;
    public GameObject Wrapper;
    public RoitSpawnRange RoitSpawnRange;
    public RoitSpawnRange[] EffectedRanges;
    public float EffectRoitSpawnRangeRadius = 7f;

    public Text text;
    public void Awake()
    {
        Wrapper.SetActive(false);
        StateChecker = new MCPStateCheckHandler(this);
    }
    private void Start()
    {
        DetectRoit();
    }
    public void OnContact()
    {
        string color = OnRoit ? "red" : "green";
        State = OnRoit ? "糟糕" : "良好";
        text.text = $"{Name}今日营业状态<color={color}>{State}</color>\r\n缴纳税银<color={color}>{Value}</color>两";
        Wrapper.SetActive(true);
        var handler = new MoneyCollectAnimationHandler(Wrapper.GetComponent<RectTransform>(), manager.YChange, manager.duration, manager.delay);
        handler.Play();
        if (Value > 0)
            CurrencyInvAnimationManager.Instance.MoneyChange(Value);
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, EffectRoitSpawnRangeRadius);
    }
    public void DetectRoit()
    {
        var list = Physics2D.OverlapCircleAll(transform.position, EffectRoitSpawnRangeRadius);
        EffectedRanges = list.Where(p => p.GetComponent<RoitSpawnRange>() != null).ToArray()
                                                            .Select(x => x.GetComponent<RoitSpawnRange>()).ToArray();
        StateChecker.ranges = EffectedRanges.ToList();
    }
}
