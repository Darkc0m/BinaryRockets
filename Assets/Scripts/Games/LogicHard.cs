using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicHard : BaseGame
{
    [SerializeField] private InterfaceRegister uiRegister;
    [SerializeField] private InterfaceRegister goalRegister;

    private LogicOp selectedOp;

    void Awake()
    {
        opTypes = new OpType[] { OpType.AND, OpType.XOR, OpType.NAND, OpType.NOR };
    }

    public override void startGame()
    {
        playerRegister.initRegister();

        uiRegister.initRegister();

        selectedType = opTypes[UnityEngine.Random.Range(0, opTypes.Length)];
        selectedOp = (LogicOp)OperatorFactory.getOperator(selectedType);
        setSelectedOpText();

        do {
            goalRegister.initRegister();
        } while (playerRegister.getValue() == goalRegister.getValue());

        uiRegister.getRegisterObj().recalculateFromValue(goalRegister.getValue());
        selectedOp.setOther(playerRegister.getRegisterObj());
        selectedOp.operate(goalRegister.getRegisterObj());
        goalValue = goalRegister.getValue();

        Debug.LogWarning($"Tienes que llegar a: {Convert.ToString(goalValue, 2).PadLeft(4, '0')}");
        goalText.text = $"El código es {Convert.ToString(goalValue, 2).PadLeft(4, '0')}";
    }

    public override void solve()
    {
        uiRegister.recalculateFromBits();
        selectedOp.setOther(uiRegister.getRegisterObj());
        selectedOp.operate(playerRegister.getRegisterObj());

        Debug.Log($"Ahora vale: {playerRegister.getValue()}");
    }

    public override void disableBtn()
    {
        confirmBtn.interactable = false;
        backBtn.interactable = false;
    }

    public override void enableBtn()
    {
        confirmBtn.interactable = true;
        backBtn.interactable = true;
    }

    public override void setSelectedOpText()
    {
        selectedOpText.text = $"Operación elegida: {OperatorFactory.getName(selectedType)}";
    }
}
