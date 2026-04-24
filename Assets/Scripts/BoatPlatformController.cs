using UnityEngine;

public class BoatPlatformController : MonoBehaviour
{
    public Transform playerRoot;   // XR Origin (VR)
    public MinecartMover mover;    // MinecartMover on Fisher_Boat

    Transform originalParent;
    int riders = 0;

    void Start()
    {
        if (mover != null)
            mover.canMove = false; // start stopped
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerRoot == null || mover == null) return;
        if (!other.transform.IsChildOf(playerRoot) && other.transform != playerRoot) return;

        riders++;
        if (riders != 1) return;

        // If the previous ride completed, allow a fresh ride only on re-entry
        if (mover.rideCompleted)
            mover.ResetForNextRide();

        originalParent = playerRoot.parent;
        playerRoot.SetParent(mover.transform, true);

        mover.BeginRide();
    }

    void OnTriggerExit(Collider other)
    {
        if (playerRoot == null || mover == null) return;
        if (!other.transform.IsChildOf(playerRoot) && other.transform != playerRoot) return;

        riders = Mathf.Max(0, riders - 1);
        if (riders != 0) return;

        playerRoot.SetParent(originalParent, true);

        // Stop moving when they leave (even mid-ride)
        mover.canMove = false;
    }
}