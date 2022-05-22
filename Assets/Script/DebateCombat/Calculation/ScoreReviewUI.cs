using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReviewUI : MonoBehaviour
{
    public RectTransform mainPannel;
    public Text totalScorePannel;
    public Text totalMultiPannel;
    public RectTransform scorePannel;
    public RectTransform multiPannel;
    public RectTransform pointCollectmultiPannel;
    public Text currentPointCollectName;
    public Text currentScore;
    public Text currentMulti;
    public IEnumerator NextPointCollecter(DebatePointCollector pointCollector)
    {
        yield return null;
    }
    public IEnumerator FinishAnimation()
    {
        yield return null;
    }
}
