using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectGate : MonoBehaviour
{
    // Array to hold the objects that will be hidden/shown
    public GameObject[] objectsToToggle;

    // Reference to the AR Camera - will be found automatically if not set
    [SerializeField] private Camera arCamera;

    // Flag to track the current visibility state
    private bool objectsVisible = true;

    private void Start()
    {
        // If no camera is assigned, try to find the AR camera
        if (arCamera == null)
        {
            arCamera = FindObjectOfType<ARSessionOrigin>()?.camera;
            if (arCamera == null)
            {
                arCamera = Camera.main;
            }
        }

        // Make sure all objects are initially visible
        SetObjectsVisibility(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the AR camera
        if (other.transform == arCamera.transform)
        {
            // Toggle object visibility every time camera enters
            ToggleObjectVisibility();
        }
    }

    // Method to toggle visibility of all selected objects
    private void ToggleObjectVisibility()
    {
        objectsVisible = !objectsVisible;
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(objectsVisible);
            }
        }
    }

    // Method to explicitly set visibility of all selected objects
    private void SetObjectsVisibility(bool visible)
    {
        objectsVisible = visible;
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(visible);
            }
        }
    }
}