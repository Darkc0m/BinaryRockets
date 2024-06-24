using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicTutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speechText;
    [SerializeField] List<GameObject> pointingHands;

    [SerializeField] ModelRegister playerRegister;
    [SerializeField] GameObject selectedOpText, uiRegister, confirmBtn, opButtons, xorTable, xorEquation, andEquation;
    [SerializeField] Rocket rocket;
    [SerializeField] Animator resultAnimator, fadeoutAnimator, rocketAnimator;
    [SerializeField] AudioManager audioManager;
    [SerializeField] List<Button> bitBtns;

    bool isTalking = true;
    string[] steps;
    [SerializeField] int stepIndex;
    float cooldown = 2.0f;
    InterfaceRegister iRegister;
    float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        iRegister = uiRegister.GetComponent<InterfaceRegister>();
        iRegister.initRegisterWithValue(9);
        initializeSteps();
        playerRegister.initRegisterWithValue(11);
        speechText.text = steps[stepIndex];
        currentCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && isTalking && currentCooldown <= 0f) //Cambiar para movil Input.touchCount > 0
        {
            nextStep();
            if (stepIndex == 10 || stepIndex == 16) { isTalking = false; }
            currentCooldown = cooldown;
        }
        switch (stepIndex)
        {
            case 5:
                selectedOpText.SetActive(true);
                pointingHands[0].SetActive(false);
                break;
            case 6:
                uiRegister.SetActive(true);
                pointingHands[1].SetActive(false);
                break;
            case 7:
                pointingHands[0].SetActive(true);
                pointingHands[2].SetActive(false);
                break;
            case 8:
                xorTable.SetActive(true);
                break;
            case 9:
                xorEquation.SetActive(true);
                break;
            case 10:
                iRegister.recalculateFromBits();
                if (iRegister.getValue() == 12) { 
                    nextStep();
                    foreach (Button b in bitBtns)
                        b.interactable = false;
                }
                break;
            case 11:
                xorTable.SetActive(false);
                xorEquation.SetActive(false);
                pointingHands[0].SetActive(false);
                confirmBtn.SetActive(true);
                break;
            case 13:
                playerRegister.initRegisterWithValue(6);
                iRegister.initRegisterWithValue(13);
                break;
            case 15:
                opButtons.SetActive(true);
                andEquation.SetActive(true);
                pointingHands[0].SetActive(false);
                break;
            case 17:
                pointingHands[4].SetActive(false);
                pointingHands[3].SetActive(true);
                break;
            case 18:
                pointingHands[3].SetActive(false);
                break;
        }
        if (currentCooldown >= 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void clickConfirm()
    {
        switch (stepIndex)
        {
            case 11:
                resultAnimator.SetTrigger("isCorrect");
                audioManager.playCorrect();
                pointingHands[3].SetActive(false);
                selectedOpText.SetActive(false);
                pointingHands[0].SetActive(true);
                nextStep();
                confirmBtn.GetComponent<Button>().interactable = false;
                isTalking = true;
                break;
            case 17:
                andEquation.SetActive(false);
                resultAnimator.SetTrigger("isCorrect");
                audioManager.playCorrect();
                nextStep();
                StartCoroutine(endGame());
                break;
        }
    }

    public void clickAND()
    {
        if(stepIndex == 16)
        {
            confirmBtn.GetComponent<Button>().interactable = true;
            nextStep();
        }
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(2.5f);
        rocketAnimator.SetTrigger("openBase");
        yield return new WaitForSeconds(2.5f);
        rocket.launch();
        yield return new WaitForSeconds(4f);

        fadeoutAnimator.SetTrigger("EndLevel");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Main Menu");
    }

    public void nextStep()
    {
        stepIndex++;
        speechText.text = steps[stepIndex];
    }

    public void initializeSteps()
    {
        steps = new string[] { "¡Hola de nuevo! En este tutorial veremos cómo se utilizan las operaciones binarias para despegar nuestra nave.",
        "El objetivo del juego sigue siendo el mismo, llegar a un número a partir de una operación entre otros dos.",
        "En este caso ambos números serán binarios y se utilizan operadores lógicos.",
        "Antes de continuar posiciona mi marcador en una superficie plana para que puedas ver el primer número.",
        "Como puedes ver, el primer número a utilizar es el 1011.",
        "El operador lógico a utilizar aparece en la esquina superior derecha.",
        "Debes introducir el otro número en su forma binaria.",
        "En este caso el código para que la nave despegue es 0111.",
        "Recuerda la tabla de la verdad del operador XOR. El resultado es 1 si ambos operandos son distintos.",
        "Debes hallar el valor que falta para que se cumpla la igualdad.",
        "La solución es 1100. Introduce 1100 tocando los iconos para cambiar su estado.",
        "¡Genial! Pulsa el botón confirmar para realizar la operación.",
        "En el modo de juego difícil se te proporcionan los dos números y serás tú quien elija la operación a utilizar.",
        "En este caso los números a utilizar son 0110 y 1101.",
        "Ahora el código de despegue es el número 0100.",
        "Debes seleccionar un operador que haga que se cumpla la igualdad.",
        "En este caso es el operador AND. Pulsa sobre él.",
        "¡Perfecto! Pulsa el botón confirmar para realizar la operación.",
        "¡Despegamos!"};
    }
}
