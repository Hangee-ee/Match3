using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public CanvasGroup overlayGroup;
    public Transform backCameraTransform;
    public Transform targetCameraTransform;
    public float transitionTime = 1f;
    public float targetCameraSize = 5f;
    public float backCameraSize = 10f;

    private float initialCameraSize;

    void Start()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("Canvas Group is not assigned!");
            return;
        }

        if (overlayGroup == null)
        {
            Debug.LogError("Canvas Group is not assigned!");
            return;
        }

        if (targetCameraTransform == null)
        {
            Debug.LogError("Target Camera Transform is not assigned!");
            return;
        }

        initialCameraSize = Camera.main.orthographicSize;
    }

    public void StartTransition()
    {
        StartCoroutine(TransitionCoroutine());
    }

    public void BackTransition()
    {
        Debug.Log("BackTransition");
        StartCoroutine(BackTransitionCoroutine());
    }

    IEnumerator TransitionCoroutine()
    {
        float startTime = Time.time;
        Vector3 initialCameraPosition = Camera.main.transform.position;
        while (Time.time - startTime < transitionTime)
        {
            float progress = (Time.time - startTime) / transitionTime;

            // Lower alpha on canvas group
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, progress);

            // Change camera size
            Camera.main.orthographicSize = Mathf.Lerp(initialCameraSize, targetCameraSize, progress);

            // Move camera towards the target position
            Camera.main.transform.position = Vector3.Lerp(initialCameraPosition, targetCameraTransform.position, progress);

            overlayGroup.alpha = Mathf.Lerp(0f, 1f, progress);

            yield return null;
        }

        canvasGroup.alpha = 0f;
        overlayGroup.alpha = 1f;
        Camera.main.orthographicSize = targetCameraSize;
        Camera.main.transform.position = targetCameraTransform.position;
    }

    IEnumerator BackTransitionCoroutine()
    {
        float startTime = Time.time;
        Vector3 initialCameraPosition = Camera.main.transform.position;
        float initialCameraSize = Camera.main.orthographicSize;

        while (Time.time - startTime < transitionTime)
        {
            float progress = (Time.time - startTime) / transitionTime;

            canvasGroup.alpha = Mathf.Lerp(0f, 1f, progress);

            // Change camera size
            Camera.main.orthographicSize = Mathf.Lerp(targetCameraSize, backCameraSize, progress);

            // Move camera towards the original position
            Camera.main.transform.position = Vector3.Lerp(initialCameraPosition, backCameraTransform.position, progress);

            overlayGroup.alpha = Mathf.Lerp(1f, 0f, progress);

            yield return null;
        }

        // Ensure final state
        canvasGroup.alpha = 1f;
        overlayGroup.alpha = 0f;
        Camera.main.orthographicSize = backCameraSize;
        Camera.main.transform.position = backCameraTransform.position;
    }
}