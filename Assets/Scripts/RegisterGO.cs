using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RegisterGO : MonoBehaviour
{
    protected Register registerObj;

    public abstract void draw();

    public void initRegister()
    {
        registerObj = new Register(this);
        registerObj.initializeRandomValues();
    }

    public void initWithinRange(byte min, byte max)
    {
        registerObj = new Register(this);
        registerObj.initializeRandomValues(min, max);
    }

    public void initRegisterWithValue(byte value)
    {
        registerObj = new Register(this);
        registerObj.recalculateFromValue(value);
        registerObj.draw();
    }

    public Register getRegisterObj()
    {
        return registerObj;
    }

    public byte getValue()
    {
        return registerObj.value;
    }

    public void setValue(byte value)
    {
        registerObj.value = value;
        registerObj.bitArray = new BitArray(new byte[] { value });
        draw();
    }
}
