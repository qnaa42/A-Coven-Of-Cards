using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character_Controller_Layer;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Character_Controller_Layer
{
    public class BaseUserManager : MonoBehaviour
    {
        public static List<UserData> global_userDatas;
        
        public bool didInit { get; set; }

        public void Init()
        {
            if(global_userDatas == null)
                global_userDatas = new List<UserData> ();
            
            didInit = true;
        }
        
        public void ResetUsers()
        {
            if (!didInit)
                Init();

            global_userDatas = new List<UserData>();
        }
        
        public List<UserData> GetPlayerList()
        {
            if (global_userDatas == null)
                Init();

            return global_userDatas;
        }
        
        public int AddNewPlayer()
        {
            if (!didInit)
                Init();

            UserData newUser = new UserData();

            newUser.id = global_userDatas.Count;
            newUser.playerName = "Default";
            
            //Movement
            newUser.movementSpeed = 7.5f;
            newUser.stableMovementSharpness = 50;
            newUser.orientationSharpness = 50;
            
            //Charging
            newUser.chargeSpeed = 50;
            newUser.maxChargeTime = 0.3f;
            newUser.stoppedTime = 0.3f;
            newUser.chargeCooldown = 1.5f;
            newUser.canDoubleCharge = false;

            newUser.score = 0;
            newUser.health = 100;
            newUser.clones = 6;

            global_userDatas.Add(newUser);

            return newUser.id;
        }
        
        //Name
        public string GetName(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].playerName;
        }
        
        public void SetName(int id, string aName)
        {
            if (!didInit)
                Init();

            global_userDatas[id].playerName = name;
        }
        
        //Movement
        //Movement Speed
        public float GetMovementSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].movementSpeed;
        }
        
        public void SetMovementSpeed(int id, float aMovementSpeed)
        {
            if (!didInit)
                Init();

            global_userDatas[id].movementSpeed = aMovementSpeed;
        }
        
        public void AddMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].movementSpeed += anAmount;
        }
        
        public void SubtractMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].movementSpeed -= anAmount;
        }
        
        //Stable Movement Sharpness
        public float GetStableMovementSharpness(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].stableMovementSharpness;
        }
        
        public void SetStableMovementSharpness(int id, float aStableMovementSharpness)
        {
            if (!didInit)
                Init();

            global_userDatas[id].stableMovementSharpness = aStableMovementSharpness;
        }
        
        public void AddStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].stableMovementSharpness += anAmount;
        }
        
        public void SubtractStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].stableMovementSharpness -= anAmount;
        }
        
        //Orientation Sharpness
        public float GetOrientationSharpness(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].orientationSharpness;
        }
        
        public void SetOrientationSharpness(int id, float anOrientationSharpness)
        {
            if (!didInit)
                Init();

            global_userDatas[id].orientationSharpness = anOrientationSharpness;
        }
        
        public void AddOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].orientationSharpness += anAmount;
        }
        
        public void SubtractOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].orientationSharpness -= anAmount;
        }
        
        //Charging
        //Charge Speed
        public float GetChargeSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].chargeSpeed;
        }
        
        public void SetChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].chargeSpeed = anAmount;
        }
        
        public void AddChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].chargeSpeed += anAmount;
        }
        
        public void SubtractChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].chargeSpeed -= anAmount;
        }
        
        //Max Charge Time
        public float GetMaxChargeTime(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].maxChargeTime;
        }
        
        public void SetMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].maxChargeTime = anAmount;
        }
        
        public void AddMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].maxChargeTime += anAmount;
        }
        
        public void SubtractMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].maxChargeTime -= anAmount;
        }
        
        //Stopped Time
        public float GetStoppedTime(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].stoppedTime;
        }
        
        public void SetStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].stoppedTime = anAmount;
        }
        
        public void AddStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].stoppedTime += anAmount;
        }
        
        public void SubtractStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].stoppedTime -= anAmount;
        }
        
        //Charge Cooldown
        public float GetChargeCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].chargeCooldown;
        }
        
        public void SetChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].chargeCooldown = anAmount;
        }
        
        public void AddChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].chargeCooldown += anAmount;
        }
        
        public void SubtractChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].chargeCooldown -= anAmount;
        }
        
        //Can Double Charge (bool)
        public bool GetCanDoubleCharge(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].canDoubleCharge;
        }
        
        public void SetCanDoubleCharge(int id, bool aBool)
        {
            if (!didInit)
                Init();

            global_userDatas[id].canDoubleCharge = aBool;
        }
        
        
        
        //Score
        public int GetScore(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].score;
        }
        
        public void SetScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].score = anAmount;
        }
        
        public void AddScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].score += anAmount;
        }
        
        public void SubtractScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].score -= anAmount;
        }
        
        //Health
        public int GetHealth(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].health;
        }
        
        public void SetHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].health = anAmount;
        }
        
        public void AddHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].health += anAmount;
        }
        
        public void SubtractHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].health -= anAmount;
        }
        
        //Clones
        public int GetClones(int id)
        {
            if (!didInit)
                Init();

            return global_userDatas[id].clones;
        }
        
        public void SetClones(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].clones = anAmount;
        }
        
        public void AddClones(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].clones += anAmount;
        }
        
        public void SubtractClones(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_userDatas[id].clones -= anAmount;
        }
    }
}
