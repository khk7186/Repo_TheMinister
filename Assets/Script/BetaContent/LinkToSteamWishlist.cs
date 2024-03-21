using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.EventSystems;

public class LinkToSteamWishlist : MonoBehaviour,IPointerClickHandler
{
    public string url = "https://store.steampowered.com/app/1234567";
    /// <summary>
    /// 加入愿望单, url就是游戏的商店页地址
    /// </summary>
    public void AddToSteamWish(string url)
    {
#if DISABLESTEAMWORKS || UNITY_EDITOR
        Application.OpenURL(url);
#else
        // 只能拉起愿望单页面，并不会加入愿望单
        SteamFriends.ActivateGameOverlayToWebPage(url);
#endif
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AddToSteamWish(url);
    }
}
