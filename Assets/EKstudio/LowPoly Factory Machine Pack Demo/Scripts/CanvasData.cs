using UnityEngine;
using TMPro; // Include this if you want to show the number on the UI

public class CanvasData : MonoBehaviour
{
    public int myCounter = 0;
    public TMP_Text counterDisplay;

    void Start()
    {
        // This runs the moment you press Play
        UpdateUI(); 
    }

    public void IncreaseCounter()
    {
        myCounter++;
        UpdateUI();
    }

    // A helper method so you don't have to write the same line twice
    void UpdateUI()
    {
        if (counterDisplay != null)
        {
            counterDisplay.text = myCounter.ToString();
        }
    }
}