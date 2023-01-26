using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base;
using UnityEngine;


namespace Assets.Scripts.Spells_Control_Layer
{
    public class ComboSpellsStatsManager : MonoBehaviour
    {
        public BaseComboSpellManager _myComboSpellManager;
        
        private int _myId { get; set; }
        
        private bool didInit { get; set; }

        private void Awake()
        {
            Init();
        }
        
        protected virtual void Init()
        {
            Debug.Log("Init Combo Spell Data Controller");
            SetupDataManager();
            didInit = true;
        }
        
        public virtual void SetComboSpellDetails(int anID)
        {
            if (!didInit)
                Init();
            
            _myId = anID;
        }
        
        protected virtual void SetupDataManager()
        {
            if(_myComboSpellManager == null)
                _myComboSpellManager = GetComponent<BaseComboSpellManager>();
            
            if(_myComboSpellManager == null)
                _myComboSpellManager = gameObject.AddComponent<BaseComboSpellManager>();
            
            if(_myComboSpellManager == null)
                _myComboSpellManager = GetComponent<BaseComboSpellManager>();
        }
        
        //Name
        public string GetComboSpellName()
        {
            if (!didInit)
                Init();

            return _myComboSpellManager.GetComboSpellName(_myId);
        }
        
        public void SetComboSpellName(string aName)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SetComboSpellName(_myId, aName);
        }
        
        //Casting Combo Spell Duration
        public float GetCastingComboSpellDuration()
        {
            if (!didInit)
                Init();

            return _myComboSpellManager.GetCastingComboSpellDuration(_myId);
        }
        
        public void SetCastingComboSpellDuration(float aDuration)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SetCastingComboSpellDuration(_myId, aDuration);
        }
        
        public void AddCastingComboSpellDuration(float aDuration)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.AddCastingComboSpellDuration(_myId, aDuration);
        }
        
        public void SubtractCastingComboSpellDuration(float aDuration)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SubtractCastingComboSpellDuration(_myId, aDuration);
        }
        
        //Casting Combo Spell Movement Speed Multiplier
        public float GetCastingComboSpellMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _myComboSpellManager.GetCastingComboSpellMovementSpeedMultiplier(_myId);
        }
        
        public void SetCastingComboSpellMovementSpeedMultiplier(float aMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SetCastingComboSpellMovementSpeedMultiplier(_myId, aMovementSpeedMultiplier);
        }
        
        public void AddCastingComboSpellMovementSpeedMultiplier(float aMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.AddCastingComboSpellMovementSpeedMultiplier(_myId, aMovementSpeedMultiplier);
        }
        
        public void SubtractCastingComboSpellMovementSpeedMultiplier(float aMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SubtractCastingComboSpellMovementSpeedMultiplier(_myId, aMovementSpeedMultiplier);
        }
        
        //Casting Combo Spell Cooldown
        public float GetCastingComboSpellCooldown()
        {
            if (!didInit)
                Init();

            return _myComboSpellManager.GetCastingComboSpellCooldown(_myId);
        }
        
        public void SetCastingComboSpellCooldown(float aCooldown)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SetCastingComboSpellCooldown(_myId, aCooldown);
        }
        
        public void AddCastingComboSpellCooldown(float aCooldown)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.AddCastingComboSpellCooldown(_myId, aCooldown);
        }
        
        public void SubtractCastingComboSpellCooldown(float aCooldown)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SubtractCastingComboSpellCooldown(_myId, aCooldown);
        }
        
        //Casting Combo Spell Direction Lock Duration
        public float GetCastingComboSpellDirectionLockDuration()
        {
            if (!didInit)
                Init();

            return _myComboSpellManager.GetCastingComboSpellDirectionLockDuration(_myId);
        }
        
        public void SetCastingComboSpellDirectionLockDuration(float aDirectionLockDuration)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SetCastingComboSpellDirectionLockDuration(_myId, aDirectionLockDuration);
        }
        
        public void AddCastingComboSpellDirectionLockDuration(float aDirectionLockDuration)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.AddCastingComboSpellDirectionLockDuration(_myId, aDirectionLockDuration);
        }
        
        public void SubtractCastingComboSpellDirectionLockDuration(float aDirectionLockDuration)
        {
            if (!didInit)
                Init();

            _myComboSpellManager.SubtractCastingComboSpellDirectionLockDuration(_myId, aDirectionLockDuration);
        }
    }
}
