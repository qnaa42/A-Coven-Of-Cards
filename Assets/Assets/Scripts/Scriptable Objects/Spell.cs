using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
    public class Spell : ScriptableObject
    {
        public string spellName = "Default";
        
        public string element = "Default";
        
        public string spellDescription = "Default";

        //Where 0 = Default, 1 = Projectile, 2 = Aeo, 3 = Dash, 4 = Buff, 5 = Aeo Debuff, 6 = Projectile Explosion
        public int spellType;
        
        public float castingSpellDuration;
        public float castingSpellMovementSpeedMultiplier;
        public float castingSpellCooldown;
        public float castingSpellDirectionLockDuration;
        
        [Header("Projectile type Spell")]
        //Projectile type Spell
        public float projectileSpeed;
        public GameObject projectilePrefab;
        public float projectileLifeSpawn;
        
        [Header("Aoe type Spell")]
        //Aeo type Spell
        public float aoeProjectileDistanceFromCastingPoint;
        public float aoeLifeSpawn;
        public float aoeRadius;
        public GameObject aoePrefab;
        
        [Header("Dash type Spell")]
        //Dash type Spell
        public float dashChargeSpeed;
        public float dashMaxChargeTime;
        public float dashStoppedTime;
        public GameObject dashTrailPrefab;
        public float dashTrailLifeSpawn;
        
        [Header("Projectile Explosion type Spell")]
        //Projectile explosion type Spell
        public GameObject projectileExplosionProjectilePrefab;
        public GameObject projectileExplosionAoePrefab;
        public float projectileExplosionProjectileSpeed;
        public float projectileExplosionProjectileLifeSpawn;
        public float projectileExplosionAoeLifeSpawn;
        public float projectileExplosionAoeRadius;

    }
}
