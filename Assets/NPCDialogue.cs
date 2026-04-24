using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    string[] lines = {
        "Welcome to Cell City!",
        "Please examine the microscope.",
        "Use your controller to interact with it.",
        "Good luck with your experiment!"
    };

    int currentLine = 0;

    void OnMouseDown()
    {
        currentLine++;

        if (currentLine >= lines.Length)
            currentLine = 0;

        dialogueText.text = lines[currentLine];
    }
}