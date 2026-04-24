using System.Collections.Generic;
using UnityEngine;

public class MinecartMover : MonoBehaviour
{
    [Header("State")]
    public bool canMove = true;
    public bool rideCompleted = false;

    [Header("Path")]
    public List<Transform> waypoints = new List<Transform>();
    public bool loop = true;                 // keep TRUE if your track is a loop
    public bool stopAfterOneLoop = true;     // NEW: stop after one full loop

    [Header("Motion")]
    public float speed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float arriveDistance = 0.05f;
    public Vector3 modelForwardOffsetEuler = new Vector3(0f, 90f, 0f);

    int index = 0;

    // Track laps (only used when loop=true)
    int lapsCompleted = 0;

    public void BeginRide()
    {
        rideCompleted = false;
        canMove = true;
    }

    public void ResetForNextRide()
    {
        // allow a new ride next time someone steps on
        rideCompleted = false;
        lapsCompleted = 0;
    }

    void Update()
    {
        if (!canMove) return;
        if (waypoints == null || waypoints.Count == 0) return;
        if (index < 0 || index >= waypoints.Count) index = 0;

        Transform target = waypoints[index];

        // Move
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Rotate (smooth)
        Vector3 dir = (target.position - transform.position);
        dir.y = 0f;
        if (dir.sqrMagnitude > 0.0001f)
        {
            Quaternion look = Quaternion.LookRotation(dir.normalized, Vector3.up);
            Quaternion offset = Quaternion.Euler(modelForwardOffsetEuler);
            transform.rotation = Quaternion.Slerp(transform.rotation, look * offset, rotateSpeed * Time.deltaTime);
        }

        // Advance waypoint
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= arriveDistance)
        {
            index++;

            // If not looping: stop at the last waypoint
            if (!loop)
            {
                if (index >= waypoints.Count)
                {
                    index = waypoints.Count - 1;
                    StopRide();
                }
                return;
            }

            // If looping: detect wrap back to start
            if (index >= waypoints.Count)
            {
                index = 0;
                lapsCompleted++;

                if (stopAfterOneLoop && lapsCompleted >= 1)
                    StopRide(); // stops at WP_0 after completing the loop
            }
        }
    }

    void StopRide()
    {
        canMove = false;
        rideCompleted = true;
    }
}