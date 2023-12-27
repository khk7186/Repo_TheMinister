using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicUI : MonoBehaviour
{
    public Text TopicName;
    public Image wisdomBackground;
    public Image writingBackground;
    public Image strategyBackground;
    public RectTransform tags;
    public GameObject tagPref;
    public void StartNewTopic(DebateTopic topic)
    {
        TopicName.text = topic.debateTopicCode.ToString();
        wisdomBackground.gameObject.SetActive(false);
        writingBackground.gameObject.SetActive(false);
        strategyBackground.gameObject.SetActive(false);
        foreach (CharacterValueType type in topic.characterValue)
        {
            string path = ReturnAssetPath.ReturnCharacterStatBackground(topic.rarerity);
            switch (type)
            {
                case CharacterValueType.ÖÇ:
                    writingBackground.gameObject.SetActive(true);
                    writingBackground.sprite = Resources.Load<Sprite>(path);
                    break;
                case CharacterValueType.²Å:
                    writingBackground.gameObject.SetActive(true);
                    writingBackground.sprite = Resources.Load<Sprite>(path);
                    break;
                case CharacterValueType.Ä±:
                    strategyBackground.gameObject.SetActive(true);
                    strategyBackground.sprite = Resources.Load<Sprite>(path);
                    break;
            }
        }
        TransformEx.Clear(tags);
        foreach (Tag tag in topic.tagRequest)
        {
            var newTag = Instantiate(tagPref, tags);
            newTag.GetComponentInChildren<TagWithDescribetion>().Setup(tag);
        }
    }
}
