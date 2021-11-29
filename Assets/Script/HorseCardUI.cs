using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HorseCardUI : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Text priceText;
    [SerializeField] private Text blocksText;
    [SerializeField] private Image horseImage;
    [SerializeField] private Confirm ConfirmWindow;

    public ConfirmPhase confirm = ConfirmPhase.Null;

    public static Dictionary<HorseRank, List<int>> HorseKindDict =
        new Dictionary<HorseRank, List<int>>()
        {
            { HorseRank.N, new List<int>(){1, 1 } },
            { HorseRank.R, new List<int>(){2, 2 } },
            { HorseRank.SR, new List<int>(){3, 3 } },
            { HorseRank.SSR, new List<int>(){4, 4 } },
            { HorseRank.UR, new List<int>(){5, 5 } },
        };
    public int price;
    public int block;
    
    public void SetUp(HorseRank horseRank)
    {
        string spritePath = ("Art/Horses/" + horseRank.ToString()).Replace(" ", string.Empty);
        Debug.Log(spritePath);
        horseImage.sprite = Resources.Load<Sprite>(spritePath);
        price = HorseKindDict[horseRank][0];
        block = HorseKindDict[horseRank][1];
        priceText.text = price + "两";
        blocksText.text = block + "户";
    }

    public void ChooseHorse()
    {
        var current = Instantiate(ConfirmWindow, FindObjectOfType<BuildingUI>().transform);
        current.SetUp("确认要花费" + price + "两白银移动" + block + "户距离吗？");
        current.confirm.onClick.AddListener(SetConfirmTrue);
        current.cancel.onClick.AddListener(SetConfirmFalse);
        StartCoroutine(Confirm());
    }

    private void SetConfirmTrue()
    {
        confirm = ConfirmPhase.True;
    }

    private void SetConfirmFalse()
    {
        confirm = ConfirmPhase.False;
    }

    private IEnumerator Confirm()
    {
        while (confirm == ConfirmPhase.Null)
        {
            yield return null;
        }
        if (confirm == ConfirmPhase.False)
        {
            confirm = ConfirmPhase.Null;
        }
        else if (confirm == ConfirmPhase.True)
        {
            MovePlayer();
            Destroy(FindObjectOfType<BuildingUI>().gameObject);
        }
    }

    private void MovePlayer()
    {
        Map map = FindObjectOfType<Map>();
        map.MoveAStep(block);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseHorse();
    }
}
