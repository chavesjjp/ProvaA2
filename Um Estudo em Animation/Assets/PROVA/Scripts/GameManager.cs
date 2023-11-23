using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public UnityEvent camShakeRun;
    // public bool correndo;
    public static GameManager instance;
    public UnityEvent atirar;
    public UnityEvent morreu;
    public UnityEvent detectado;
    public UnityEvent danoEnemy;
    bool reiniciar = false;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void Update()
    {
        if (reiniciar == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void Atirar()
    {
        atirar.Invoke();
        Debug.Log("Tiro Invocado");
    }
    public void Morte()
    {
        morreu.Invoke();
        reiniciar = true;
    }
    public void Detectado()
    {
        detectado.Invoke();
        Debug.Log("Detectou");
    }
    public void EnemyDano()
    {
        danoEnemy.Invoke();
    }

}
