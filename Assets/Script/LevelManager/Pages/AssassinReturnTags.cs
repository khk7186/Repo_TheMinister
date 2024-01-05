using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinReturnTags : MonoBehaviour
{

    public static List<Tag> SwapTags = new List<Tag>()
    { Tag.Ò©¶¾,
        Tag.Ò©¶¾,
        Tag.Ò©¶¾,
        Tag.ÒåÖ«,
        Tag.ÒåÖ«,
        Tag.¶À±Û,
        Tag.¶À±Û,
        Tag.¶À±Û,
        Tag.¶òÔË²øÉí,
        Tag.¶òÔË²øÉí,
        Tag.ÍÈ½Å²»±ã,
        Tag.ÍÈ½Å²»±ã,
        Tag.ÍÈ½Å²»±ã,
        Tag.°ëÉí²»Ëì,
        Tag.°ëÉí²»Ëì,
        Tag.Í·ÌÛ,
        Tag.Í·ÌÛ,
        Tag.Ï¥¸Ç½©Ó²,
        Tag.Ï¥¸Ç½©Ó²,
        Tag.ÎŞÉË´óÑÅ,
        Tag.ÎåÎ¶ÔÓ³Â,
    
    };
    
    public static Tag TagAfterAssassin()
    {       
            return SwapTags[Random.Range(0, SwapTags.Count - 1)];
    }

    public static List<Tag> GetTagsAfter()
    {
        List<Tag> AfterTags = new List<Tag>();
        int tagAmount = Random.Range(1, 3);
        for (int i = tagAmount;i >= 1; i --)
        {
            AfterTags.Add(TagAfterAssassin());
        }
        return AfterTags;
    }
    
   

    
}
