using UnityEngine;
using TMPro;

public class DeleteProteinOnBoxEnter : MonoBehaviour
{
    public string boxType;
    public CanvasData canvasData;

    private void OnTriggerEnter(Collider other)
    {
        // You can use a specific tag to ensure only certain objects are destroyed

        if (other.CompareTag("SortingProtein"))
        {
            TMP_Text check = other.GetComponentInChildren<TMP_Text>();
            string label = check.text;

            if (boxType == label)
            {
                canvasData.IncreaseCounter();
            }

            Destroy(other.gameObject); 
        }
    }
}
