using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBit : MonoBehaviour
{
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void setMaterial(Material material)
    {
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
