using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebateTopicUI : MonoBehaviour
{
    public RectTransform TagRequestField;
    public Image TypeRequestField;
    public Image TagImage;
    public Text TopicName;
    public Text Points;
    public void Setup(DebateTopic debateTopic)
    {
        foreach(Tag tag in debateTopic.tagRequest)
        {
            var newTag = Instantiate(TagImage, TagRequestField);
            string FolderPathOfTags = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
            newTag.GetComponent<Image>().sprite = Resources.Load<Sprite>(FolderPathOfTags);
        }
        string FolderPathOfType = ("Art/CharacterValue/" + debateTopic.characterValue.ToString()).Replace(" ", string.Empty);
        TypeRequestField.sprite = Resources.Load<Sprite>(FolderPathOfType);
        TopicName.text = debateTopic.DebateTopicCode.ToString();
        Points.text = debateTopic.PointMult.ToString();
    }
}
