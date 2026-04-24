using UnityEngine;
using TMPro;

public class ShowOnProximity : MonoBehaviour
{
    public Transform player;
    public float showDistance = 12f;

    private TextMeshPro textMesh;
    private MeshRenderer meshRenderer;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        bool shouldShow = distance <= showDistance;

        if (textMesh != null)
            textMesh.enabled = shouldShow;

        if (meshRenderer != null)
            meshRenderer.enabled = shouldShow;
    }
}