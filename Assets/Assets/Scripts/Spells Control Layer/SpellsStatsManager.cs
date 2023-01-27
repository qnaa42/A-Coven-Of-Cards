using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Spells_Control_Layer.Base;
using UnityEngine;



namespace Assets.Scripts.Spells_Control_Layer
{
    public class SpellsStatsManager : MonoBehaviour
    {
        public BaseSpellManager _mySpellManager;
        
        private int _myId { get; set; }
        
        private bool didInit { get; set; }

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            Debug.Log("Init Spell Data Controller");
            SetupDataManager();
            didInit = true;
        }
        
        public virtual void SetSpellDetails(int anID)
        {
            if (!didInit)
                Init();
            
            _myId = anID;
        }
        
        protected virtual void SetupDataManager()
        {
            if(_mySpellManager == null)
                _mySpellManager = GetComponent<BaseSpellManager>();
            
            if(_mySpellManager == null)
                _mySpellManager = gameObject.AddComponent<BaseSpellManager>();
            
            if(_mySpellManager == null)
                _mySpellManager = GetComponent<BaseSpellManager>();
        }
        
        //Name
        public string GetSpellName()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetSpellName(_myId);
        }
        
        public void SetSpellName(string aName)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetSpellName(_myId, aName);
        }
        
        //Element
        public string GetSpellElement()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetSpellElement(_myId);
        }
        
        //Casting Spell Duration
        public float GetCastingSpellDuration()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetCastingSpellDuration(_myId);
        }
        
        public void SetCastingSpellDuration(float aDuration)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetCastingSpellDuration(_myId, aDuration);
        }
        
        public void AddCastingSpellDuration(float aDuration)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddCastingSpellDuration(_myId, aDuration);
        }
        
        public void SubtractCastingSpellDuration(float aDuration)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractCastingSpellDuration(_myId, aDuration);
        }
        
        //Casting Spell Movement Speed Multiplier
        public float GetCastingSpellMovementSpeedMultiplier()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetCastingSpellMovementSpeedMultiplier(_myId);
        }
        
        public void SetCastingSpellMovementSpeedMultiplier(float aMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetCastingSpellMovementSpeedMultiplier(_myId, aMovementSpeedMultiplier);
        }
        
        public void AddCastingSpellMovementSpeedMultiplier(float aMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddCastingSpellMovementSpeedMultiplier(_myId, aMovementSpeedMultiplier);
        }
        
        public void SubtractCastingSpellMovementSpeedMultiplier(float aMovementSpeedMultiplier)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractCastingSpellMovementSpeedMultiplier(_myId, aMovementSpeedMultiplier);
        }
        
        //Casting Spell Cooldown
        public float GetCastingSpellCooldown()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetCastingSpellCooldown(_myId);
        }
        
        public void SetCastingSpellCooldown(float aCooldown)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetCastingSpellCooldown(_myId, aCooldown);
        }
        
        public void AddCastingSpellCooldown(float aCooldown)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddCastingSpellCooldown(_myId, aCooldown);
        }
        
        public void SubtractCastingSpellCooldown(float aCooldown)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractCastingSpellCooldown(_myId, aCooldown);
        }
        
        //Casting Spell Direction Lock Duration
        public float GetCastingSpellDirectionLockDuration()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetCastingSpellDirectionLockDuration(_myId);
        }
        
        public void SetCastingSpellDirectionLockDuration(float aDirectionLockDuration)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetCastingSpellDirectionLockDuration(_myId, aDirectionLockDuration);
        }
        
        public void AddCastingSpellDirectionLockDuration(float aDirectionLockDuration)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddCastingSpellDirectionLockDuration(_myId, aDirectionLockDuration);
        }
        
        public void SubtractCastingSpellDirectionLockDuration(float aDirectionLockDuration)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractCastingSpellDirectionLockDuration(_myId, aDirectionLockDuration);
        }
    }
}
