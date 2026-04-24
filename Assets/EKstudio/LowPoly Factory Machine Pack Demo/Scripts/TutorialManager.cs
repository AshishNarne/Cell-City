using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class TutorialStep
{
    [TextArea] public string title;
    [TextArea] public string body;
    [TextArea] public string subText;
    [TextArea] public string labelText;
}

public class TutorialManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI instructionTitle;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI instructionSubText;
    public TextMeshProUGUI instructionLabelText;
    public TextMeshProUGUI buttonText;
    public Button actionButton;

    public ProteinSpawnerScript proteinSpawner; // Reference to ProteinSpawnerScript

    public GameObject scoreCanvas; // Reference to ScoreCounter

    public TutorialStep[] tutorialSteps;

    private int currentStep = 0;

    void Start()
    {
        panel.SetActive(true);
        scoreCanvas.SetActive(false);

        ShowStep();
        actionButton.onClick.AddListener(OnButtonPressed);
    }

    void ShowStep()
    {
        instructionTitle.text = tutorialSteps[currentStep].title;
        instructionText.text = tutorialSteps[currentStep].body;
        instructionSubText.text = tutorialSteps[currentStep].subText;
        instructionLabelText.text = tutorialSteps[currentStep].labelText;


        if (currentStep == tutorialSteps.Length - 1)
        {
            buttonText.text = "PLAY";
        }
        else
        {
            buttonText.text = "NEXT";
        }
    }

    void OnButtonPressed()
    {
        if (currentStep < tutorialSteps.Length - 1)
        {
            currentStep++;
            ShowStep();
        }
        else
        {
            StartGame();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f; // Resume game

        // Option 1: Hide panel
        panel.SetActive(false);
        proteinSpawner.StartSpawning();

        // Option 2: Keep last instruction visible (your requirement)
        // actionButton.gameObject.SetActive(false);
        scoreCanvas.SetActive(true);
    }
}