using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Base.Data
{
    public class SpellData
    {
        public int id;
        
        public string spellName = "Default";
        
        public string element = "Default";
        
        public string spellDescription = "Default";
        
        //Where 0 = Default, 1 = Projectile, 2 = Aeo, 3 = Dash, 4 = Buff, 5 = Aeo Debuff, 6 = Projectile Explosion
        public int spellType;

        public float castingSpellDuration;
        public float castingSpellMovementSpeedMultiplier;
        public float castingSpellCooldown;
        public float castingSpellDirectionLockDuration;
        
        //Projectile type Spell
        public float projectileSpeed;
        public GameObject projectilePrefab;
        public float projectileLifeSpawn;
        
        //Aeo type Spell
        public float aoeDistanceFromCastingPoint;
        public float aoeLifeSpawn;
        public float aoeRadius;
        public GameObject aoePrefab;
        
        //Dash type Spell
        public float dashChargeSpeed;
        public float dashMaxChargeTime;
        public float dashStoppedTime;
        public GameObject dashTrailPrefab;
        public float dashTrailLifeSpawn;

        //Buff type Spell

        //Aeo debuff type Spell

        //Projectile explosion type Spell
        public GameObject projectileExplosionProjectilePrefab;
        public GameObject projectileExplosionAoePrefab;
        public float projectileExplosionProjectileSpeed;
        public float projectileExplosionProjectileLifeSpawn;
        public float projectileExplosionAoeLifeSpawn;
        public float projectileExplosionAoeRadius;
        
        //Change to Movement Speed
        public float changeToMovementSpeed;
        
        //Change to Light Attack
        public float changeToLightAttackDuration;
        public float changeToLightAttackMovementSpeed;
        public float changeToLightAttackCooldown;
        public float changeToLightAttackRange;
        public float changeToLightAttackRadius;
        
        //Change to Heavy Attack
        public float changeToHeavyAttackDuration;
        public float changeToHeavyAttackMovementSpeed;
        public float changeToHeavyAttackCooldown;
        public float changeToHeavyAttackRange;
        public float changeToHeavyAttackRadius;
        
        //Change to Charge
        public float changeToChargeSpeed;
        public float changeToChargeMaxChargeTime;
        public float changeToChargeStoppedTime;
        public float changeToChargeCooldown;
        public bool canDoubleCharge;
        


    }
}
