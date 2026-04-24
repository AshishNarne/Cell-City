using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    public Shrink transition;
    public ParticleSystem hitParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transition.TriggerSequence();
            hitParticles.Play();
        }
    }
}