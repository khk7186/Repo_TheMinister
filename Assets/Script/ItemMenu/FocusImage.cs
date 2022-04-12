using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusImage : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private Text Name;
    [SerializeField] private Text Info;

    public void Setup(ItemName itemName)
    {
        Image.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnItemPath(itemName));
        Name.text = itemName.ToString();
        //TODO: INFO
    }
}
