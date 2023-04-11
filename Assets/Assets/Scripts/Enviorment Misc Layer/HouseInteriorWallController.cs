using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Enviorment_Misc_Layer
{
    public class HouseInteriorWallController : MonoBehaviour
    {
        public GameObject[] HighWalls;
        public GameObject[] LowWalls;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            var houseManager = this.GetComponentInParent<HouseManager>();
            if(houseManager.HouseWallControllers.CurrentHouseState== HouseWallController.HouseState.PlayerOutside) return;
            foreach (var highWall in HighWalls)
            {
                highWall.SetActive(false);
            }
            foreach (var lowWall in LowWalls)
            {
                lowWall.SetActive(true);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            var houseManager = this.GetComponentInParent<HouseManager>();
            if(houseManager.HouseWallControllers.CurrentHouseState== HouseWallController.HouseState.PlayerOutside) return;
            foreach (var highWall in HighWalls)
            {
                highWall.SetActive(true);
            }
            foreach (var lowWall in LowWalls)
            {
                lowWall.SetActive(false);
            }
        }
    }
}
