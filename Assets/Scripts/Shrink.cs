using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;

public class Shrink : MonoBehaviour
{
    [Header("Dependencies")]
    public CanvasGroup fadeCanvasGroup;
    public Camera mainCamera;
    public ContinuousMoveProvider moveProvider;
    public Transform suckTarget;

    [Header("Settings")]
    public string sceneToLoad;
    public float transitionDuration = 2.0f;
    public float targetScale = 0.01f;
    public AnimationCurve movementCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void TriggerSequence()
    {
        if (suckTarget != null)
        {
            StartCoroutine(TransitionRoutine());
        }
    }

    private IEnumerator TransitionRoutine()
    {
        if (moveProvider != null) moveProvider.enabled = false;
        
        Vector3 initialScale = transform.localScale;
        Vector3 endScale = Vector3.one * targetScale;
        Vector3 initialPosition = transform.position;
        float initialNearClip = mainCamera.nearClipPlane; 
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            float curveT = movementCurve.Evaluate(t);

            transform.localScale = Vector3.Lerp(initialScale, endScale, t);
            transform.position = Vector3.Lerp(initialPosition, suckTarget.position, curveT);
            mainCamera.nearClipPlane = Mathf.Lerp(initialNearClip, 0.01f, t);
            
            if (fadeCanvasGroup != null)
            {
                fadeCanvasGroup.alpha = t;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
        transform.position = suckTarget.position;
        if (fadeCanvasGroup != null) fadeCanvasGroup.alpha = 1f;

        SceneManager.LoadScene(sceneToLoad);
    }
}