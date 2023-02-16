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
        
        //Spell Description
        public string GetSpellDescription()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetSpellDescription(_myId);
        }
        
        //Spell Type
        public int GetSpellType()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetSpellType(_myId);
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
        
        //Projectile Type Spell
        //Projectile Speed
        public float GetProjectileSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileSpeed(_myId);
        }
        
        public void SetProjectileSpeed(float aProjectileSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileSpeed(_myId, aProjectileSpeed);
        }
        
        public void AddProjectileSpeed(float aProjectileSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddProjectileSpeed(_myId, aProjectileSpeed);
        }
        
        public void SubtractProjectileSpeed(float aProjectileSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractProjectileSpeed(_myId, aProjectileSpeed);
        }
        
        //Projectile Prefab
        public GameObject GetProjectilePrefab()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectilePrefab(_myId);
        }
        
        public void SetProjectilePrefab(GameObject aProjectilePrefab)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectilePrefab(_myId, aProjectilePrefab);
        }
        
        //Projectile Life Spawn
        public float GetProjectileLifeSpawn()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileLifeSpawn(_myId);
        }
        
        public void SetProjectileLifeSpawn(float aProjectileLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileLifeSpawn(_myId, aProjectileLifeSpawn);
        }
        
        public void AddProjectileLifeSpawn(float aProjectileLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddProjectileLifeSpawn(_myId, aProjectileLifeSpawn);
        }
        
        public void SubtractProjectileLifeSpawn(float aProjectileLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractProjectileLifeSpawn(_myId, aProjectileLifeSpawn);
        }
        
        //Aeo type spell
        //Distance From Casting Point
        public float GetAoeDistanceFromCastingPoint()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetAoeDistanceFromCastingPoint(_myId);
        }
        
        public void SetAoeDistanceFromCastingPoint(float aDistanceFromCastingPoint)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetAoeDistanceFromCastingPoint(_myId, aDistanceFromCastingPoint);
        }
        
        public void AddAoeDistanceFromCastingPoint(float aDistanceFromCastingPoint)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddAoeDistanceFromCastingPoint(_myId, aDistanceFromCastingPoint);
        }
        
        public void SubtractAoeDistanceFromCastingPoint(float aDistanceFromCastingPoint)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractAoeDistanceFromCastingPoint(_myId, aDistanceFromCastingPoint);
        }
        
        //Aeo Life Spawn
        public float GetAoeLifeSpawn()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetAoeLifeSpawn(_myId);
        }
        
        public void SetAoeLifeSpawn(float aAeoLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetAoeLifeSpawn(_myId, aAeoLifeSpawn);
        }
        
        public void AddAoeLifeSpawn(float aAeoLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddAoeLifeSpawn(_myId, aAeoLifeSpawn);
        }
        
        public void SubtractAoeLifeSpawn(float aAeoLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractAoeLifeSpawn(_myId, aAeoLifeSpawn);
        }
        
        //Aeo Radius
        public float GetAoeRadius()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetAoeRadius(_myId);
        }
        
        public void SetAoeRadius(float aAeoRadius)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetAoeRadius(_myId, aAeoRadius);
        }
        
        public void AddAoeRadius(float aAeoRadius)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddAoeRadius(_myId, aAeoRadius);
        }
        
        public void SubtractAoeRadius(float aAeoRadius)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractAoeRadius(_myId, aAeoRadius);
        }
        
        //Aeo Prefab
        public GameObject GetAoePrefab()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetAoePrefab(_myId);
        }
        
        public void SetAoePrefab(GameObject aAeoPrefab)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetAoePrefab(_myId, aAeoPrefab);
        }
        
        //Dash Type Spell
        //Dash Charge Speed
        public float GetDashChargeSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetDashChargeSpeed(_myId);
        }
        
        public void SetDashChargeSpeed(float aDashChargeSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetDashChargeSpeed(_myId, aDashChargeSpeed);
        }
        
        public void AddDashChargeSpeed(float aDashChargeSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddDashChargeSpeed(_myId, aDashChargeSpeed);
        }
        
        public void SubtractDashChargeSpeed(float aDashChargeSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractDashChargeSpeed(_myId, aDashChargeSpeed);
        }
        
        //Dash Max Charge Time
        public float GetDashMaxChargeTime()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetDashMaxChargeTime(_myId);
        }
        
        public void SetDashMaxChargeTime(float aDashMaxChargeTime)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetDashMaxChargeTime(_myId, aDashMaxChargeTime);
        }
        
        public void AddDashMaxChargeTime(float aDashMaxChargeTime)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddDashMaxChargeTime(_myId, aDashMaxChargeTime);
        }
        
        public void SubtractDashMaxChargeTime(float aDashMaxChargeTime)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractDashMaxChargeTime(_myId, aDashMaxChargeTime);
        }
        
        //Dash Stopped Time 
        public float GetDashStoppedTime()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetDashStoppedTime(_myId);
        }
        
        public void SetDashStoppedTime(float aDashStoppedTime)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetDashStoppedTime(_myId, aDashStoppedTime);
        }
        
        public void AddDashStoppedTime(float aDashStoppedTime)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddDashStoppedTime(_myId, aDashStoppedTime);
        }
        
        public void SubtractDashStoppedTime(float aDashStoppedTime)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractDashStoppedTime(_myId, aDashStoppedTime);
        }
        
        //Dash Trail Prefab
        public GameObject GetDashTrailPrefab()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetDashTrailPrefab(_myId);
        }
        
        public void SetDashTrailPrefab(GameObject aDashTrailPrefab)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetDashTrailPrefab(_myId, aDashTrailPrefab);
        }
        
        //Dash Trail Life Spawn
        public float GetDashTrailLifeSpawn()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetDashTrailLifeSpawn(_myId);
        }
        
        public void SetDashTrailLifeSpawn(float aDashTrailLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetDashTrailLifeSpawn(_myId, aDashTrailLifeSpawn);
        }
        
        public void AddDashTrailLifeSpawn(float aDashTrailLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddDashTrailLifeSpawn(_myId, aDashTrailLifeSpawn);
        }
        
        public void SubtractDashTrailLifeSpawn(float aDashTrailLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractDashTrailLifeSpawn(_myId, aDashTrailLifeSpawn);
        }
        
        //Projectile Explosion type Spell
        //Projectile Explosion Projectile Prefab
        public GameObject GetProjectileExplosionProjectilePrefab()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileExplosionProjectilePrefab(_myId);
        }
        
        public void SetProjectileExplosionProjectilePrefab(GameObject aProjectileExplosionProjectilePrefab)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileExplosionProjectilePrefab(_myId, aProjectileExplosionProjectilePrefab);
        }
        
        //Projectile Explosion Aoe Prefab
        public GameObject GetProjectileExplosionAoePrefab()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileExplosionAoePrefab(_myId);
        }
        
        public void SetProjectileExplosionAoePrefab(GameObject aProjectileExplosionAoePrefab)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileExplosionAoePrefab(_myId, aProjectileExplosionAoePrefab);
        }
        
        //Projectile Explosion Projectile Speed
        public float GetProjectileExplosionProjectileSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileExplosionProjectileSpeed(_myId);
        }
        
        public void SetProjectileExplosionProjectileSpeed(float aProjectileExplosionProjectileSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileExplosionProjectileSpeed(_myId, aProjectileExplosionProjectileSpeed);
        }
        
        public void AddProjectileExplosionProjectileSpeed(float aProjectileExplosionProjectileSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddProjectileExplosionProjectileSpeed(_myId, aProjectileExplosionProjectileSpeed);
        }   
        
        public void SubtractProjectileExplosionProjectileSpeed(float aProjectileExplosionProjectileSpeed)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractProjectileExplosionProjectileSpeed(_myId, aProjectileExplosionProjectileSpeed);
        }
        
        //Projectile Explosion Projectile Life Spawn
        public float GetProjectileExplosionProjectileLifeSpawn()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileExplosionProjectileLifeSpawn(_myId);
        }
        
        public void SetProjectileExplosionProjectileLifeSpawn(float aProjectileExplosionProjectileLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileExplosionProjectileLifeSpawn(_myId, aProjectileExplosionProjectileLifeSpawn);
        }
        
        public void AddProjectileExplosionProjectileLifeSpawn(float aProjectileExplosionProjectileLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddProjectileExplosionProjectileLifeSpawn(_myId, aProjectileExplosionProjectileLifeSpawn);
        }
        
        public void SubtractProjectileExplosionProjectileLifeSpawn(float aProjectileExplosionProjectileLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractProjectileExplosionProjectileLifeSpawn(_myId, aProjectileExplosionProjectileLifeSpawn);
        }
        
        //Projectile Explosion Aoe Life Spawn
        public float GetProjectileExplosionAoeLifeSpawn()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileExplosionAoeLifeSpawn(_myId);
        }
        
        public void SetProjectileExplosionAoeLifeSpawn(float aProjectileExplosionAoeLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileExplosionAoeLifeSpawn(_myId, aProjectileExplosionAoeLifeSpawn);
        }
        
        public void AddProjectileExplosionAoeLifeSpawn(float aProjectileExplosionAoeLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddProjectileExplosionAoeLifeSpawn(_myId, aProjectileExplosionAoeLifeSpawn);
        }
        
        public void SubtractProjectileExplosionAoeLifeSpawn(float aProjectileExplosionAoeLifeSpawn)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractProjectileExplosionAoeLifeSpawn(_myId, aProjectileExplosionAoeLifeSpawn);
        }
        
        //Projectile Explosion Aoe Radius
        public float GetProjectileExplosionAoeRadius()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetProjectileExplosionAoeRadius(_myId);
        }
        
        public void SetProjectileExplosionAoeRadius(float aProjectileExplosionAoeRadius)
        {
            if (!didInit)
                Init();

            _mySpellManager.SetProjectileExplosionAoeRadius(_myId, aProjectileExplosionAoeRadius);
        }
        
        public void AddProjectileExplosionAoeRadius(float aProjectileExplosionAoeRadius)
        {
            if (!didInit)
                Init();

            _mySpellManager.AddProjectileExplosionAoeRadius(_myId, aProjectileExplosionAoeRadius);
        }
        
        public void SubtractProjectileExplosionAoeRadius(float aProjectileExplosionAoeRadius)
        {
            if (!didInit)
                Init();

            _mySpellManager.SubtractProjectileExplosionAoeRadius(_myId, aProjectileExplosionAoeRadius);
        }
        
        //Getters for change to stats
        //Change to Movement Speed
        public float GetChangeToMovementSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToMovementSpeed(_myId);
        }
        
        //Change to Light Attack
        //Change to Light Attack Duration
        public float GetChangeToLightAttackDuration()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToLightAttackDuration(_myId);
        }
        
        //Change to Light Attack Movement Speed
        public float GetChangeToLightAttackMovementSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToLightAttackMovementSpeed(_myId);
        }
        
        //Change to Light Attack Cooldown
        public float GetChangeToLightAttackCooldown()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToLightAttackCooldown(_myId);
        }
        
        //Change to Light Attack Range
        public float GetChangeToLightAttackRange()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToLightAttackRange(_myId);
        }
        
        //Change to Light Attack Radius
        public float GetChangeToLightAttackRadius()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToLightAttackRadius(_myId);
        }
        
        //Change to Heavy Attack
        //Change to Heavy Attack Duration
        public float GetChangeToHeavyAttackDuration()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToHeavyAttackDuration(_myId);
        }
        
        //Change to Heavy Attack Movement Speed
        public float GetChangeToHeavyAttackMovementSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToHeavyAttackMovementSpeed(_myId);
        }
        
        //Change to Heavy Attack Cooldown
        public float GetChangeToHeavyAttackCooldown()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToHeavyAttackCooldown(_myId);
        }
        
        //Change to Heavy Attack Range
        public float GetChangeToHeavyAttackRange()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToHeavyAttackRange(_myId);
        }
        
        //Change to Heavy Attack Radius
        public float GetChangeToHeavyAttackRadius()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToHeavyAttackRadius(_myId);
        }
        
        //Change to Charge 
        //Change to Charge Speed
        public float GetChangeToChargeSpeed()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToChargeSpeed(_myId);
        }
        
        //Change to Max Charge Time
        public float GetChangeToMaxChargeTime()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToMaxChargeTime(_myId);
        }
        
        //Change to Charge Stopped Time
        public float GetChangeToChargeStoppedTime()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToChargeStoppedTime(_myId);
        }
        
        //Change to Charge Cooldown
        public float GetChangeToChargeCooldown()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetChangeToChargeCooldown(_myId);
        }
        
        //Can Double Charge?
        public bool GetCanDoubleCharge()
        {
            if (!didInit)
                Init();

            return _mySpellManager.GetCanDoubleCharge(_myId);
        }
    }
}
