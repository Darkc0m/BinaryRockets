using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRegister : RegisterGO
{
    public List<ModelBit> bits;
    public Material onMaterial;
    public Material offMaterial;

    public override void draw()
    {
        for(int i = 0; i < bits.Count; i++)
        {
            bits[i].setMaterial(registerObj.bitArray.Get(i) == true ? onMaterial : offMaterial);
        }
    }
}
