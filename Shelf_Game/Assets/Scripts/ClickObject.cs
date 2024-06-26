using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClickObject : MonoBehaviour
{
    public UnityEvent onClick;

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is this GameObject
                if (hit.collider.gameObject == gameObject)
                {
                    // Invoke onClick event
                    onClick.Invoke();
                }
            }
        }
    }
}
