using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubOp : ArithmeticOp
{
    byte value;

    public void operate(Register register)
    {
        register.value -= value;
        register.value %= 16;
        register.bitArray = new BitArray(new byte[] { register.value });
        register.draw();
    }

    public void setValue(int value)
    {
        this.value = (byte)value;
    }
}