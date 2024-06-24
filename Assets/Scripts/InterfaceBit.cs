using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceBit : MonoBehaviour
{
    [SerializeField] private Sprite bitOnSprite, bitOffSprite;
    [SerializeField] private Image image;
    bool value;

    public void setValue(bool newValue)
    {
        value = newValue;
        image.sprite = newValue ? bitOnSprite : bitOffSprite;
    }

    public void click()
    {
        setValue(!value);
    }

    public bool getValue()
    {
        return value;
    }
}
