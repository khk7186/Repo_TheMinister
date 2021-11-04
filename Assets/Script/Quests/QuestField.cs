using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestField : MonoBehaviour
{
    public GameObject nodeRoot;
    public Button submitButton;

    public void Awake()
    {
        submitButton.gameObject.SetActive(false);
    }

    public void ShowSubmit()
    {
        submitButton.gameObject.SetActive(true);
    }
    public void HideSubmit()
    {
        submitButton.gameObject.SetActive(false);
    }

}
