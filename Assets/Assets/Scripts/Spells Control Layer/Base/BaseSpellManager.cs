using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base.Data;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Base
{
    public class BaseSpellManager : MonoBehaviour
    {
        private static List<SpellData> global_SpellDatas;
        
        private bool didInit { get; set; }

        private void Init()
        {
            global_SpellDatas ??= new List<SpellData>();
            
            didInit = true;
        }
        
        public void ResetSpells()
        {
            if (!didInit)
                Init();

            global_SpellDatas = new List<SpellData>();
        }

        public List<SpellData> GetSpellList()
        {
            if (global_SpellDatas == null)
                Init();

            return global_SpellDatas;
        }

        public int AddNewSpell
                (
                string _name, 
                string _element,
                string _spellDescription,
                int _spellType,
                float _castingSpellDuration, 
                float _castingSpellMovementSpeedMultiplier, 
                float _castingSpellCooldown, 
                float _castingSpellDirectionLockDuration,
                //Projectile type Spell
                float _projectileSpeed,
                GameObject _projectilePrefab,
                float _projectileLifeSpawn,
                //Aeo type Spell
                float _aoeDistanceFromCastingPoint,
                float _aoeLifeSpawn,
                float _aoeRadius,
                GameObject _aoePrefab,
                //Dash type Spell
                float _dashChargeSpeed,
                float _dashMaxChargeTime,
                float _dashStoppedTime,
                GameObject _dashTrailPrefab,
                float _dashTrailLifeSpawn,
                //Projectile Explosion type Spell
                GameObject _projectileExplosionProjectilePrefab,
                GameObject _projectileExplosionAoePrefab,
                float _projectileExplosionProjectileSpeed,
                float _projectileExplosionProjectileLifeSpawn,
                float _projectileExplosionAoeLifeSpawn,
                float _projectileExplosionAoeRadius,
                //Change to Movement Speed
                float _changeToMovementSpeed,
                //Change to Light Attack
                float _changeToLightAttackDuration,
                float _changeToLightAttackMovementSpeed,
                float _changeToLightAttackCooldown,
                float _changeToLightAttackRange,
                float _changeToLightAttackRadius,
                //Change to Heavy Attack
                float _changeToHeavyAttackDuration,
                float _changeToHeavyAttackMovementSpeed,
                float _changeToHeavyAttackCooldown,
                float _changeToHeavyAttackRange,
                float _changeToHeavyAttackRadius,
                //Change to Charge
                float _changeToChargeSpeed,
                float _changeToChargeMaxChargeTime,
                float _changeToChargeStoppedTime,
                float _changeToChargeCooldown,
                bool _canDoubleCharge
                )
        {
            if (!didInit)
                Init();

            var newSpell = new SpellData
            {
                id = global_SpellDatas.Count,
                spellName = _name,
                
                element = _element,
                
                spellDescription = _spellDescription,
                
                spellType = _spellType,

                castingSpellDuration = _castingSpellDuration,
                castingSpellMovementSpeedMultiplier = _castingSpellMovementSpeedMultiplier,
                castingSpellCooldown = _castingSpellCooldown,
                castingSpellDirectionLockDuration = _castingSpellDirectionLockDuration,
                
                //Projectile type Spell
                projectileSpeed = _projectileSpeed,
                projectilePrefab = _projectilePrefab,
                projectileLifeSpawn = _projectileLifeSpawn,
                
                //Aeo type Spell
                aoeDistanceFromCastingPoint = _aoeDistanceFromCastingPoint,
                aoeLifeSpawn = _aoeLifeSpawn,
                aoeRadius = _aoeRadius,
                aoePrefab = _aoePrefab,
                
                //Dash type Spell
                dashChargeSpeed = _dashChargeSpeed,
                dashMaxChargeTime = _dashMaxChargeTime,
                dashStoppedTime = _dashStoppedTime,
                dashTrailPrefab = _dashTrailPrefab,
                dashTrailLifeSpawn = _dashTrailLifeSpawn,
                
                //Projectile Explosion type Spell
                projectileExplosionProjectilePrefab = _projectileExplosionProjectilePrefab,
                projectileExplosionAoePrefab = _projectileExplosionAoePrefab,
                projectileExplosionProjectileSpeed = _projectileExplosionProjectileSpeed,
                projectileExplosionProjectileLifeSpawn = _projectileExplosionProjectileLifeSpawn,
                projectileExplosionAoeLifeSpawn = _projectileExplosionAoeLifeSpawn,
                projectileExplosionAoeRadius = _projectileExplosionAoeRadius,
                
                //Change to Movement Speed
                changeToMovementSpeed = _changeToMovementSpeed,
                
                //Change to Light Attack
                changeToLightAttackDuration = _changeToLightAttackDuration,
                changeToLightAttackMovementSpeed = _changeToLightAttackMovementSpeed,
                changeToLightAttackCooldown = _changeToLightAttackCooldown,
                changeToLightAttackRange = _changeToLightAttackRange,
                changeToLightAttackRadius = _changeToLightAttackRadius,
                
                //Change to Heavy Attack
                changeToHeavyAttackDuration = _changeToHeavyAttackDuration,
                changeToHeavyAttackMovementSpeed = _changeToHeavyAttackMovementSpeed,
                changeToHeavyAttackCooldown = _changeToHeavyAttackCooldown,
                changeToHeavyAttackRange = _changeToHeavyAttackRange,
                changeToHeavyAttackRadius = _changeToHeavyAttackRadius,
                
                //Change to Charge
                changeToChargeSpeed = _changeToChargeSpeed,
                changeToChargeMaxChargeTime = _changeToChargeMaxChargeTime,
                changeToChargeStoppedTime = _changeToChargeStoppedTime,
                changeToChargeCooldown = _changeToChargeCooldown,
                canDoubleCharge = _canDoubleCharge
            };
            
            global_SpellDatas.Add(newSpell);
            
            return newSpell.id;
        }

        //Name
        public string GetSpellName(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].spellName;
        }
        
        public void SetSpellName(int id, string aName)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].spellName = aName;
        }
        
        //Element
        public string GetSpellElement(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].element;
        }
        
        //Spell Description
        public string GetSpellDescription(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].spellDescription;
        }
        
        //Spell Type
        public int GetSpellType(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].spellType;
        }
        
        
        //Casting Spell Duration
        public float GetCastingSpellDuration(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].castingSpellDuration;
        }
        
        public void SetCastingSpellDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellDuration = anAmount;
        }

        public void AddCastingSpellDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellDuration += anAmount;
        }
        
        public void SubtractCastingSpellDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellDuration -= anAmount;
        }
        
        //Casting Spell Movement Speed Multiplier
        public float GetCastingSpellMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].castingSpellMovementSpeedMultiplier;
        }
        
        public void SetCastingSpellMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellMovementSpeedMultiplier = anAmount;
        }
        
        public void AddCastingSpellMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellMovementSpeedMultiplier += anAmount;
        }
        
        public void SubtractCastingSpellMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellMovementSpeedMultiplier -= anAmount;
        }
        
        //Casting Spell Cooldown
        public float GetCastingSpellCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].castingSpellCooldown;
        }
        
        public void SetCastingSpellCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellCooldown = anAmount;
        }
        
        public void AddCastingSpellCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellCooldown += anAmount;
        }
        
        public void SubtractCastingSpellCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellCooldown -= anAmount;
        }
        
        //Casting Spell Direction Lock Duration
        public float GetCastingSpellDirectionLockDuration(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].castingSpellDirectionLockDuration;
        }
        
        public void SetCastingSpellDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellDirectionLockDuration = anAmount;
        }
        
        public void AddCastingSpellDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellDirectionLockDuration += anAmount;
        }
        
        public void SubtractCastingSpellDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].castingSpellDirectionLockDuration -= anAmount;
        }
        
        //Projectile Type Spell
        //Projectile Speed
        public float GetProjectileSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileSpeed;
        }
        
        public void SetProjectileSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileSpeed = anAmount;
        }
        
        public void AddProjectileSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileSpeed += anAmount;
        }
        
        public void SubtractProjectileSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileSpeed -= anAmount;
        }
        
        //Projectile Prefab
        public GameObject GetProjectilePrefab(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectilePrefab;
        }
        
        public void SetProjectilePrefab(int id, GameObject aPrefab)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectilePrefab = aPrefab;
        }
        
        //Projectile Life Spawn
        public float GetProjectileLifeSpawn(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileLifeSpawn;
        }
        
        public void SetProjectileLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileLifeSpawn = anAmount;
        }
        
        public void AddProjectileLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileLifeSpawn += anAmount;
        }
        
        public void SubtractProjectileLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileLifeSpawn -= anAmount;
        }
        
        //Aeo Type Spell
        //Distance From Casting Point
        public float GetAoeDistanceFromCastingPoint(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].aoeDistanceFromCastingPoint;
        }
        
        public void SetAoeDistanceFromCastingPoint(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeDistanceFromCastingPoint = anAmount;
        }
        
        public void AddAoeDistanceFromCastingPoint(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeDistanceFromCastingPoint += anAmount;
        }
        
        public void SubtractAoeDistanceFromCastingPoint(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeDistanceFromCastingPoint -= anAmount;
        }
        
        //Aeo Life Spawn
        public float GetAoeLifeSpawn(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].aoeLifeSpawn;
        }
        
        public void SetAoeLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeLifeSpawn = anAmount;
        }
        
        public void AddAoeLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeLifeSpawn += anAmount;
        }
        
        public void SubtractAoeLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeLifeSpawn -= anAmount;
        }
        
        //Aeo Radius
        public float GetAoeRadius(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].aoeRadius;
        }
        
        public void SetAoeRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeRadius = anAmount;
        }
        
        public void AddAoeRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeRadius += anAmount;
        }
        
        public void SubtractAoeRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoeRadius -= anAmount;
        }
        
        //Aeo Prefab
        public GameObject GetAoePrefab(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].aoePrefab;
        }
        
        public void SetAoePrefab(int id, GameObject aPrefab)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].aoePrefab = aPrefab;
        }
        
        //Dash Type Spell
        //Dash Charge Speed
        public float GetDashChargeSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].dashChargeSpeed;
        }
        
        public void SetDashChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashChargeSpeed = anAmount;
        }
        
        public void AddDashChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashChargeSpeed += anAmount;
        }
        
        public void SubtractDashChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashChargeSpeed -= anAmount;
        }
        
        //Dash Max Charge Time
        public float GetDashMaxChargeTime(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].dashMaxChargeTime;
        }
        
        public void SetDashMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashMaxChargeTime = anAmount;
        }
        
        public void AddDashMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashMaxChargeTime += anAmount;
        }
        
        public void SubtractDashMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashMaxChargeTime -= anAmount;
        }
        
        //Dash Stopped Time
        public float GetDashStoppedTime(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].dashStoppedTime;
        }
        
        public void SetDashStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashStoppedTime = anAmount;
        }
        
        public void AddDashStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashStoppedTime += anAmount;
        }
        
        public void SubtractDashStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashStoppedTime -= anAmount;
        }
        
        //Dash Trail Prefab
        public GameObject GetDashTrailPrefab(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].dashTrailPrefab;
        }
        
        public void SetDashTrailPrefab(int id, GameObject aPrefab)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashTrailPrefab = aPrefab;
        }
        
        //Dash Trail Life Spawn
        public float GetDashTrailLifeSpawn(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].dashTrailLifeSpawn;
        }
        
        public void SetDashTrailLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashTrailLifeSpawn = anAmount;
        }
        
        public void AddDashTrailLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashTrailLifeSpawn += anAmount;
        }
        
        public void SubtractDashTrailLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].dashTrailLifeSpawn -= anAmount;
        }
        
        //Projectile Explosion type Spell
        //Projectile Explosion Projectile Prefab
        public GameObject GetProjectileExplosionProjectilePrefab(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileExplosionProjectilePrefab;
        }
        
        public void SetProjectileExplosionProjectilePrefab(int id, GameObject aPrefab)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectilePrefab = aPrefab;
        }
        
        //Projectile Explosion Aoe Prefab
        public GameObject GetProjectileExplosionAoePrefab(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileExplosionAoePrefab;
        }
        
        public void SetProjectileExplosionAoePrefab(int id, GameObject aPrefab)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoePrefab = aPrefab;
        }
        
        //Projectile Explosion Projectile Speed
        public float GetProjectileExplosionProjectileSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileExplosionProjectileSpeed;
        }
        
        public void SetProjectileExplosionProjectileSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectileSpeed = anAmount;
        }
        
        public void AddProjectileExplosionProjectileSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectileSpeed += anAmount;
        }
        
        public void SubtractProjectileExplosionProjectileSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectileSpeed -= anAmount;
        }
        
        //Projectile Explosion Projectile Life Spawn
        public float GetProjectileExplosionProjectileLifeSpawn(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileExplosionProjectileLifeSpawn;
        }
        
        public void SetProjectileExplosionProjectileLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectileLifeSpawn = anAmount;
        }
        
        public void AddProjectileExplosionProjectileLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectileLifeSpawn += anAmount;
        }
        
        public void SubtractProjectileExplosionProjectileLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionProjectileLifeSpawn -= anAmount;
        }
        
        //Projectile Explosion Aoe Life Spawn
        public float GetProjectileExplosionAoeLifeSpawn(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileExplosionAoeLifeSpawn;
        }
        
        public void SetProjectileExplosionAoeLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoeLifeSpawn = anAmount;
        }
        
        public void AddProjectileExplosionAoeLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoeLifeSpawn += anAmount;
        }
        
        public void SubtractProjectileExplosionAoeLifeSpawn(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoeLifeSpawn -= anAmount;
        }
        
        //Projectile Explosion Aoe Radius
        public float GetProjectileExplosionAoeRadius(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].projectileExplosionAoeRadius;
        }
        
        public void SetProjectileExplosionAoeRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoeRadius = anAmount;
        }
        
        public void AddProjectileExplosionAoeRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoeRadius += anAmount;
        }
        
        public void SubtractProjectileExplosionAoeRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_SpellDatas[id].projectileExplosionAoeRadius -= anAmount;
        }
        
        //Getters for change to stats
        //Change to Movement Speed
        public float GetChangeToMovementSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToMovementSpeed;
        }
        
        //Change to Light Attack
        //Change to Light Attack Duration
        public float GetChangeToLightAttackDuration(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToLightAttackDuration;
        }
        
        //Change to Light Attack Movement Speed
        public float GetChangeToLightAttackMovementSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToLightAttackMovementSpeed;
        }
        
        //Change to Light Attack Cooldown
        public float GetChangeToLightAttackCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToLightAttackCooldown;
        }
        
        //Change to Light Attack Range
        public float GetChangeToLightAttackRange(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToLightAttackRange;
        }
        
        //Change to Light Attack Radius
        public float GetChangeToLightAttackRadius(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToLightAttackRadius;
        }
        
        //Change To Heavy Attack
        //Change to Heavy Attack Duration
        public float GetChangeToHeavyAttackDuration(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToHeavyAttackDuration;
        }
        
        //Change to Heavy Attack Movement Speed
        public float GetChangeToHeavyAttackMovementSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToHeavyAttackMovementSpeed;
        }
        
        //Change to Heavy Attack Cooldown
        public float GetChangeToHeavyAttackCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToHeavyAttackCooldown;
        }
        
        //Change to Heavy Attack Range
        public float GetChangeToHeavyAttackRange(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToHeavyAttackRange;
        }
        
        //Change to Heavy Attack Radius
        public float GetChangeToHeavyAttackRadius(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToHeavyAttackRadius;
        }
        
        //Change to Charge 
        //Change to Charge Speed
        public float GetChangeToChargeSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToChargeSpeed;
        }
        
        //Change to Max Charge Time
        public float GetChangeToMaxChargeTime(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToChargeMaxChargeTime;
        }
        
        //Change to Charge Stopped Time
        public float GetChangeToChargeStoppedTime(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToChargeStoppedTime;
        }
        
        //Change to Charge Cooldown
        public float GetChangeToChargeCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].changeToChargeCooldown;
        }
        
        //Can Double Charge?
        public bool GetCanDoubleCharge(int id)
        {
            if (!didInit)
                Init();

            return global_SpellDatas[id].canDoubleCharge;
        }
    }
}
