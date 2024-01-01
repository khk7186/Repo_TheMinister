using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticPurchaseItem : MonoBehaviour
{
    public static Dictionary<ItemName, int> LoyaltyShopPrice = new Dictionary<ItemName, int>()
    {
        {ItemName.文官状, 2},
        {ItemName.武官状, 2},
        {ItemName.弹劾文书, 1},
        {ItemName.御马官印, 1 }
    };
}
