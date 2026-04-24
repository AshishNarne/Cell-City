using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogue_text;
    public GameObject dialogue_box;
    public GameObject arrow;

    [TextArea(2, 4)]
    public string[] dialogue_lines;

    private int current_line = 0;

    void Start()
    {
        dialogue_box.SetActive(true);
        dialogue_text.text = dialogue_lines[current_line];
    }

    public void NextDialogue()
    {
        current_line++;

        if (current_line < dialogue_lines.Length)
        {
            dialogue_text.text = dialogue_lines[current_line];
        }
        else
        {
            dialogue_box.SetActive(false);
            arrow.SetActive(true);
        }
    }
}