using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseGame : MonoBehaviour
{
    [SerializeField] protected ModelRegister playerRegister;
    [SerializeField] protected TextMeshPro goalText; //EL BOCADILLO DE ASTRONAUTA
    [SerializeField] protected TextMeshProUGUI selectedOpText;
    [SerializeField] protected Button confirmBtn, backBtn;

    protected byte goalValue;
    protected OpType[] opTypes;
    protected OpType selectedType;

    public abstract void startGame();

    public abstract void solve();

    public abstract void disableBtn();

    public abstract void enableBtn();

    public abstract void setSelectedOpText();

    public bool isGoalReached()
    {
        return playerRegister.getValue() == goalValue;
    }
}