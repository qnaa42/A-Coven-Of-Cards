using Assets.Scripts.Core_Layer;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OnTriggerEnterStatReduce : MonoBehaviour
    {
        public float movementMultiplier = 0.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.userManager.SetGlobalMovementSpeedMultiplier(movementMultiplier);
                
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.userManager.SetGlobalMovementSpeedMultiplier(1f);
                
            }
        }
    }

