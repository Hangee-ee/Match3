using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateObjects : MonoBehaviour
{
    public LevelScriptable level;
    public Transform[] shelves; // Reference to the shelves containing item slots

    private List<Transform>[] availableSlotsPerShelf; // List to store available item slots for each shelf

    private void Start()
    {
        FindAvailableSlots();
        SpawnItems();
    }

    private void FindAvailableSlots()
    {
        availableSlotsPerShelf = new List<Transform>[shelves.Length];

        for (int i = 0; i < shelves.Length; i++)
        {
            Transform[] itemSlots = shelves[i].GetComponentsInChildren<Transform>();
            availableSlotsPerShelf[i] = new List<Transform>();

            // Remove the shelf itself from the list
            foreach (Transform slot in itemSlots)
            {
                if (slot != shelves[i])
                {
                    availableSlotsPerShelf[i].Add(slot);
                }
            }
        }

        //Debug.LogError("Spawned slots: " + shelves.Length + " slots: " + shelves);
    }

    private void SpawnItems()
    {
        foreach (GameObject prefab in level.itemPrefabs)
        {
            SpawnPrefab(prefab, 3);
            //Debug.LogError("Spawned: " + prefab);
        }
    }

    private void SpawnPrefab(GameObject prefab, int amount)
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is null!");
            return;
        }

        int itemsSpawned = 0; // Track the number of items spawned

        while (itemsSpawned < amount && HasAvailableSlots())
        {
            int randomShelfIndex = Random.Range(0, shelves.Length);
            Transform[] slots = availableSlotsPerShelf[randomShelfIndex].ToArray();

            if (slots.Length > 0)
            {
                int randomSlotIndex = Random.Range(0, slots.Length);
                Transform selectedSlot = slots[randomSlotIndex];
                GameObject newObject = Instantiate(prefab, selectedSlot);
                newObject.transform.localPosition = Vector3.zero;

                // Set the item as a child of the slot
                newObject.transform.SetParent(selectedSlot);

                // Remove the selected slot from the list of available slots
                availableSlotsPerShelf[randomShelfIndex].RemoveAt(randomSlotIndex);

                itemsSpawned++; // Increment the number of items spawned
            }
        }

        if (itemsSpawned < amount)
        {
            Debug.LogWarning("Failed to spawn all items: " + prefab.name);
        }
    }

    private bool HasAvailableSlots()
    {
        foreach (var slots in availableSlotsPerShelf)
        {
            if (slots.Count > 0)
                return true;
        }
        return false;
    }
}