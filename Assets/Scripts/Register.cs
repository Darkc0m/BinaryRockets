using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register
{
    public byte value;
    public BitArray bitArray;
    public RegisterGO registerGO;

    public Register(RegisterGO registerGO)
    {
        this.registerGO = registerGO;
    }

    public void recalculateValue()
    {
        int[] array = new int[1];
        bitArray.CopyTo(array, 0);
        value = (byte)array[0];
    }

    public void recalculateFromValue(byte value)
    {
        this.value = value;
        bitArray = new BitArray(new byte[] { value });
    }

    public void initializeRandomValues()
    {
        value = (byte)Random.Range(0, 16);
        bitArray = new BitArray(new byte[] { value });
        draw();
    }

    public void initializeRandomValues(int min, int max)
    {
        value = (byte)Random.Range(min, max);
        bitArray = new BitArray(new byte[] { value });
        draw();
    }

    public void draw()
    {
        registerGO.draw();
    }

    public bool hasSameValue(Register other)
    {
        return value == other.value;
    }
}
