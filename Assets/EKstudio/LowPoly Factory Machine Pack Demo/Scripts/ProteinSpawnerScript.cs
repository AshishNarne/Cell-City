using UnityEngine;
using TMPro;

public class ProteinSpawnerScript : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform spawnPoint;
    public float launchSpeed = 2f;
    public float spawnOffset = 0.15f;

    [Header("Spawn Timing")]
    public float spawnInterval = 2f;          // starting interval
    public float intervalDecrease = 0.2f;     // how much faster each spawn gets
    public float minimumSpawnInterval = 0.5f; // clamp so it doesn't get too fast

    public int maxCalls = 5;

    private int callCount = 0;
    private float currentSpawnInterval;
    private bool isSpawning = false;

    private string[] proteinLabels = { "M6P", "KDEL", "TMD", "UNK" };

    public void StartSpawning()
    {
        if (isSpawning) return;

        isSpawning = true;
        callCount = 0;
        currentSpawnInterval = spawnInterval;

        SpawnProtein(); // spawn first one immediately
    }

    void SpawnProtein()
    {
        Vector3 spawnPos = spawnPoint.position + spawnPoint.forward * spawnOffset;
        GameObject sphere = Instantiate(spherePrefab, spawnPos, spawnPoint.rotation);

        Transform labelTransform = sphere.transform.Find("ProteinLabel");
        if (labelTransform != null)
        {
            TMP_Text label = labelTransform.GetComponent<TMP_Text>();
            if (label != null)
            {
                int randomIndex = Random.Range(0, proteinLabels.Length);
                label.text = proteinLabels[randomIndex];
            }
        }

        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.forward * launchSpeed;
        }

        callCount++;
        Debug.Log("Spawn #" + callCount + " | Next interval: " + currentSpawnInterval);

        if (callCount >= maxCalls)
        {
            isSpawning = false;
            return;
        }

        currentSpawnInterval = Mathf.Max(minimumSpawnInterval, currentSpawnInterval - intervalDecrease);

        Invoke(nameof(SpawnProtein), currentSpawnInterval);
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnProtein));
        isSpawning = false;
    }
}