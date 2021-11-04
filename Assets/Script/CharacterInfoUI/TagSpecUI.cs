using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagSpecUI : MonoBehaviour
{
    public Image tagIcon;
    public Text Info;

    public void SetUp(Tag tag)
    {
        SetTagIcon(tag);
        SetTagInfo(tag);
    }

    private void SetTagIcon(Tag tag)
    {
        string FolderPathOfTags = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
        tagIcon.sprite = Resources.Load<Sprite>(FolderPathOfTags);
    }

    private void SetTagInfo(Tag tag)
    {
        
    }
}
