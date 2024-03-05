using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPoliticSlotPages : MonoBehaviour
{
    public GameObject objectToActive = null;
    private void OnEnable()
    {
        FindObjectOfType<PoliticActionUI>().Show();
        StartCoroutine(OpenDialogue());
    }
    private void OnDisable()
    {
        FindObjectOfType<PoliticActionUI>().Hide();
    }
    IEnumerator OpenDialogue()
    {
        yield return new WaitForSeconds(1f);
        objectToActive.gameObject.SetActive(true);
    }
}
