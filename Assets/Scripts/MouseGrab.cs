using UnityEngine;

public class MouseGrab : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject grabbedObject;
    private float grabDistance = 3f;
    private float throwForce = 10f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // when left-click pressed
        {
            TryGrabObject();
        }

        if (Input.GetMouseButtonUp(0)) // when left-click released
        {
            ReleaseObject();
        }

        if (grabbedObject != null)
        {
            MoveGrabbedObject();
        }
    }

    void TryGrabObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance))
        {
            if (hit.rigidbody != null)
            {
                grabbedObject = hit.rigidbody.gameObject;
                hit.rigidbody.useGravity = false;
            }
        }
    }

    void MoveGrabbedObject()
    {
        Vector3 targetPos = mainCamera.transform.position + mainCamera.transform.forward * grabDistance;
        grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, targetPos, Time.deltaTime * 10);
    }

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.linearVelocity = mainCamera.transform.forward * throwForce;
            grabbedObject = null;
        }
    }
}
