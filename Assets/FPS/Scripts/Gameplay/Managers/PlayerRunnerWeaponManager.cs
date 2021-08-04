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
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}