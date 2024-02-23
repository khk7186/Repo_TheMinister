using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticPageOpen : MonoBehaviour
{
    public void OpenPage()
    {

        FindObjectOfType<PoliticActionUI>().Show();
    }
}
