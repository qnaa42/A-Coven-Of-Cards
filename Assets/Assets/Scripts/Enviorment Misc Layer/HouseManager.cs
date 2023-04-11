using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Enviorment_Misc_Layer
{
    public class HouseManager : MonoBehaviour
    {
        public HouseWallController HouseWallControllers;
        public HouseInteriorWallController HouseInteriorWallController;
        
        
        public float insideHouseMovementMultiplier = 0.5f;
    }
}
