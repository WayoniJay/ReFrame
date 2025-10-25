using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            Debug.Log("Orb entered the portal!");
            // You can add glow, teleport, or score logic here
        }
    }
}
