using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BinaryTutorialManager : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Image blackboardImage;
    [SerializeField] List<Sprite> imageSteps;
    [SerializeField] string nextLevel;
    [SerializeField] Animator fadeoutAnimator;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextTutorialImage();
    }

    public void nextTutorialImage()
    {
        if(index == imageSteps.Count)
        {
            StartCoroutine(LoadNextLevel());
        }
        else
        {
            continueButton.interactable = false;
            blackboardImage.sprite = imageSteps[index];
            index++;
            StartCoroutine(stepDelay());
        }
    }

    IEnumerator stepDelay()
    {
        yield return new WaitForSeconds(2f);
        continueButton.interactable = true;
    }

    IEnumerator LoadNextLevel()
    {
        fadeoutAnimator.SetTrigger("EndLevel");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevel);
    }
}
