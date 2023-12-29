using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticSystemManager : MonoBehaviour
{
    public static PoliticSystemManager Instance;
    public int AssassinDuration = 6;
    public List<PoliticAssassinEvent> OngoingAssassinEvents = new List<PoliticAssassinEvent>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
