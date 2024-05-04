using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPrefab : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Reference to the prefab you want to instantiate

    void Start()
    {
        // Check if the prefab is assigned
        if (prefabToInstantiate != null)
        {
            // Instantiate the prefab and set its parent to the current GameObject
            GameObject newObject = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("Prefab to instantiate is not assigned!");
        }
    }
}

