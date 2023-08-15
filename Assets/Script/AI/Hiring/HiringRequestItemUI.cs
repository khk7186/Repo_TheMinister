using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiringRequestItemUI : ItemUI
{
    public Text RequestAmount;
    public void Setup(ItemName item, int amount,int request)
    {
        base.Setup(item,amount);
        RequestAmount.text = request.ToString();
        gameObject.SetActive(true);
    }
}
