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
        public float GetMovementSpeed()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetMovementSpeed(_myId);
        }
        
        public virtual void SetMovementSpeed(float aMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetMovementSpeed(_myId, aMovementSpeed);
        }
        
        public virtual void AddMovementSpeed(float aMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddMovementSpeed(_myId, aMovementSpeed);
        }
        
        public virtual void SubtractMovementSpeed(float aMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractMovementSpeed(_myId, aMovementSpeed);
        }
        
        //Global Movement Speed Multiplier
        public float GetGlobalMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetGlobalMovementSpeedMultiplier(_myId);
        }
        
        public virtual void SetGlobalMovementSpeedMultiplier(float aGlobalMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetGlobalMovementSpeedMultiplier(_myId, aGlobalMovementSpeed);
        }
        
        public virtual void AddGlobalMovementSpeedMultiplier(float aGlobalMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddGlobalMovementSpeedMultiplier(_myId, aGlobalMovementSpeed);
        }
        
        public virtual void SubtractGlobalMovementSpeedMultiplier(float aGlobalMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractGlobalMovementSpeedMultiplier(_myId, aGlobalMovementSpeed);
        }
        
        //Melee Movement Speed Multiplier
        public float GetMeleeMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetMeleeMovementSpeedMultiplier(_myId);
        }
        
        public virtual void SetMeleeMovementSpeedMultiplier(float aMeleeMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetMeleeMovementSpeedMultiplier(_myId, aMeleeMovementSpeed);
        }
        
        public virtual void AddMeleeMovementSpeedMultiplier(float aMeleeMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddMeleeMovementSpeedMultiplier(_myId, aMeleeMovementSpeed);
        }
        
        public virtual void SubtractMeleeMovementSpeedMultiplier(float aMeleeMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractMeleeMovementSpeedMultiplier(_myId, aMeleeMovementSpeed);
        }
        
        
        //Casting Movement Speed Multiplier
        public float GetCastingMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetCastingMovementSpeedMultiplier(_myId);
        }
        
        public virtual void SetCastingMovementSpeedMultiplier(float aCastingMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SetCastingMovementSpeedMultiplier(_myId, aCastingMovementSpeed);
        }
        
        public virtual void AddCastingMovementSpeedMultiplier(float aCastingMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.AddCastingMovementSpeedMultiplier(_myId, aCastingMovementSpeed);
        }
        
        public virtual void SubtractCastingMovementSpeed(float aCastingMovementSpeed)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractCastingMovementSpeedMultiplier(_myId, aCastingMovementSpeed);
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
        
        //Light Attack Direction Lock Duration
        public float GetLightAttackDirectionLockDuration()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetLightAttackDirectionLockDuration(_myId);
        }
        
        public virtual void SetLightAttackDirectionLockDuration(float aLightAttackDirectionLookDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SetLightAttackDirectionLockDuration(_myId, aLightAttackDirectionLookDuration);
        }
        
        public virtual void AddLightAttackDirectionLockDuration(float aLightAttackDirectionLookDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.AddLightAttackDirectionLockDuration(_myId, aLightAttackDirectionLookDuration);
        }
        
        public virtual void SubtractLightAttackDirectionLockDuration(float aLightAttackDirectionLookDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractLightAttackDirectionLockDuration(_myId, aLightAttackDirectionLookDuration);
        }
        
        //Heavy Attack
        //Heavy Attack Duration
        public float GetHeavyAttackDuration()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetHeavyAttackDuration(_myId);
        }
        
        public virtual void SetHeavyAttackDuration(float aHeavyAttackDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SetHeavyAttackDuration(_myId, aHeavyAttackDuration);
        }
        
        public virtual void AddHeavyAttackDuration(float aHeavyAttackDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.AddHeavyAttackDuration(_myId, aHeavyAttackDuration);
        }
        
        public virtual void SubtractHeavyAttackDuration(float aHeavyAttackDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractHeavyAttackDuration(_myId, aHeavyAttackDuration);
        }
        
        //Heavy Attack Movement Speed Multiplier
        public float GetHeavyAttackMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetHeavyAttackMovementSpeedMultiplier(_myId);
        }
        
        public virtual void SetHeavyAttackMovementSpeedMultiplier(float aHeavyAttackMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myDataManager.SetHeavyAttackMovementSpeedMultiplier(_myId, aHeavyAttackMovementSpeedMultiplier);
        }
        
        public virtual void AddHeavyAttackMovementSpeedMultiplier(float aHeavyAttackMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myDataManager.AddHeavyAttackMovementSpeedMultiplier(_myId, aHeavyAttackMovementSpeedMultiplier);
        }
        
        public virtual void SubtractHeavyAttackMovementSpeedMultiplier(float aHeavyAttackMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractHeavyAttackMovementSpeedMultiplier(_myId, aHeavyAttackMovementSpeedMultiplier);
        }
        
        //Heavy Attack Cooldown
        public float GetHeavyAttackCooldown()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetHeavyAttackCooldown(_myId);
        }
        
        public virtual void SetHeavyAttackCooldown(float aHeavyAttackCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.SetHeavyAttackCooldown(_myId, aHeavyAttackCooldown);
        }
        
        public virtual void AddHeavyAttackCooldown(float aHeavyAttackCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.AddHeavyAttackCooldown(_myId, aHeavyAttackCooldown);
        }
        
        public virtual void SubtractHeavyAttackCooldown(float aHeavyAttackCooldown)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractHeavyAttackCooldown(_myId, aHeavyAttackCooldown);
        }
        
        //Heavy Attack Direction Lock Duration
        public float GetHeavyAttackDirectionLockDuration()
        {
            if (!didInit)
                Init();

            return _myDataManager.GetHeavyAttackDirectionLockDuration(_myId);
        }
        
        public virtual void SetHeavyAttackDirectionLockDuration(float aHeavyAttackDirectionLookDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SetHeavyAttackDirectionLockDuration(_myId, aHeavyAttackDirectionLookDuration);
        }
        
        public virtual void AddHeavyAttackDirectionLockDuration(float aHeavyAttackDirectionLookDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.AddHeavyAttackDirectionLockDuration(_myId, aHeavyAttackDirectionLookDuration);
        }
        
        public virtual void SubtractHeavyAttackDirectionLockDuration(float aHeavyAttackDirectionLookDuration)
        {
            if (!didInit)
                Init();

            _myDataManager.SubtractHeavyAttackDirectionLockDuration(_myId, aHeavyAttackDirectionLookDuration);
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
