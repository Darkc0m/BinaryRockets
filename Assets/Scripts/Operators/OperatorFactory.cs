using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OperatorFactory
{
    public static Operator getOperator(OpType type)
    {
        switch (type)
        {
            case OpType.ADD:
                return new AddOp();
            case OpType.SUB:
                return new SubOp();
            case OpType.AND:
                return new AndOp();
            case OpType.OR:
                return new OrOp();
            case OpType.NOT:
                return new NotOp();
            case OpType.NAND:
                return new NandOp();
            case OpType.NOR:
                return new NorOp();
            case OpType.XOR:
                return new XorOp();
            default:
                return null;
        }
    }

    public static string getName(OpType type)
    {
        switch (type)
        {
            case OpType.ADD:
                return "sumar";
            case OpType.SUB:
                return "restar";
            case OpType.AND:
                return "AND";
            case OpType.OR:
                return "OR";
            case OpType.NOT:
                return "NOT";
            case OpType.NAND:
                return "NAND";
            case OpType.NOR:
                return "NOR";
            case OpType.XOR:
                return "XOR";
            default:
                return null;
        }
    }
}
