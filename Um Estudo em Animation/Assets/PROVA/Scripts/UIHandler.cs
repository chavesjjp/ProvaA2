using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject textoMorte;
    public void MorreuText()
    {
        textoMorte.SetActive(true);
    }
}
