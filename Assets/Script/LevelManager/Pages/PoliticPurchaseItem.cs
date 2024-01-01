using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GovernorType 
{
    文贞,
    文正,
    文,
    武勇,
    武忠,
    武
};
public class PoliticPurchaseItem : MonoBehaviour
{
    public static Dictionary<ItemName, int> LoyaltyShopPrice = new Dictionary<ItemName, int>()
    {
        {ItemName.文官状, 2},
        {ItemName.武官状, 2},
        {ItemName.弹劾文书, 1},
        {ItemName.御马官印, 1 }
    };

    public static Dictionary<GovernorType, List<ItemName>> GovernorShop = new Dictionary<GovernorType, List<ItemName>>()
    {
        {GovernorType.文贞, new List<ItemName>(){ItemName.文官状,
                                                                                         ItemName.弹劾文书,}
        },
        {GovernorType.文正,new List<ItemName>(){ItemName.文官状,
                                                                                        ItemName.弹劾文书} },
        {GovernorType.文,new List<ItemName>(){ItemName.文官状,
                                                                                        ItemName.弹劾文书} },
        {GovernorType.武勇,new List<ItemName>(){ItemName.武官状,
                                                                                        ItemName.御马官印} },
        {GovernorType.武忠,new List<ItemName>(){ItemName.武官状,
                                                                                        ItemName.御马官印} },
        {GovernorType.武,new List<ItemName>(){ItemName.武官状,
                                                                                        ItemName.御马官印} },
    };
}
