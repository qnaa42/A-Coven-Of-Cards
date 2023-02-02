using UnityEngine;

namespace Assets.Scripts.Character_Controller_Layer.Base.Data
{
    public class UserData
    {
        public int id;

        public string playerName = "Default";

        //This is where all the data will go, from each player depended systems like character controller and such
        
        //Movement
        public float movementSpeed;
        public float globalMovementSpeedMultiplier;
        public float meleeMovementSpeedMultiplier;
        public float castingMovementSpeedMultiplier;
        public float stableMovementSharpness;
        public float orientationSharpness;
        
        //Light Attack
        public float lightAttackDuration;
        public float lightAttackMovementSpeedMultiplier;
        public float lightAttackCooldown;
        public float lightAttackDirectionLockDuration;
        public float lightAttackRange;
        public float lightAttackRadius;
        
        //Heavy Attack
        public float heavyAttackDuration;
        public float heavyAttackMovementSpeedMultiplier;
        public float heavyAttackCooldown;
        public float heavyAttackDirectionLockDuration;
        public float heavyAttackRange;
        public float heavyAttackRadius;
        
        
        //Charging
        public float chargeSpeed;
        public float maxChargeTime;
        public float stoppedTime;
        public float chargeCooldown;
        public bool canDoubleCharge;
        
        //Casting
        public int castingSpell1Id;
        public int castingSpell2Id;
        public int castingSpell3Id;
        
        
        
        
        public int score;
        public int health;
    }
}
