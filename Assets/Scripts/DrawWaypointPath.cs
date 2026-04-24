using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawWaypointPath : MonoBehaviour
{
    public Transform waypointsParent;

    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();

        int count = waypointsParent.childCount;
        line.positionCount = count;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = waypointsParent.GetChild(i).position + Vector3.up * 0.2f;
            line.SetPosition(i, pos);
        }
    }
}