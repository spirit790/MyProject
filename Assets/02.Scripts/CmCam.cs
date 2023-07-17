using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CmCam : MonoBehaviour
{
    public GameObject player;
    public Vector3 followOffset;
    public Quaternion lookAtRotation;

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null && virtualCamera != null)
        {
            virtualCamera.transform.position = player.transform.position + followOffset;

            virtualCamera.transform.rotation = lookAtRotation;
        }
    }
}
