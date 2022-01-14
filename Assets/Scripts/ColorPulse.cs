using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPulse : MonoBehaviour
{
    Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        GameObject building = GameObject.Find("HQ");
        Renderer renderer = building.GetComponent<Renderer>();
        Material[] materialsArray = renderer.sharedMaterials;

        foreach (Material material in materialsArray)
        {
            if (material.name.StartsWith("MAT_Red_Dynamic"))
            {
                this.m_Material = material;                
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Material == null) return;

        float red = Mathf.Sin(Time.time*5);
        Color c = new Color(red, 0, 0);

        m_Material.SetColor("_EmissionColor", c);
    }
}
