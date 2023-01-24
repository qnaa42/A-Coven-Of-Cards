using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character_Controller_Layer;
using Assets.Scripts.Core_Layer;
using UnityEngine;

public class OnTriggerEnterStatReduce : MonoBehaviour
{
    public float movementSpeedChange = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.userManager.SubtractMovementSpeed(movementSpeedChange);
            GameManager.instance.playerManager.Character.StatsUpdate();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.userManager.AddMovementSpeed(movementSpeedChange);
            GameManager.instance.playerManager.Character.StatsUpdate();
        }
    }
}
