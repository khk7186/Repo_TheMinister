using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TagExchangeUI : MonoBehaviour
{
    public Character character;
    public Tag newTag;
    public TagSpecUI tagSpecUI;

    public Transform tagCardGroup;
    public TagInfoCardOnExchangeUI tagCardPrf;
    public void SetUp(Tag newtag, Character character)
    {
        this.newTag = newtag;
        this.character = character;
        foreach (Tag tag in character.tagList)
        {
            var current = Instantiate(tagCardPrf, tagCardGroup);
            current.SetUp(tag,newTag,character);
        }
        tagSpecUI.SetUp(newTag);
    }
    public void FinishTheState()
    {
        GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().RemoveItem();
        FindObjectOfType<ItemInventoryUI>().SetUp();
        Destroy(FindObjectOfType<PlayerCharactersInventory>().gameObject);
        Destroy(gameObject);
    }
}
