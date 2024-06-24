using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XorOp : LogicOp
{
    public Register other;

    public void operate(Register register)
    {
        for (int i = 0; i < 4; i++)
        {
            register.bitArray.Set(i, register.bitArray.Get(i) ^ other.bitArray.Get(i));
        }
        register.recalculateValue();
        register.draw();
    }

    public void setOther(Register other)
    {
        this.other = other;
    }
}
