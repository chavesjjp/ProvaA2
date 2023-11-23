using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;


    [SerializeField] private float velocidade;
    private float velocidadeBase;
    [SerializeField] private float velocidadeRun;
    [SerializeField] private float gravityValue;
    [SerializeField] private float jumpForce;
    private bool groundedPlayer;
    static public bool run;
    Vector2 input;
    void Start()
    {
        velocidadeBase = velocidade;
        run = false;
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Police"))
        {
            Destroy(gameObject);
            GameManager.instance.Morte();
        }
    }
}
