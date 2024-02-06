using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticFactionTrigger : MonoBehaviour
{
    public PoliticFactionMenuUI politicFactionMenuUI = null;
    public void OnClick()
    {
        politicFactionMenuUI.Show();
    }
}
