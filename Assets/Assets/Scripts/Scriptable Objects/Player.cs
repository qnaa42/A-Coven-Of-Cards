using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Player", menuName = "Player")]
    public class Player : ScriptableObject
    {
        public string playerName = "Default";
        
        [Header("Movement")]
        //Movement
        public float movementSpeed;
        public float globalMovementSpeedMultiplier;
        public float meleeMovementSpeedMultiplier;
        public float castingMovementSpeedMultiplier;
        public float stableMovementSharpness;
        public float orientationSharpness;
        
        [Header("Light Attack")]
        //Light Attack
        public float lightAttackDuration;
        public float lightAttackMovementSpeedMultiplier;
        public float lightAttackCooldown;
        public float lightAttackDirectionLockDuration;
        public float lightAttackRange;
        public float lightAttackRadius;
        
        [Header("Heavy Attack")]
        //Heavy Attack
        public float heavyAttackDuration;
        public float heavyAttackMovementSpeedMultiplier;
        public float heavyAttackCooldown;
        public float heavyAttackDirectionLockDuration;
        public float heavyAttackRange;
        public float heavyAttackRadius;
        
        [Header("Charging")]
        //Charging
        public float chargeSpeed;
        public float maxChargeTime;
        public float stoppedTime;
        public float chargeCooldown;
        public bool canDoubleCharge;
        
        [Header("Casting")]
        //Casting
        public int castingSpell1Id;
        public int castingSpell2Id;
        public int castingSpell3Id;
        
        
        
        public int score;
        public int health;
    }
}

