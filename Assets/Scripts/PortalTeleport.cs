using System.Security.Cryptography;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform targetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            other.transform.position = targetPosition.position;
        }
    }
    
  
}
