using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArithmeticEasy : BaseGame
{
    [SerializeField] private NumberSelector numberSelector;

    private ArithmeticOp selectedOp;

    void Awake()
    {
        opTypes = new OpType[] { OpType.ADD, OpType.SUB };
    }

    public override void startGame()
    {
        selectedType = opTypes[Random.Range(0, 2)];
        selectedOp = (ArithmeticOp)OperatorFactory.getOperator(selectedType);

        //playerRegister.initRegister();
        //do
        //    goalValue = (byte)Random.Range(0, 16);
        //while (playerRegister.getValue() == goalValue);

        initValuesInRange();
        
        setSelectedOpText();

        goalText.text = $"El código es {goalValue}";

        Debug.LogWarning($"{playerRegister.getValue()} {selectedType} ? = {goalValue}");
    }

    public void initValuesInRange()
    {
        switch (selectedType)
        {
            case OpType.ADD:
                playerRegister.initWithinRange(0, 12);
                goalValue = (byte)Random.Range(playerRegister.getValue() + 1, 16);
                break;
            case OpType.SUB:
                playerRegister.initWithinRange(4, 16);
                goalValue = (byte)Random.Range(0, playerRegister.getValue());
                break;
        }
    }

    public override void solve()
    {
        selectedOp.setValue(numberSelector.getValue());
        selectedOp.operate(playerRegister.getRegisterObj());

        Debug.Log($"Ahora vale: {playerRegister.getValue()}");
    }

    public override void disableBtn()
    {
        confirmBtn.interactable = false;
        backBtn.interactable = false;
        numberSelector.disable();
    }

    public override void enableBtn()
    {
        confirmBtn.interactable = true;
        backBtn.interactable = true;
        numberSelector.enable();
    }

    public override void setSelectedOpText()
    {
        selectedOpText.text = $"Tienes que {OperatorFactory.getName(selectedType)}";
    }
}
