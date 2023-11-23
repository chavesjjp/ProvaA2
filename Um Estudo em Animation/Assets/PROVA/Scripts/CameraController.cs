using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    public float tempo;
    bool correndo;
    void Start()
    {
        tempo = 1;
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            correndo = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            correndo = false;
        if (correndo)
        {
            tempo += tempo * Time.deltaTime;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.3f;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1f;
            if (tempo > 3f)
            {
                vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
            }
        }
        if (!correndo)
        {
            tempo = 1;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
        }
    }
}
