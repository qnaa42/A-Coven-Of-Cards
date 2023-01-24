using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core_Layer;
using UnityEngine;
using Assets.Scripts.Character_Controller_Layer;
namespace Assets.Scripts.Character_Controller_Layer

{
    public class UserStatsManager : MonoBehaviour
    {
        public BaseUserManager _myDataManager;

        private int _myId { get; set; }
        private bool didInit { get; set; }
        
        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            Debug.Log("Init Player Data Controller");
            SetupDataManager();
            didInit = true;
        }
        
        public virtual void SetPlayerDetails(int anID)
        {
            // this function can be used by a game manager to pass in details from the player list, such as
            // this players ID or perhaps you could override this in the future to add avatar support, load outs or
            // special abilities etc?
            _myId = anID;
        }

        protected virtual void SetupDataManager()
        {
            // if a player manager is not set in the editor, let's try to find one
            if (_myDataManager == null)
                _myDataManager = GetComponent<BaseUserManager>();

            if (_myDataManager == null)
                _myDataManager = gameObject.AddComponent<BaseUserManager>();

            if (_myDataManager == null)
                _myDataManager = GetComponent<BaseUserManager>();
        }
        
        //Name
        public string GetName()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetName(_myId);
        }
        
        public virtual void SetName(string aName)
        {
            if (!didInit)
                Init();

            _myDataManager.SetName(_myId, aName);
        }
        
        //Movement
        //Movement Speed
        public float GetMeleeMovementSpeed()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetMeleeMovementSpeed(_myId);
        }
        
        public virtual void SetMeleeMovementSpeed(float aMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetMeleeMovementSpeed(_myId, aMovementSpeed);
        }
        
        public virtual void AddMeleeMovementSpeed(float aMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddMeleeMovementSpeed(_myId, aMovementSpeed);
        }
        
        public virtual void SubtractMeleeMovementSpeed(float aMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractMeleeMovementSpeed(_myId, aMovementSpeed);
        }
        
        //Casting Movement Speed
        public float GetCastingMovementSpeed()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetCastingMovementSpeed(_myId);
        }
        
        public virtual void SetCastingMovementSpeed(float aCastingMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetCastingMovementSpeed(_myId, aCastingMovementSpeed);
        }
        
        public virtual void AddCastingMovementSpeed(float aCastingMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddCastingMovementSpeed(_myId, aCastingMovementSpeed);
        }
        
        public virtual void SubtractCastingMovementSpeed(float aCastingMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractCastingMovementSpeed(_myId, aCastingMovementSpeed);
        }
        
        //Stable Movement Sharpness
        public float GetStableMovementSharpness()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetStableMovementSharpness(_myId);
        }
        
        public virtual void SetStableMovementSharpness(float aStableMovementSharpness)
        {
            if (!didInit)
                Init();

            _myDataManager.SetStableMovementSharpness(_myId, aStableMovementSharpness);
        }
        
        public virtual void AddStableMovementSharpness(float aStableMovementSharpness)
        {
            if (!didInit)
                Init();

            _myDataManager.AddStableMovementSharpness(_myId, aStableMovementSharpness);
        }
        
        public virtual void SubtractStableMovementSharpness(float aStableMovementSharpness)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractStableMovementSharpness(_myId, aStableMovementSharpness);
        }
        
        //Orientation Sharpness
        public float GetOrientationSharpness()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetOrientationSharpness(_myId);
        }
        
        public virtual void SetOrientationSharpness(float aOrientationSharpness)
        {
            if (!didInit)
                Init();

            _myDataManager.SetOrientationSharpness(_myId, aOrientationSharpness);
        }
        
        public virtual void AddOrientationSharpness(float aOrientationSharpness)
        {
            if (!didInit)
                Init();

            _myDataManager.AddOrientationSharpness(_myId, aOrientationSharpness);
        }
        
        public virtual void SubtractOrientationSharpness(float aOrientationSharpness)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractOrientationSharpness(_myId, aOrientationSharpness);
        }
        
        //Light Attack
        //Light Attack Duration
        public float GetLightAttackDuration()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetLightAttackDuration(_myId);
        }
        
        public virtual void SetLightAttackDuration(float aLightAttackDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SetLightAttackDuration(_myId, aLightAttackDuration);
        }
        
        public virtual void AddLightAttackDuration(float aLightAttackDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.AddLightAttackDuration(_myId, aLightAttackDuration);
        }
        
        public virtual void SubtractLightAttackDuration(float aLightAttackDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractLightAttackDuration(_myId, aLightAttackDuration);
        }
        
        //Light Attack Movement Speed Multiplier
        public float GetLightAttackMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetLightAttackMovementSpeedMultiplier(_myId);
        }
        
        public virtual void SetLightAttackMovementSpeedMultiplier(float aLightAttackMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myDataManager.SetLightAttackMovementSpeedMultiplier(_myId, aLightAttackMovementSpeedMultiplier);
        }
        
        public virtual void AddLightAttackMovementSpeedMultiplier(float aLightAttackMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myDataManager.AddLightAttackMovementSpeedMultiplier(_myId, aLightAttackMovementSpeedMultiplier);
        }
        
        public virtual void SubtractLightAttackMovementSpeedMultiplier(float aLightAttackMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractLightAttackMovementSpeedMultiplier(_myId, aLightAttackMovementSpeedMultiplier);
        }
        
        //Light Attack Cooldown
        public float GetLightAttackCooldown()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetLightAttackCooldown(_myId);
        }
        
        public virtual void SetLightAttackCooldown(float aLightAttackCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.SetLightAttackCooldown(_myId, aLightAttackCooldown);
        }
        
        public virtual void AddLightAttackCooldown(float aLightAttackCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.AddLightAttackCooldown(_myId, aLightAttackCooldown);
        }
        
        public virtual void SubtractLightAttackCooldown(float aLightAttackCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractLightAttackCooldown(_myId, aLightAttackCooldown);
        }

        //Charge
        //Charge Speed
        public float GetChargeSpeed()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetChargeSpeed(_myId);
        }
        
        public virtual void SetChargeSpeed(float aChargeSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetChargeSpeed(_myId, aChargeSpeed);
        }
        
        public virtual void AddChargeSpeed(float aChargeSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddChargeSpeed(_myId, aChargeSpeed);
        }
        
        public virtual void SubtractChargeSpeed(float aChargeSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractChargeSpeed(_myId, aChargeSpeed);
        }
        
        //Max Charge Time
        public float GetMaxChargeTime()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetMaxChargeTime(_myId);
        }
        
        public virtual void SetMaxChargeTime(float aMaxChargeTime)
        {
            if (!didInit)
                Init();

            _myDataManager.SetMaxChargeTime(_myId, aMaxChargeTime);
        }
        
        public virtual void AddMaxChargeTime(float aMaxChargeTime)
        {
            if (!didInit)
                Init();

            _myDataManager.AddMaxChargeTime(_myId, aMaxChargeTime);
        }
        
        public virtual void SubtractMaxChargeTime(float aMaxChargeTime)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractMaxChargeTime(_myId, aMaxChargeTime);
        }
        
        //Stopped Time
        public float GetStoppedTime()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetStoppedTime(_myId);
        }
        
        public virtual void SetStoppedTime(float aStoppedTime)
        {
            if (!didInit)
                Init();

            _myDataManager.SetStoppedTime(_myId, aStoppedTime);
        }
        
        public virtual void AddStoppedTime(float aStoppedTime)
        {
            if (!didInit)
                Init();

            _myDataManager.AddStoppedTime(_myId, aStoppedTime);
        }
        
        public virtual void SubtractStoppedTime(float aStoppedTime)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractStoppedTime(_myId, aStoppedTime);
        }
        
        //Charge Cooldown
        public float GetChargeCooldown()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetChargeCooldown(_myId);
        }
        
        public virtual void SetChargeCooldown(float aChargeCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.SetChargeCooldown(_myId, aChargeCooldown);
        }
        
        public virtual void AddChargeCooldown(float aChargeCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.AddChargeCooldown(_myId, aChargeCooldown);
        }
        
        public virtual void SubtractChargeCooldown(float aChargeCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractChargeCooldown(_myId, aChargeCooldown);
        }
        
        //Can Double Charge (bool)
        public bool GetCanDoubleCharge()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetCanDoubleCharge(_myId);
        }
        
        public virtual void SetCanDoubleCharge(bool aCanDoubleCharge)
        {
            if (!didInit)
                Init();

            _myDataManager.SetCanDoubleCharge(_myId, aCanDoubleCharge);
        }

        //Score
        public int GetScore()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetScore(_myId);
        }
        
        public virtual void SetScore(int aScore)
        {
            if (!didInit)
                Init();

            _myDataManager.SetScore(_myId, aScore);
        }
        
        public virtual void AddScore(int aScore)
        {
            if (!didInit)
                Init();

            _myDataManager.AddScore(_myId, aScore);
        }
        
        public virtual void SubtractScore(int aScore)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractScore(_myId, aScore);
        }
        
        //Health
        public int GetHealth()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetHealth(_myId);
        }
        
        public virtual void SetHealth(int aHealth)
        {
            if (!didInit)
                Init();

            _myDataManager.SetHealth(_myId, aHealth);
        }
        
        public virtual void AddHealth(int aHealth)
        {
            if (!didInit)
                Init();

            _myDataManager.AddHealth(_myId, aHealth);
        }
        
        public virtual void SubtractHealth(int aHealth)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractHealth(_myId, aHealth);
        }
        
    }
}
