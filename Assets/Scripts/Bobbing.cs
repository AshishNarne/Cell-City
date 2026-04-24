using UnityEngine;

public class Bobbing : MonoBehaviour {
    public float speed = 5f;
    public float height = 0.5f;
    private Vector3 startPos;

    void Start() {
        // Record the starting position to oscillate around it
        startPos = transform.position;
    }

    void Update() {
        // Calculate new Y position
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
