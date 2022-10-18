using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToSearch : MonoBehaviour,IEqualityComparer<LinkToSearch>
{
    public string searchName;
    public bool Equals(LinkToSearch x, LinkToSearch y)
    {
        return string.Equals(x.searchName, y.searchName);
    }
    public int GetHashCode(LinkToSearch obj)
    {
        return obj.searchName.GetHashCode();
    }
    public static LinkToSearch FindTheLink(string searchName)
    {
        var pool = GameObject.FindObjectsOfType<LinkToSearch>(true);
        foreach(LinkToSearch link in pool)
        {
            if(link.searchName == searchName)
            {
                return link;
            }
        }
        return null;
    }
    public static List<LinkToSearch> FindAllLinks(string searchName)
    {
        var pool = GameObject.FindObjectsOfType<LinkToSearch>(true);
        var result = new List<LinkToSearch>();
        foreach (LinkToSearch link in pool)
        {
            if (link.searchName == searchName)
            {
                result.Add(link);
            }
        }
        return result;
    }
}
