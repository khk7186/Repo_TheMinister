using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HorseCardUI : MonoBehaviour, IPointerClickHandler, ISubject
{
    [SerializeField] private Text priceText;
    [SerializeField] private Text blocksText;
    [SerializeField] private Image horseImage;

    public ConfirmPhase confirm = ConfirmPhase.Null;
    private IObserver Map;

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
        string currentText = "确认要花费" + price + "两白银移动" + block + "户距离吗？";
        Confirmation.HoldingMethod holding = MovePlayer;
        RegisterObserver(FindObjectOfType<Map>());
        StartCoroutine(Confirmation.CreateNewComfirmation(holding, currentText).Confirm());
    }
    private void MovePlayer()
    {
        Notify(block, NotificationType.MovePlayer);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseHorse();
    }

    public void RegisterObserver(IObserver observer)
    {
        Map = observer;
    }

    public void Notify(object value, NotificationType notificationType)
    {
        Map.OnNotify(value, notificationType);
    }
}
