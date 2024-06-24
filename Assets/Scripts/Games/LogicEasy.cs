using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicEasy : BaseGame
{
    [SerializeField] private InterfaceRegister uiRegister;
    [SerializeField] private List<Button> OpButtons;
    [SerializeField] private InterfaceRegister goalRegister;

    private LogicOp selectedOp;
    private int selectedOpBtn;

    void Awake()
    {
        opTypes = new OpType[] { OpType.AND, OpType.OR, OpType.XOR, OpType.NAND, OpType.NOR };
    }

    public override void startGame()
    {
        playerRegister.initRegister();

        uiRegister.initRegister();

        selectedType = opTypes[UnityEngine.Random.Range(0, opTypes.Length)];
        selectedOp = (LogicOp)OperatorFactory.getOperator(selectedType);

        do
        {
            goalRegister.initRegister();
        } while (playerRegister.getValue() == goalRegister.getValue());

        uiRegister.getRegisterObj().recalculateFromValue(goalRegister.getValue());
        uiRegister.draw();
        selectedOp.setOther(playerRegister.getRegisterObj());
        selectedOp.operate(goalRegister.getRegisterObj());
        goalValue = goalRegister.getValue();

        Debug.LogWarning($"Tienes que llegar a: {Convert.ToString(goalValue, 2).PadLeft(4, '0')} {selectedOp}");
        goalText.text = $"El código es {Convert.ToString(goalValue, 2).PadLeft(4, '0')}";
    }

    public override void solve()
    {
        selectedType = opTypes[selectedOpBtn - 1];
        Debug.LogWarning($"Has elegido {selectedType}");
        selectedOp = (LogicOp)OperatorFactory.getOperator(selectedType);
        selectedOp.setOther(uiRegister.getRegisterObj());
        selectedOp.operate(playerRegister.getRegisterObj());
    }

    public void selectOpButton(int index)
    {
        selectedOpBtn = index;
        confirmBtn.interactable = true;
        foreach(Button b in OpButtons)
            b.interactable = true;
        OpButtons[index - 1].interactable = false;
    }

    public override void disableBtn()
    {
        confirmBtn.interactable = false;
        backBtn.interactable = false;
        foreach(Button b in OpButtons)
            b.interactable = false;
    }

    public override void enableBtn()
    {
        confirmBtn.interactable = false;
        backBtn.interactable = true;
        foreach (Button b in OpButtons)
            b.interactable = true;

        if (selectedOpBtn != 0)
        {
            OpButtons[selectedOpBtn - 1].interactable = false;
            confirmBtn.interactable = true;
        }
    }

    public override void setSelectedOpText(){}
}
