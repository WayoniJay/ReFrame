using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class Throwable : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    private Vector3 lastPosition;
    private Vector3 velocity;

    public float throwForceMultiplier = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isHeld)
        {
            // Make object follow the mouse in front of camera
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2f; // distance from camera
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Calculate throw direction
            velocity = (worldPos - lastPosition) / Time.deltaTime;
            lastPosition = worldPos;

            // Move smoothly
            rb.MovePosition(worldPos);

            // Release on mouse up
            if (Input.GetMouseButtonUp(0))
            {
                ThrowObject();
            }
        }
    }

    void OnMouseDown()
    {
        isHeld = true;
        rb.useGravity = false;
        rb.isKinematic = false;
        lastPosition = transform.position;
    }

    void ThrowObject()
    {
        isHeld = false;
        rb.useGravity = true;

        rb.AddForce(velocity * throwForceMultiplier, ForceMode.Impulse);
    }
}
