using System;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay.Level
{
    public class FinishZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player reached the finish zone");
                EventManager.Broadcast(Events.FinishReachedEvent);
            }
        }
    }
}