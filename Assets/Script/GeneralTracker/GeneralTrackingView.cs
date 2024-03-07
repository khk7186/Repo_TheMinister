using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class GeneralTrackingView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GeneralTrackingViewManager Manager = null;
    [SerializeField] public Animator moveAnimator = null;
    [SerializeField] public Animator sizeAnimator = null;
    public string trackerName = "";
    public Image Head = null;
    public Image Frame = null;
    public Image Background = null;
    public Character character = null;
    public string characterName = string.Empty;
    public string message = string.Empty;
    public int timeLeft = 0;
    public bool isUp = false;
    public bool isDown = false;
    public Text roundLeft = null;
    public Image smallViewImage = null;
    public GeneralTrackingInfo InfoPage = null;
    public bool Finish = false;
    public bool NoAction = false;
    public UnityEvent unityEvent = new UnityEvent();
    public PoliticAssassinEvent assassinEvent = null;
    public Sprite recoveryFrame = null;
    public Sprite assassinFrame = null;
    public Sprite questFrame = null;
    public Sprite recoveryMask = null;
    public Sprite assassinMask = null;
    public Sprite questMask = null;
    public Sprite completeMask = null;
    public Sprite EndFrame = null;
    public void SetFinish()
    {
        Finish = true;
        smallViewImage.color = Color.green;
        //TODO: Find finish line for info
        //if (NoAction)
        //{
        //    character.Back();
        //    StartCoroutine(HideInSec());
        //}
    }
    public void OnSpawn(Character character, bool noAction = false)
    {
        NoAction = noAction;
        this.character = character;
        InfoPage.gameObject.SetActive(false);
        this.characterName = character.CharacterName;
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false);
        Head.sprite = Resources.Load<Sprite>(spritePath);
        var e = new UnityEvent();
        if (character.OnAssassinEvent == false)
        {
            e.AddListener(() => character.Back());
        }
        else
        {
            e.AddListener(() => PoliticSystemManager.Instance.EndAssassin(character));
        }
        if (character.spawnAfterAway != null)
        {
            e.AddListener(() => Instantiate(character.spawnAfterAway.gameObject));
        }
        unityEvent = e;
        smallViewImage.color = Color.red;
        Show();
    }
    public void Setup(string trackerName, string message, int timeLeft, string TrackerType)
    {
        this.trackerName = trackerName;
        this.message = message;
        this.timeLeft = timeLeft;
        if (TrackerType == "assassin")
        {
            this.Frame.sprite = assassinFrame;
            smallViewImage.sprite = assassinMask;
        }
        else if (TrackerType == "recovery")
        {
            this.Frame.sprite = recoveryFrame;
            smallViewImage.sprite = recoveryMask;
        }
        else if (TrackerType == "quest")
        {
            this.Frame.sprite = questFrame;
            smallViewImage.sprite = questMask;
        }
        InfoPage.Setup(characterName, message, timeLeft);
        roundLeft.text = timeLeft.ToString();
        if (timeLeft == 0 && NoAction == false)
        {
            SetFinish();
            smallViewImage.sprite = completeMask;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Manager.PopUpTracker(this);
        InfoPage.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Manager.PopOffTracker(this);
        InfoPage.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Finish)
        {
            unityEvent.Invoke();
            Hide();
        }
        else
        {
            ShowMessage("ÐÐ¶¯ÉÐÎ´½áÊø");
        }
    }
    public void ShowMessage(string messageString)
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = messageString;
    }

    public void Show()
    {
        var rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.zero;
        rect.DOScale(1, 0.1f).OnComplete(() => StartCoroutine(ShowOnSpawn()));
    }
    public IEnumerator ShowOnSpawn()
    {
        Manager.PopUpTracker(this);
        yield return new WaitForSeconds(2f);
        Manager.PopOffTracker(this);
        Manager.MoveReturns();
    }
    public void Hide()
    {
        var rect = GetComponent<RectTransform>();
        Manager.trackingViews.Remove(this);
        rect.DOScale(0, 0.5f).OnComplete(() => Destroy(gameObject));
    }
    public IEnumerator HideInSec()
    {
        yield return new WaitForSeconds(1);
        Hide();
    }
}
