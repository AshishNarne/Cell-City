using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProteinMover : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 direction = Vector3.forward;

    private Rigidbody rb;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private bool isHeld = false;
    bool hasBeenDropped = false;

    // Make sure component is able to listen for grabbing
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grab.selectEntered.AddListener(_ => isHeld = true);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
        hasBeenDropped = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


}
