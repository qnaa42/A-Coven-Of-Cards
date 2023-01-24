using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character_Controller_Layer;
using Assets.Scripts.Character_Controller_Layer.Base.Data;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Character_Controller_Layer
{
    public class BaseUserManager : MonoBehaviour
    {
        private static List<UserData> global_UserDatas;

        private bool didInit { get; set; }

        private void Init()
        {
            global_UserDatas ??= new List<UserData>();

            didInit = true;
        }
        
        public void ResetUsers()
        {
            if (!didInit)
                Init();

            global_UserDatas = new List<UserData>();
        }
        
        public List<UserData> GetPlayerList()
        {
            if (global_UserDatas == null)
                Init();

            return global_UserDatas;
        }
        
        public int AddNewPlayer()
        {
            if (!didInit)
                Init();

            var newUser = new UserData
            {
                id = global_UserDatas.Count,
                playerName = "Default",
                //Movement
                movementSpeed = 7.5f,
                stableMovementSharpness = 50,
                orientationSharpness = 50,
                //Charging
                chargeSpeed = 50,
                maxChargeTime = 0.3f,
                stoppedTime = 0.3f,
                chargeCooldown = 1.5f,
                canDoubleCharge = false,
                score = 0,
                health = 100,
                clones = 6
            };

            global_UserDatas.Add(newUser);

            return newUser.id;
        }
        
        //Name
        public string GetName(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].playerName;
        }
        
        public void SetName(int id, string aName)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].playerName = name;
        }
        
        //Movement
        //Movement Speed
        public float GetMovementSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].movementSpeed;
        }
        
        public void SetMovementSpeed(int id, float aMovementSpeed)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].movementSpeed = aMovementSpeed;
        }
        
        public void AddMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].movementSpeed += anAmount;
        }
        
        public void SubtractMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].movementSpeed -= anAmount;
        }
        
        //Stable Movement Sharpness
        public float GetStableMovementSharpness(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].stableMovementSharpness;
        }
        
        public void SetStableMovementSharpness(int id, float aStableMovementSharpness)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stableMovementSharpness = aStableMovementSharpness;
        }
        
        public void AddStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stableMovementSharpness += anAmount;
        }
        
        public void SubtractStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stableMovementSharpness -= anAmount;
        }
        
        //Orientation Sharpness
        public float GetOrientationSharpness(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].orientationSharpness;
        }
        
        public void SetOrientationSharpness(int id, float anOrientationSharpness)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].orientationSharpness = anOrientationSharpness;
        }
        
        public void AddOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].orientationSharpness += anAmount;
        }
        
        public void SubtractOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].orientationSharpness -= anAmount;
        }
        
        //Charging
        //Charge Speed
        public float GetChargeSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].chargeSpeed;
        }
        
        public void SetChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeSpeed = anAmount;
        }
        
        public void AddChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeSpeed += anAmount;
        }
        
        public void SubtractChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeSpeed -= anAmount;
        }
        
        //Max Charge Time
        public float GetMaxChargeTime(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].maxChargeTime;
        }
        
        public void SetMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].maxChargeTime = anAmount;
        }
        
        public void AddMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].maxChargeTime += anAmount;
        }
        
        public void SubtractMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].maxChargeTime -= anAmount;
        }
        
        //Stopped Time
        public float GetStoppedTime(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].stoppedTime;
        }
        
        public void SetStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stoppedTime = anAmount;
        }
        
        public void AddStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stoppedTime += anAmount;
        }
        
        public void SubtractStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stoppedTime -= anAmount;
        }
        
        //Charge Cooldown
        public float GetChargeCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].chargeCooldown;
        }
        
        public void SetChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeCooldown = anAmount;
        }
        
        public void AddChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeCooldown += anAmount;
        }
        
        public void SubtractChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeCooldown -= anAmount;
        }
        
        //Can Double Charge (bool)
        public bool GetCanDoubleCharge(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].canDoubleCharge;
        }
        
        public void SetCanDoubleCharge(int id, bool aBool)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].canDoubleCharge = aBool;
        }
        
        
        //Score
        public int GetScore(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].score;
        }
        
        public void SetScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].score = anAmount;
        }
        
        public void AddScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].score += anAmount;
        }
        
        public void SubtractScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].score -= anAmount;
        }
        
        //Health
        public int GetHealth(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].health;
        }
        
        public void SetHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].health = anAmount;
        }
        
        public void AddHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].health += anAmount;
        }
        
        public void SubtractHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].health -= anAmount;
        }
        
        //Clones
        public int GetClones(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].clones;
        }
        
        public void SetClones(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].clones = anAmount;
        }
        
        public void AddClones(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].clones += anAmount;
        }
        
        public void SubtractClones(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].clones -= anAmount;
        }
    }
}
