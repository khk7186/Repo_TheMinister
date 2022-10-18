using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLinkToSearch : MonoBehaviour
{
    [System.Serializable]
    public struct LinkToSearchStorage
    {
        public string searchName;
        public LinkToSearch selectObject;
    }
    public bool SearchOnEnable = false;
    public List<string> searchNameList;
    public List<LinkToSearchStorage> storage;
    private void OnEnable()
    {
        if (SearchOnEnable)
        {
            storage = new List<LinkToSearchStorage>();
            foreach (string str in searchNameList)
            {
                storage.Add(new LinkToSearchStorage
                {
                    searchName = str,
                    selectObject = LinkToSearch.FindTheLink(str)
                });
            }
        }
    }
    public LinkToSearch GetLinkToSearch(string searchName)
    {
        foreach (LinkToSearchStorage link in storage)
        {
            if (link.searchName == searchName)
            {
                return link.selectObject;
            }
        }
        return null;
    }
}
