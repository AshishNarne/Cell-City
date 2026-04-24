using UnityEngine;

public class PlaceMenuInFrontOfPlayer : MonoBehaviour
{
    public Transform playerCamera;
    public float distanceInFront = 2.5f;
    public float heightOffset = 0f;
    public bool facePlayer = true;

    void Start()
    {
        if (playerCamera == null) return;

        Vector3 forward = playerCamera.forward;
        forward.y = 0f;
        forward.Normalize();

        transform.position = playerCamera.position + forward * distanceInFront;
        transform.position += new Vector3(0f, heightOffset, 0f);

        if (facePlayer)
        {
            Vector3 lookDirection = transform.position - playerCamera.position;
            lookDirection.y = 0f;

            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}