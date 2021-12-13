using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaTagUI : MonoBehaviour
{
    [SerializeField] private Image tagPref;
    public List<Tag> tagList;
    public void Setup(List<Tag> tags)
    {
        tagList = tags;
        foreach (Tag tag in tags)
        {
            var target = Instantiate(tagPref, transform);
            string path = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
            target.sprite = Resources.Load<Sprite>(path);
        }
    }
}
