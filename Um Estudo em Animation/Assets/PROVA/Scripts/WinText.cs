using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinText : MonoBehaviour
{

    public GameObject vitoria;
    private void Start()
    {

        vitoria.SetActive(false);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vitoria.SetActive(true);
        }
    }
}
