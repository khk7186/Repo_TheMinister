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

    public void Setup(Character character, List<AIInteractType> types,Transform characterImage)
    {
        Character = character;
        interactTypes.AddRange(types);
        foreach (AIInteractType interactType in interactTypes)
        {
            string finalPath = (parentPath + interactType.ToString()).Replace(" ", string.Empty);
            var target = Instantiate(Resources.Load<Button>(finalPath), transform);
            target.transform.position = Camera.main.WorldToScreenPoint(characterImage.position);
        }
        loaded = true;
    }
    private void FixedUpdate()
    {
        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))&&loaded)
        {
            Destroy(gameObject);
        }
    }
}
