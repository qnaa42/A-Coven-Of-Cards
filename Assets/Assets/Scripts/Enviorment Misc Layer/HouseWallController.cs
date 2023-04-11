using System;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Enviorment_Misc_Layer
{
    public class HouseWallController : MonoBehaviour
    {
        // State enumeration
        public enum HouseState
        {
            PlayerOutside,
            PlayerInside
        }

        // Expose the current state
        [SerializeField] private HouseState currentHouseState;
        public HouseState CurrentHouseState => currentHouseState;

        [SerializeField] private GameObject OutsideWall;
        [SerializeField] private GameObject[] InsideWalls;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            currentHouseState = HouseState.PlayerInside;

            OutsideWall.SetActive(false);
            foreach (var insideWall in InsideWalls)
            {
                insideWall.SetActive(true);
            }
            var houseManager = this.GetComponentInParent<HouseManager>();
            GameManager.instance.userManager.SubtractGlobalMovementSpeedMultiplier(houseManager.insideHouseMovementMultiplier);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            currentHouseState = HouseState.PlayerOutside;

            OutsideWall.SetActive(true);
            foreach (var insideWall in InsideWalls)
            {
                insideWall.SetActive(false);
            }
            var houseManager = this.GetComponentInParent<HouseManager>();
            GameManager.instance.userManager.AddGlobalMovementSpeedMultiplier(houseManager.insideHouseMovementMultiplier);
        }
    }
}
