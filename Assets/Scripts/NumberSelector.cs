using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numberText;
    [SerializeField] int lowestValue = 1;
    [SerializeField] int highestValue = 15;
    [SerializeField] Button increaseBtn;
    [SerializeField] Button reduceBtn;

    int value;

    public void Start()
    {
        value = lowestValue;
        updateComponent();
    }

    private void updateComponent()
    {
        reduceBtn.interactable = value != lowestValue;
        increaseBtn.interactable = value != highestValue;

        numberText.text = $"{value}";
    }

    public void add()
    {
        value++;
        updateComponent();
    }

    public void sub()
    {
        value--;
        updateComponent();
    }

    public int getValue()
    {
        return value;
    }

    public void disable()
    {
        increaseBtn.interactable = false;
        reduceBtn.interactable = false;
    }

    public void enable()
    {
        increaseBtn.interactable = true;
        reduceBtn.interactable = true;
    }
}
