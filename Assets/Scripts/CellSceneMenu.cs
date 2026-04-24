using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CellSceneMenu : MonoBehaviour
{
    [Header("References")]
    public Transform xrOrigin;
    public Transform boatSpawnPoint;
    public GameObject pathLineObject;
    public Toggle motionGuidanceToggle;

    [Header("Protein Sorting")]
    public string proteinSortingSceneName;

    public void Start()
    {
        if (motionGuidanceToggle != null && pathLineObject != null)
        {
            motionGuidanceToggle.isOn = pathLineObject.activeSelf;
            motionGuidanceToggle.onValueChanged.AddListener(SetMotionGuidance);
        }
    }

    public void BoatTourTeleport()
    {
        if (xrOrigin == null || boatSpawnPoint == null) return;

        xrOrigin.position = boatSpawnPoint.position;
        xrOrigin.rotation = boatSpawnPoint.rotation;
    }

    public void LoadProteinSorting()
    {
        if (!string.IsNullOrEmpty(proteinSortingSceneName))
        {
            SceneManager.LoadScene(proteinSortingSceneName);
        }
    }

    public void SetMotionGuidance(bool enabled)
    {
        if (pathLineObject != null)
        {
            pathLineObject.SetActive(enabled);
        }
    }
}