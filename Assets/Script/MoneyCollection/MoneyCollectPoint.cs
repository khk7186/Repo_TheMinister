using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollectPoint : MonoBehaviour
{
    public int Value = 100;
    public string Name = "商行";
    public string State = "良好";
    public bool OnRoit = false;
    public Collider2D Trigger;
    public GameObject Wrapper;
    public RoitSpawnRange RoitSpawnRange;
    public static MoneyCollectManager manager => MoneyCollectManager.Instance;

    public Text text;
    public void Start()
    {
        Wrapper.SetActive(false);
    }
    public void OnContact()
    {
        if (RoitSpawnRange != null) 
            State = RoitSpawnRange.onRoit ? "糟糕" : "良好";
        text.text = $"{Name}今日营业状态{State}\r\n缴纳税银<color=green>{Value}</color>两";
        Wrapper.SetActive(true);
        var handler = new MoneyCollectAnimationHandler(Wrapper.GetComponent<RectTransform>(), manager.YChange, manager.duration, manager.delay);
        handler.Play();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1);
    }


}
