using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveSurface : MonoBehaviour
{
    public Transform doorTransform; // Reference to the door's Transform component
    public float movementAmount = 1.0f; // Amount to move the door along its Z-axis
    private bool isDoorOpen = false;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    public void ToggleDoorOpen()
    {
        if (!isDoorOpen)
        {
            // Move the door along its Z-axis by the specified amount
            Vector3 newPosition = doorTransform.position + doorTransform.forward * movementAmount;
            doorTransform.position = newPosition;
        }
        else
        {
            // Move the door back to its original position
            Vector3 originalPosition = doorTransform.position - doorTransform.forward * movementAmount;
            doorTransform.position = originalPosition;
        }

        // Toggle the door state
        isDoorOpen = !isDoorOpen;
    }
}
