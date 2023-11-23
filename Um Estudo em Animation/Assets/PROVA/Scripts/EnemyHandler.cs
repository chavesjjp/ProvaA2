using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHandler : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] destinos;
    int numeroDestino;
    Vector3 target;
    bool isHumanoid;
    public Transform player;
    public EnemyScriptable vida;
    public int vidaLocal;
    private void Start()
    {
        isHumanoid = false;
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        vidaLocal = vida.vida;
    }
    void Update()
    {
        if (agent.agentTypeID == 0)
            isHumanoid = true;
        switch (isHumanoid)
        {
            case true:
                agent.SetDestination(player.position);
                break;
            case false:
                if (Vector3.Distance(transform.position, target) < 1)
                {
                    UpdateNumeroDestino();
                    UpdateDestination();
                }
                break;
        }

    }
    void UpdateDestination()
    {
        target = destinos[numeroDestino].position;
        agent.SetDestination(target);
    }
    void UpdateNumeroDestino()
    {
        numeroDestino++;
        if (numeroDestino == destinos.Length)
        {
            numeroDestino = 0;
        }
    }
    public void AgentType()
    {
        agent.agentTypeID = 0;
    }

    public void DanoPistola()
    {
        this.vidaLocal--;
        if (this.vidaLocal <= 0)
            GameObject.Destroy(this.gameObject);
    }

}
