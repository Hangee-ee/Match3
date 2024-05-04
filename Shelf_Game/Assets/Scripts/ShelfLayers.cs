using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfLayers : MonoBehaviour
{
    [SerializeField] private GameObject childPrefab; // Prefab of the child object
    [SerializeField] private int totalItems = 12; // Total number of items
    [SerializeField] private int rows = 3; // Number of rows
    [SerializeField] private int columns = 3; // Number of columns

    // Function to calculate the number of layers needed
    private int CalculateLayers()
    {
        return Mathf.CeilToInt((float)totalItems / (rows * columns));
    }

    // Function to instantiate children for the item slot
    private void InstantiateChildrenForItemSlot(int layers)
    {
        Debug.Log("Instantiating children for item slot...");

        // Iterate over each child slot in the item slot
        for (int i = 0; i < layers; i++)
        {
            // Calculate position for the new child slot
            Vector3 newPosition = transform.position + new Vector3(0f, i * childPrefab.transform.localScale.y, 0f);

            // Instantiate the child prefab
            GameObject newObject = Instantiate(childPrefab, newPosition, Quaternion.identity, transform);
            Debug.Log("Instantiated child at position: " + newObject.transform.position);
        }
    }

    // Example usage
    private void Start()
    {
        int layers = CalculateLayers(); // Calculate the number of layers
        InstantiateChildrenForItemSlot(layers); // Instantiate children for the item slot
    }
}
