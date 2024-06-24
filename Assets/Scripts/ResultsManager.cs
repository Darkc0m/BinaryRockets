using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image astronautObj;
    [SerializeField] private Sprite astronautaOk;
    [SerializeField] private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        if(Score.getScore() >= 3)
        {
            audioManager.playCelebrate();
            astronautObj.sprite = astronautaOk;
        }
        scoreText.text = $"Has conseguido {Score.getScore()} puntos";
    }

    IEnumerator backToMainMenu()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Main menu");
    }

    public void backToMenu()
    {
        StartCoroutine(backToMainMenu());
    }
}
