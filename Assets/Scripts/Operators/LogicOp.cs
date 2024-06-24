using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LogicOp : Operator
{
    public void setOther(Register other);
}
