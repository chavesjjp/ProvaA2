using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private float aimDuration = 0.3f;
    Camera mainCamera;
    public Rig aimLayer;
    RayCastWeapon weapon;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RayCastWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
        if (Input.GetMouseButton(1))
        {
            aimLayer.weight += Time.deltaTime / aimDuration;
        }
        else
        {
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }
        if (Input.GetButton("Fire2") && Input.GetButtonDown("Fire1"))
        {
            GameManager.instance.Atirar();
        }
    }
}
