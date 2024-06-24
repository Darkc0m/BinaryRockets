using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterTable : MonoBehaviour
{
    [SerializeField] private ModelRegister registerA, registerB, resultRegister;
    [SerializeField] private byte valueA, valueB, valueResult;

    private void Start()
    {
        registerA.initRegisterWithValue(valueA);
        registerB.initRegisterWithValue(valueB);
        resultRegister.initRegisterWithValue(valueResult);
    }
}
