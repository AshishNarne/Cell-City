using UnityEngine;

public class ProteinDisappear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float destroyZ = 8f;

    void Update()
    {
        if (transform.position.z > destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
