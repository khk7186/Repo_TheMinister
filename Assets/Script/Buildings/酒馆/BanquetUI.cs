using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BanquetUI : MonoBehaviour
{
    public Transform Content;
    public Button Confirm;
    public BanquetCharacterUI Temp;
    public RectTransform MoveableWindow;
    public int MaxPersonHere = 2;
    private Building building;
    public int Cost = 100;
    public Text CostMessage;
    private List<Character> characters = new List<Character>();

    public void Awake()
    {
        Confirm.onClick.AddListener(AddPersonHere);
        Temp.gameObject.SetActive(false);
    }
    public void Setup(Building building)
    {
        this.building = building;
        CostMessage.text = Cost.ToString();
        //GetComponent<Animator>().enabled = false;
        MoveableWindow.anchoredPosition = new Vector2(MoveableWindow.anchoredPosition.x, 0);
    }
    public void AddPersonHere()
    {
        CurrencyInventory inventory = FindObjectOfType<CurrencyInventory>();
        if (inventory.Money < Cost)
        {
            var message = Instantiate(Resources.Load<RiseUpTextAnimation>("Hiring/Message"));
            message.GetComponent<Text>().text = "你需要更多的银两";
            return;
        }
        Sequence sequence = DOTween.Sequence().Append(MoveableWindow.DOAnchorPosY(400f, 0.3f).OnComplete(() => Debug.Log("moved")));
        sequence.Play();
        CurrencyInvAnimationManager.Instance.MoneyChange(-Cost);
        InGameCharacterStorage inGameCharacterStorage =
            GameObject.FindObjectOfType<InGameCharacterStorage>();
        characters.AddRange(inGameCharacterStorage.SelectOtherCharacters(MaxPersonHere, building.charactersHere));
        TransformEx.Clear(Content);
        foreach (Character character in characters)
        {
            var item = Instantiate(Temp, Content);
            item.gameObject.SetActive(true);
            item.Setup(character);
        }
    }
}
