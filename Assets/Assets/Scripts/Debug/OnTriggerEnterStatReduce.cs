using Assets.Scripts.Core_Layer;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OnTriggerEnterStatReduce : MonoBehaviour
    {
        public float movementSpeedChange = 5;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.userManager.SubtractMeleeMovementSpeed(movementSpeedChange);
                GameManager.instance.playerManager.Character.StatsUpdate();
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.userManager.AddMeleeMovementSpeed(movementSpeedChange);
                GameManager.instance.playerManager.Character.StatsUpdate();
            }
        }
    }

