using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticImpeachPage : PoliticPage
{
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text difficultyText = null;
    public GameObject difficultyGameobject = null;
    public Text alreadySpent = null;
    public Slider newOfferSlider = null;
    public Text newOfferText = null;
    public Text slotReward = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public CurrencyInventory inventory = null;
}
