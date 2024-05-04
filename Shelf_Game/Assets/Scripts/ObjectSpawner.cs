using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab; // The prefab you want to spawn
    public GameObject shelf; // Reference to the shelf GameObject

    void Start()
    {
        if (shelf != null)
        {
            Transform[] itemSlots = shelf.GetComponentsInChildren<Transform>();

            if (itemSlots.Length > 0)
            {
                foreach (Transform slot in itemSlots)
                {
                    if (slot != shelf.transform) // Skip the shelf itself
                    {
                        // Spawn the objects
                        GameObject firstObject = Instantiate(prefab, slot.position, Quaternion.identity);
                        firstObject.transform.SetParent(slot); // Set the parent to the item slot
                        firstObject.SetActive(true); // Activate the first object

                        for (int i = 1; i < 3; i++)
                        {
                            Vector3 newPosition = slot.position + new Vector3(i * 0.5f, 0, 0);

                            GameObject newObj = Instantiate(prefab, newPosition, Quaternion.identity);
                            newObj.transform.SetParent(slot); // Set the parent to the item slot
                            newObj.SetActive(false); // Deactivate the other objects
                        }
                    }
                }
            }
            else
            {
                Debug.LogWarning("No item slots found in the shelf!");
            }
        }
        else
        {
            Debug.LogWarning("Shelf reference is not set!");
        }
    }
}
