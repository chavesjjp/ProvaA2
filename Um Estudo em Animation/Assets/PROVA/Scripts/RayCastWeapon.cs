using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public ParticleSystem fogoArma;
    public Transform raycastOrigin;

    Ray ray;
    RaycastHit hitInfo;

    [SerializeField] int dano;
    EnemyHandler inimigo;

    public void StartFiring()
    {
        isFiring = true;
        fogoArma.Emit(1);

        ray.origin = raycastOrigin.position;
        ray.direction = raycastOrigin.forward;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("Police"))
            {
                Collider colliderInimigo = hitInfo.collider;
                EnemyHandler enemy = colliderInimigo.GetComponent<EnemyHandler>();
                if (enemy != null)
                {
                    enemy.DanoPistola();
                }
            }

        }
    }
    public void StopFiring()
    {
        isFiring = false;
    }
}
