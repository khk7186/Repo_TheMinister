using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCharacters : MonoBehaviour
{
    public Button ExitButton;
    public List<CharacterUI> characterUIList = new List<CharacterUI>();


    private void Start()
    {  
        gameObject.SetActive(false);
    }





}
