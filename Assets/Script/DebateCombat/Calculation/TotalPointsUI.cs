using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TotalPointsUI : MonoBehaviour
{
    public RectTransform mainPannel;
    public int totalPoints = 0;
    public int totalMulti = 0;
    public Text TotalPoints;
    public Text TotalMulti;
    public float duration = 0.1f;

    public void Start()
    {
        mainPannel.localPosition = new Vector3(50, 70, 0);
    }
    public IEnumerator StartAnimate(int point, int multi)
    {
        yield return PointCountTo(point);
        StartCoroutine(MultiCountTo(multi));
    }
    IEnumerator PointCountTo(int target)
    {
        int start = totalPoints;
        int current = start;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            current = (int)Mathf.Lerp(start, start + target, progress);
            string symble = current >= 0 ? "+" : "-";
            TotalPoints.text = $"{symble}{current.ToString()}";
            yield return null;
        }
        string finalSymble = current >= 0 ? "+" : "-";
        totalPoints = start + target;
        TotalPoints.text = $"{finalSymble}{totalPoints}";
    }
    IEnumerator MultiCountTo(int target)
    {
        int start = totalMulti;
        int current = start;
        for (float timer = 0; timer <= duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            current = (int)Mathf.Lerp(start, start + target, progress);
            TotalMulti.text = $"¡Á{current.ToString()}";
            yield return null;
        }
        totalMulti = start + target;
        TotalMulti.text = $"¡Á{totalMulti}";
    }

    public IEnumerator FinalCount()
    {
        int final = totalPoints * totalMulti;
        float finalDuration = duration * 3;
        var targetColor = ColorUtility.TryParseHtmlString("#7D000D", out Color color) ? color : Color.red;
        TotalPoints.DOColor(targetColor, finalDuration);
        TotalPoints.GetComponent<RectTransform>().DOAnchorPos(new Vector2(150f, -120f), finalDuration);
        TotalPoints.GetComponent<RectTransform>().DOScale(1.8f, finalDuration);
        for (float timer = 0; timer <= finalDuration; timer += Time.deltaTime)
        {
            float progress = timer / finalDuration;
            TotalMulti.text = ((int)Mathf.Lerp(totalMulti, 0, progress)).ToString();
            TotalPoints.text = ((int)Mathf.Lerp(totalPoints, final, progress)).ToString();
            yield return null;
        }
        totalPoints = final;
        TotalMulti.text = "0";
        TotalPoints.text = final.ToString();
        
    }

}
