using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPopUI : MonoBehaviour
{
    private Character Character;
    private List<AIInteractType> interactTypes = new List<AIInteractType>();
    private string parentPath = "NPCInteractiveUI/InteractiveButton/";
    public bool loaded = false;
    private CharacterInfoUI currentCharacterInfoUI;
    public Button Info,Talk, Attack, Hire, Trade, Gobang, Debate;

    public void Setup(Character character, List<AIInteractType> types, Transform characterImage)
    {
        Character = character;
        interactTypes.AddRange(types);
        foreach (AIInteractType interactType in interactTypes)
        {
            string finalPath = (parentPath + interactType.ToString()).Replace(" ", string.Empty);
            var target = Instantiate(Resources.Load<Button>(finalPath), transform);
            target.transform.position = Camera.main.WorldToScreenPoint(characterImage.position);
        }
        StartCoroutine(LoadDelay());
        SetPosition(characterImage);
    }
    private void Update()
    {
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && loaded)
            {
                Destroy(gameObject);
            }
        }
    }

    private void SetPosition(Transform targetTransform)
    {
        var CanvasRect = MainCanvas.FindMainCanvas().GetComponent<RectTransform>();
        var MainCamera = Camera.main;
        var Position = targetTransform.position;
        Vector2 AP = WorldToCanvasPosition(CanvasRect, MainCamera, Position);
        AP.x += 40;
        AP.y += 35;
        GetComponent<RectTransform>().anchoredPosition = AP;
    }
    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0.001f);
        loaded = true;
    }
    public void SelectCharacterInfo()
    {
        var target = Resources.Load<CharacterInfoUI>("CharacterInfo/CharacterInfo");
        currentCharacterInfoUI = Instantiate(target, FindObjectOfType<Canvas>().transform);
        currentCharacterInfoUI.Setup(Character);
        //Debug.Log(currentCharacterInfoUI);
    }

    private Vector2 WorldToCanvasPosition(RectTransform canvas, Camera camera, Vector3 position)
    {
        //Vector position (percentage from 0 to 1) considering camera size.
        //For example (0,0) is lower left, middle is (0.5,0.5)
        Vector2 temp = camera.WorldToViewportPoint(position);

        //Calculate position considering our percentage, using our canvas size
        //So if canvas size is (1100,500), and percentage is (0.5,0.5), current value will be (550,250)
        temp.x *= canvas.sizeDelta.x;
        temp.y *= canvas.sizeDelta.y;

        //The result is ready, but, this result is correct if canvas recttransform pivot is 0,0 - left lower corner.
        //But in reality its middle (0.5,0.5) by default, so we remove the amount considering cavnas rectransform pivot.
        //We could multiply with constant 0.5, but we will actually read the value, so if custom rect transform is passed(with custom pivot) , 
        //returned value will still be correct.

        temp.x -= canvas.sizeDelta.x * canvas.pivot.x;
        temp.y -= canvas.sizeDelta.y * canvas.pivot.y;

        return temp;
    }
}
