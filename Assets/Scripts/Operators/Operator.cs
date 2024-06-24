using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Operator
{
    public void operate(Register register);
}

public enum OpType
{
    AND,
    OR,
    XOR,
    SUB,
    ADD,
    NOT,
    NAND,
    NOR
}
