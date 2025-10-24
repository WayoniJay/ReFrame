using UnityEngine;

public class OrbController : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 newPos = GetMouseWorldPos() + offset;
            transform.position = newPos;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 5f; // distance from camera
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
