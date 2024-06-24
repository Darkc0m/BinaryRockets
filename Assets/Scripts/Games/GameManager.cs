using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BaseGame gameType;
    [SerializeField] private Rocket rocket;
    [SerializeField] private Animator resultAnimator, fadeoutAnimator, rocketAnimator, astronautAnimator;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private int rounds;

    private void Start()
    {
        Score.resetScore();
        gameType.startGame();
    }

    public void solveGame()
    {
        gameType.solve();
        StartCoroutine(solveResults());
    }

    IEnumerator solveResults()
    {
        gameType.disableBtn();

        if (gameType.isGoalReached())
        {
            resultAnimator.SetTrigger("isCorrect");
            audioManager.playCorrect();
            Score.increaseScore();
        }
        else
        {
            audioManager.playWrong();
            resultAnimator.SetTrigger("isWrong");
        }

        yield return new WaitForSeconds(2f);

        if (--rounds > 0)
        {
            gameType.enableBtn();
            gameType.startGame();
        }
        else
        {
            StartCoroutine(endGame());
            Debug.Log($"Se acabo tienes: puntos {Score.getScore()}");
        }
    }

    IEnumerator endGame()
    {
        if (Score.getScore() > 0)
        {
            rocketAnimator.SetTrigger("openBase");
            astronautAnimator.SetTrigger("LaunchRocket");
            yield return new WaitForSeconds(2.5f);
            rocket.launch();
            yield return new WaitForSeconds(4f);
        }

        fadeoutAnimator.SetTrigger("EndLevel");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Results");
    }

    IEnumerator backToMainMenu()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Main menu");
    }

    public void backToMenu()
    {
        StartCoroutine(backToMainMenu());
    }
}
