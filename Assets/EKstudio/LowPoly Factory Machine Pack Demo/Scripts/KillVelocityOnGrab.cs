using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KillVelocityOnGrab : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private Rigidbody rb;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectExited.AddListener(OnRelease);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
