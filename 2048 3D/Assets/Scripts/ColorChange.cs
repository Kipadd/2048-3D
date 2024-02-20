using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] materials;
    private int currentMaterialIndex = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("vork!");
            currentMaterialIndex ++;
            if (currentMaterialIndex >= materials.Length)
            {
                currentMaterialIndex = 0;
            }
        GetComponent<MeshRenderer>().material = materials[currentMaterialIndex];
        }
    }
}
