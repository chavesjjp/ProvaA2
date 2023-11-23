using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;
    public Transform raycastOrigin;
    public float maxDistance;
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        ray.origin = raycastOrigin.position;
        ray.direction = raycastOrigin.forward;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Player"))
                    GameManager.instance.Detectado();
                else
                    Debug.Log("Parede");
            }

        }
    }
}
