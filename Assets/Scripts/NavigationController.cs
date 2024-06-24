using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bubbleText;
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Animator fadeoutAnimator, panelAnimator;
    [SerializeField] private GameObject muteImage;
    private GameMode selectedGameMode = GameMode.NotSelected;
    private Difficulty selectedDifficulty = Difficulty.NotSelected;
    private bool isTutorial = false;

    private void Start()
    {
        if (AudioListener.volume == 0)
            muteImage.SetActive(true);
    }

    public void clickMode(int num)
    {
        selectedGameMode = (GameMode)num;
        confirmBtn.interactable = true;
        switch ((GameMode)num)
        {
            case GameMode.Arithmetic:
                bubbleText.text = $"Practica la suma y resta binaria";
                break;
            case GameMode.Logic:
                bubbleText.text = $"Practica las operaciones lógicas";
                break;
            case GameMode.NotSelected:
                bubbleText.text = $"Elige un modo de juego";
                selectedDifficulty = Difficulty.NotSelected;
                confirmBtn.interactable = false;
                isTutorial = false;
                break;
        }
    }

    public void clickTutorial()
    {
        isTutorial = true;
    }

    public void clickMute()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        muteImage.SetActive(!muteImage.activeSelf);
    }

    public void clickExit()
    {
        Application.Quit();
    }

    public void clickDifficulty(int num)
    {
        selectedDifficulty = (Difficulty)num;
        if (selectedDifficulty == Difficulty.Normal)
        {
            bubbleText.text = "Has seleccionado normal";
        }
        else
        {
            bubbleText.text = "Has seleccionado difícil";
        }
        confirmBtn.interactable = true;
    }

    public void clickAbout()
    {
        bubbleText.text = "Binary Rockets utiliza marcadores de realidad aumentada en sus niveles. Pulsa descargar para poder imprimirlos.";
    }

    public void clickDownload()
    {
        Application.OpenURL("https://darkc0m.github.io/BinaryRocketsWeb/");
    }

    public void clickConfirm()
    {
        if (isTutorial)
        {
            fadeoutAnimator.SetTrigger("NextLevel");
            StartCoroutine(delayForTutorial(selectedGameMode));
        }
        else if(selectedDifficulty == Difficulty.NotSelected)
        {
            bubbleText.text = "Elige un nivel de dificultad";
            confirmBtn.interactable = false;
            panelAnimator.SetTrigger("SelectGameMode");
        }
        else
        {
            fadeoutAnimator.SetTrigger("NextLevel");
            //Empezar partida
            StartCoroutine(delayForLevel(selectedGameMode, selectedDifficulty));
        }
    }

    IEnumerator delayForTutorial(GameMode mode)
    {
        yield return new WaitForSeconds(1f);

        switch (mode)
        {
            case GameMode.Arithmetic:
                SceneManager.LoadScene("BinaryTutorial");
                break;
            case GameMode.Logic:
                SceneManager.LoadScene("LogicTutorial");
                break;
        }
    }

    IEnumerator delayForLevel(GameMode mode, Difficulty difficulty)
    {
        yield return new WaitForSeconds(1.0f);

        switch (mode)
        {
            case GameMode.Arithmetic:
                if (difficulty == Difficulty.Normal)
                    SceneManager.LoadScene("Arithmetic Easy");
                else if(difficulty == Difficulty.Hard)
                    SceneManager.LoadScene("Arithmetic Hard");
                break;
            case GameMode.Logic:
                if (difficulty == Difficulty.Normal)
                    SceneManager.LoadScene("Logic Easy");
                else if (difficulty == Difficulty.Hard)
                    SceneManager.LoadScene("Logic Hard");
                break;
            case GameMode.NotSelected:
                SceneManager.LoadScene("");
                break;
        }
    }
}

public enum GameMode
{
    Arithmetic,
    Logic,
    NotSelected
}

public enum Difficulty
{
    Normal,
    Hard,
    NotSelected
}