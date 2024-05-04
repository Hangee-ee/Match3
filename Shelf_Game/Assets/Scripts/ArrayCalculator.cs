using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCalculator : MonoBehaviour
{
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 3;
    [SerializeField] private int totalItems = 20;

    // Function to calculate the dimensions of the array
    public int[] CalculateArrayDimensions()
    {
        int[] dimensions = new int[3]; // Initialize array to store dimensions

        // Calculate the number of layers needed
        int layers = Mathf.CeilToInt((float)totalItems / (rows * columns));

        // Determine the dimensions based on the number of layers, rows, and columns
        dimensions[0] = rows;
        dimensions[1] = columns;
        dimensions[2] = layers;

        return dimensions;
    }

    // Example usage
    private void Start()
    {
        // Calculate dimensions
        int[] arrayDimensions = CalculateArrayDimensions();

        // Print dimensions
        Debug.Log("Array dimensions: " + arrayDimensions[0] + "x" + arrayDimensions[1] + "x" + arrayDimensions[2]);
    }
}