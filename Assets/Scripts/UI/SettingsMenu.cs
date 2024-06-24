using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject disabledAudio;

    public void activeAudio()
    {
        disabledAudio.SetActive(!disabledAudio.activeSelf);
    }
}
