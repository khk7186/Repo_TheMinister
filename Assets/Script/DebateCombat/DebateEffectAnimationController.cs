using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DebateEffectAnimationController : MonoBehaviour
{
    public VideoPlayer Victory;
    public VideoPlayer Defeat;
    public float Delay = 1f;
    public List<Image> VictoryImages = new List<Image>();
    public List<Image> DefeatImages = new List<Image>();
    public List<RectTransform> DamageText = new List<RectTransform>();
    public List<ShakeObject> shakeObjects = new List<ShakeObject>();
    public List<int> damageShow = new List<int>() { 0, 0, 0, 0 };

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            VictoryImages[i]?.gameObject.SetActive(false);
            DefeatImages[i]?.gameObject.SetActive(false);
            DamageText[i]?.gameObject.SetActive(false);
        }
    }
    public List<int> Setup(List<int> result)
    {
        int victoryTop = 0;
        int winIndex = 0;
        for (int i = 0; i < result.Count; i++)
        {
            if (result[i] > victoryTop)
            {
                victoryTop = result[i];
                winIndex = i;
            }
        }
        SetSubImages(result, victoryTop, winIndex);
        SetDamageText(result, victoryTop);
        Victory.Prepare();
        Defeat.Prepare();
        return damageShow;
    }
    private void SetDamageText(List<int> result, int victoryTop)
    {
        for (int i = 0; i < result.Count; i++)
        {
            if (result[i] == 0)
            {
                continue;
            }
            damageShow[i] = result[i] - victoryTop;
        }
    }
    public void SetSubImages(List<int> result, int victoryTop, int winIndex)
    {
        for (int i = 0; i < result.Count; i++)
        {
            if (i == winIndex)
            {
                VictoryImages[i].gameObject.SetActive(true);
                DefeatImages[i].gameObject.SetActive(false);
            }
            else
            {
                VictoryImages[i].gameObject.SetActive(false);
                DefeatImages[i].gameObject.SetActive(true);
            }
        }
    }

    public void PlayVictory()
    {
        Victory.Play();
    }
    public void PlayDefeat()
    {
        Defeat.Play();
    }

    public void DisplayDamage()
    {
        for (int i = 0; i < 4; i++)
        {
            if (damageShow[i] >= 0)
            {
                continue;
            }
            DamageText[i].gameObject.SetActive(true);
            shakeObjects[i].StartShake();
            Text pref = DamageText[i].GetComponentInChildren<Text>(true);
            var output = Instantiate<Text>(pref, DamageText[i].transform);
            output.text = damageShow[i].ToString();
            output.gameObject.SetActive(true);
        }
    }
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    public IEnumerator PlayRoutine()
    {
        PlayVictory();
        yield return new WaitForSeconds(Delay);
        PlayDefeat();
        yield return new WaitForSeconds(0.1f);
        DisplayDamage();
        var allUnits = FindObjectsOfType<DebateUnit>();
        yield return new WaitForSeconds(0.1f);
        foreach (var unit in allUnits)
        {
            unit.PointsChange(damageShow[unit.index]);
        }
        yield return new WaitForSeconds(Delay);
        Start();
        FindObjectOfType<DebateMainEventManager>().NextTopic();
    }
}
