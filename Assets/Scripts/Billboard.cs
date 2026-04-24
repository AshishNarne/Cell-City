using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target; // drag Main Camera here

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 dir = transform.position - target.position;
        dir.y = 0f; // keep upright (no tilting)
        if (dir.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
    }
}