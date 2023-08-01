using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public Material defaultMaterial;
    public List<MaterialSave> materials;

    public void Change(string rarity, Image targetImage)
    {
        var targetMaterial = materials.Find(x => x.name == rarity).material;
        Debug.Log(rarity);
        targetImage.material = targetMaterial;
    }
    public void UnChange(Image targetImage)
    {
        Material targetMaterial = null;
        if (defaultMaterial != null)
        {
            targetMaterial = defaultMaterial;
        }
        targetImage.material = targetMaterial;
    }


}
[Serializable]
public class MaterialSave
{
    public string name;
    public Material material;
}
