using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceRegister : RegisterGO
{
    [SerializeField] List<InterfaceBit> bits;
    [SerializeField] GameObject isSelectedBackground;
    [SerializeField] Button registerBtn;
    public int index;

    public override void draw()
    {
        for (int i = 0; i < bits.Count; i++)
        {
            bits[i].setValue(registerObj.bitArray.Get(i));
        }
    }

    public void recalculateFromBits()
    {
        byte value = 0;
        for(int i = 0; i < bits.Count; i++)
        {
            if (bits[i].getValue())
                value += (byte)Math.Pow(2, i);
        }

        registerObj.recalculateFromValue(value);
    }
}
