using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class PlayerRunnerWeaponManager : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    PlayerInputHandler m_InputHandler;
    public Camera PlayerCamera;

    private void Start()
    {
        m_InputHandler = GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        // m_InputHandler.GetFireInputDown(),
        // m_InputHandler.GetFireInputHeld(),
        // m_InputHandler.GetFireInputReleased()
        if (m_InputHandler.GetFireInputDown())
        {
            RaycastHit hit;
            var playerCameraTransform = PlayerCamera.transform;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, 50f))
            {
                if (Vector3.Distance(playerCameraTransform.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(playerCameraTransform.position + (playerCameraTransform.forward * 30));
            }
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}