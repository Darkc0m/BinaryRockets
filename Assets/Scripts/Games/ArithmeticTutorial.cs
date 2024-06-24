using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArithmeticTutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speechText;
    [SerializeField] List<GameObject> pointingHands;

    [SerializeField] ModelRegister playerRegister;
    [SerializeField] GameObject selectedOpText, numberSelector, uiRegister, confirmBtn;
    [SerializeField] Rocket rocket;
    [SerializeField] Animator resultAnimator, fadeoutAnimator, rocketAnimator;
    [SerializeField] AudioManager audioManager;

    bool isTalking = true;
    string[] steps;
    int stepIndex;
    float cooldown = 2.0f;
    NumberSelector selector;
    [SerializeField] float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        selector = numberSelector.GetComponent<NumberSelector>();
        uiRegister.GetComponent<InterfaceRegister>().initRegisterWithValue(6);
        initializeSteps();
        playerRegister.initRegisterWithValue(5);
        speechText.text = steps[stepIndex];
        currentCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && isTalking && currentCooldown <= 0f) //Cambiar para movil
        {
            nextStep();
            if(stepIndex == 9) { isTalking = false; }
            currentCooldown = cooldown;
        }
        switch (stepIndex)
        {
            case 5:
                selectedOpText.SetActive(true);
                pointingHands[0].SetActive(false);
                pointingHands[1].SetActive(true);
                break;
            case 6:
                numberSelector.SetActive(true);
                pointingHands[1].SetActive(false);
                pointingHands[2].SetActive(true);
                break;
            case 7:
                uiRegister.SetActive(true);
                numberSelector.SetActive(false);
                pointingHands[3].SetActive(true);
                break;
            case 8:
                uiRegister.SetActive(false);
                numberSelector.SetActive(true);
                break;
            case 9:
                if (selector.getValue() == 6){ nextStep(); selector.disable(); }
                break;
            case 10:
                pointingHands[2].SetActive(false);
                confirmBtn.SetActive(true);
                pointingHands[4].SetActive(true);
                break;
        }
        if (currentCooldown >= 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void clickConfirm()
    {
        pointingHands[4].SetActive(false);
        resultAnimator.SetTrigger("isCorrect");
        audioManager.playCorrect();
        nextStep();
        confirmBtn.GetComponent<Button>().interactable = false;
        StartCoroutine(endGame());
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
        steps = new string[] { "¡Hola, soy Astro, el comandante de esta misión! En este tutorial te enseñaré las bases del juego.",
        "Para empezar a jugar coloca mi marcador sobre una superficie plana y apunta hacia él con la cámara de tu dispositivo.",
        "Podrás ver unas cajas con energía que representan un número binario, donde verde y rojo son 1 y 0 respectivamente.",
        "Tu objetivo será que esas cajas tomen un valor que yo te diré a partir de una suma o una resta.",
        "El número es el 0101, o 5 en el sistema decimal.",
        "La operación que debes realizar viene indicada en la esquina superior derecha.",
        "Debes elegir el otro número con el que operar en el selector de números.",
        "En el nivel difícil deberás introducir el valor de forma binaria, en vez de decimal.",
        "El número de las cajas y el número que introduzcas se sumarán entre ellos.",
        "En esta ocasión el código de despegue es 11. Introduce un valor para que al sumarle 5 obtengas ese resultado.",
        "¡Perfecto! Una vez introducido el número correcto pulsa el botón \"confirmar\" para realizar la operación.",
        "¡Despegamos!"};
    }
}
