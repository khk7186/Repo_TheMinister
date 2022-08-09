using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingInterfaceUI : MonoBehaviour
{
    public DatingCharacterUI childTemp;
    public Transform content;
    private void Awake()
    {
        childTemp.gameObject.SetActive(false);
    }
    public void Setup(List<Character> characters)
    {
        TransformEx.Clear(content);
        foreach (Character character in characters)
        {
            SpwanTemp(character);
        }
    }
    public void SpwanTemp(Character character)
    {
        var target = Instantiate(childTemp, content);
        target.gameObject.SetActive(true);
        target.Setup(character);
    }
}
