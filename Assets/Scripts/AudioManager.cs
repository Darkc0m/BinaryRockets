using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource correct;
    [SerializeField] AudioSource wrong;
    [SerializeField] AudioSource button;
    [SerializeField] AudioSource celebrate;

    public void playCorrect()
    {
        correct.Play();
    }

    public void playWrong()
    {
        wrong.Play();
    }

    public void playButton()
    {
        button.Play();
    }

    public void playCelebrate()
    {
        celebrate.Play();
    }
}
