using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character_Controller_Layer;
using Assets.Scripts.Character_Controller_Layer.Base.Data;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Character_Controller_Layer
{
    public class BaseUserManager : MonoBehaviour
    {
        private static List<UserData> global_UserDatas;

        private bool didInit { get; set; }

        private void Init()
        {
            global_UserDatas ??= new List<UserData>();

            didInit = true;
        }
        
        public void ResetUsers()
        {
            if (!didInit)
                Init();

            global_UserDatas = new List<UserData>();
        }
        
        public List<UserData> GetPlayerList()
        {
            if (global_UserDatas == null)
                Init();

            return global_UserDatas;
        }
        
        public int AddNewPlayer(
        string playerName,
        //Movement
        float movementSpeed,
        float globalMovementSpeedMultiplier,
        float meleeMovementSpeedMultiplier,
        float castingMovementSpeedMultiplier,
        float stableMovementSharpness,
        float orientationSharpness,
        //Light Attack
        float lightAttackDuration,
        float lightAttackMovementSpeedMultiplier,
        float lightAttackCooldown,
        float lightAttackDirectionLockDuration,
        float lightAttackRange,
        float lightAttackRadius,
        //Heavy Attack
        float heavyAttackDuration,
        float heavyAttackMovementSpeedMultiplier,
        float heavyAttackCooldown,
        float heavyAttackDirectionLockDuration,
        float heavyAttackRange,
        float heavyAttackRadius,
        //Charging
        float chargeSpeed,
        float maxChargeTime,
        float stoppedTime,
        float chargeCooldown,
        bool canDoubleCharge,
        
        //Casting
        int castingSpell1Id,
        int castingSpell2Id,
        int castingSpell3Id,
        
        
        int score,
        int health
            )
        {
            if (!didInit)
                Init();

            var newUser = new UserData
            {
                id = global_UserDatas.Count,
                
                playerName = playerName,
                //Movement
                movementSpeed = movementSpeed,
                globalMovementSpeedMultiplier = globalMovementSpeedMultiplier,
                meleeMovementSpeedMultiplier = meleeMovementSpeedMultiplier,
                castingMovementSpeedMultiplier = castingMovementSpeedMultiplier,
                stableMovementSharpness = stableMovementSharpness,
                orientationSharpness = orientationSharpness,
                //Light Attack
                lightAttackDuration = lightAttackDuration,
                lightAttackMovementSpeedMultiplier = lightAttackMovementSpeedMultiplier,
                lightAttackCooldown = lightAttackCooldown,
                lightAttackDirectionLockDuration = lightAttackDirectionLockDuration,
                lightAttackRange = lightAttackRange,
                lightAttackRadius = lightAttackRadius,
                //Heavy Attack
                heavyAttackDuration = heavyAttackDuration,
                heavyAttackMovementSpeedMultiplier = heavyAttackMovementSpeedMultiplier,
                heavyAttackCooldown = heavyAttackCooldown,
                heavyAttackDirectionLockDuration = heavyAttackDirectionLockDuration,
                heavyAttackRange = heavyAttackRange,
                heavyAttackRadius = heavyAttackRadius,
                //Charging
                chargeSpeed = chargeSpeed,
                maxChargeTime = maxChargeTime,
                stoppedTime = stoppedTime,
                chargeCooldown = chargeCooldown,
                canDoubleCharge = canDoubleCharge,
                //Casting
                castingSpell1Id = castingSpell1Id,
                castingSpell2Id = castingSpell2Id,
                castingSpell3Id = castingSpell3Id,
                
                score = score,
                health = health
            };

            global_UserDatas.Add(newUser);

            return newUser.id;
        }
        
        //Name
        public string GetName(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].playerName;
        }
        
        public void SetName(int id, string aName)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].playerName = name;
        }
        
        //Movement
        //Movement Speed
        public float GetMovementSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].movementSpeed;
        }
        
        public void SetMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].movementSpeed = anAmount;
        }
        
        public void AddMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].movementSpeed += anAmount;
        }
        
        public void SubtractMovementSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].movementSpeed -= anAmount;
        }
        
        //Global Movement Speed Multiplier
        public float GetGlobalMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].globalMovementSpeedMultiplier;
        }
        
        public void SetGlobalMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].globalMovementSpeedMultiplier = anAmount;
        }
        
        public void AddGlobalMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].globalMovementSpeedMultiplier += anAmount;
        }
        
        public void SubtractGlobalMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].globalMovementSpeedMultiplier -= anAmount;
        }
        
        //Melee Movement Speed Multiplier
        public float GetMeleeMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].meleeMovementSpeedMultiplier;
        }
        
        public void SetMeleeMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].meleeMovementSpeedMultiplier = anAmount;
        }
        
        public void AddMeleeMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].meleeMovementSpeedMultiplier += anAmount;
        }

        public void SubtractMeleeMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].meleeMovementSpeedMultiplier -= anAmount;
        }
        
        
        //Casting Movement Speed Multiplier
        public float GetCastingMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].castingMovementSpeedMultiplier;
        }
        
        public void SetCastingMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].castingMovementSpeedMultiplier = anAmount;
        }
        
        public void AddCastingMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].castingMovementSpeedMultiplier += anAmount;
        }
        
        public void SubtractCastingMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].castingMovementSpeedMultiplier -= anAmount;
        }
        
        //Stable Movement Sharpness
        public float GetStableMovementSharpness(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].stableMovementSharpness;
        }
        
        public void SetStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stableMovementSharpness = anAmount;
        }
        
        public void AddStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stableMovementSharpness += anAmount;
        }
        
        public void SubtractStableMovementSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stableMovementSharpness -= anAmount;
        }
        
        //Orientation Sharpness
        public float GetOrientationSharpness(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].orientationSharpness;
        }
        
        public void SetOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].orientationSharpness = anAmount;
        }
        
        public void AddOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].orientationSharpness += anAmount;
        }
        
        public void SubtractOrientationSharpness(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].orientationSharpness -= anAmount;
        }
        
        //Light Attack
        //Light Attack Duration
        public float GetLightAttackDuration(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].lightAttackDuration;
        }
        
        public void SetLightAttackDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackDuration = anAmount;
        }
        
        public void AddLightAttackDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackDuration += anAmount;
        }
        
        public void SubtractLightAttackDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackDuration -= anAmount;
        }
        
        //Light Attack Movement Speed Multiplier
        public float GetLightAttackMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].lightAttackMovementSpeedMultiplier;
        }
        
        public void SetLightAttackMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackMovementSpeedMultiplier = anAmount;
        }
        
        public void AddLightAttackMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackMovementSpeedMultiplier += anAmount;
        }
        
        public void SubtractLightAttackMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackMovementSpeedMultiplier -= anAmount;
        }
        
        //Light Attack Cooldown
        public float GetLightAttackCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].lightAttackCooldown;
        }
        
        public void SetLightAttackCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackCooldown = anAmount;
        }
        
        public void AddLightAttackCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackCooldown += anAmount;
        }
        
        public void SubtractLightAttackCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackCooldown -= anAmount;
        }
        
        //Light Attack Direction Lock Duration
        public float GetLightAttackDirectionLockDuration(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].lightAttackDirectionLockDuration;
        }
        
        public void SetLightAttackDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackDirectionLockDuration = anAmount;
        }
        
        public void AddLightAttackDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackDirectionLockDuration += anAmount;
        }
        
        public void SubtractLightAttackDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackDirectionLockDuration -= anAmount;
        }
        
        //Light Attack Range
        public float GetLightAttackRange(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].lightAttackRange;
        }
        
        public void SetLightAttackRange(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackRange = anAmount;
        }

        public void AddLightAttackRange(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackRange += anAmount;
        }
        
        public void SubtractLightAttackRange(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackRange -= anAmount;
        }
        
        //Light Attack Radius
        public float GetLightAttackRadius(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].lightAttackRadius;
        }
        
        public void SetLightAttackRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackRadius = anAmount;
        }
        
        public void AddLightAttackRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackRadius += anAmount;
        }
        
        public void SubtractLightAttackRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].lightAttackRadius -= anAmount;
        }
        
        
        
        //Heavy Attack
        //Heavy Attack Duration
        public float GetHeavyAttackDuration(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].heavyAttackDuration;
        }
        
        public void SetHeavyAttackDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackDuration = anAmount;
        }
        
        public void AddHeavyAttackDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackDuration += anAmount;
        }
        
        public void SubtractHeavyAttackDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackDuration -= anAmount;
        }
        
        //Heavy Attack Movement Speed Multiplier
        public float GetHeavyAttackMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].heavyAttackMovementSpeedMultiplier;
        }
        
        public void SetHeavyAttackMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackMovementSpeedMultiplier = anAmount;
        }
        
        public void AddHeavyAttackMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackMovementSpeedMultiplier += anAmount;
        }
        
        public void SubtractHeavyAttackMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackMovementSpeedMultiplier -= anAmount;
        }
        
        //Heavy Attack Cooldown
        public float GetHeavyAttackCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].heavyAttackCooldown;
        }
        
        public void SetHeavyAttackCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackCooldown = anAmount;
        }
        
        public void AddHeavyAttackCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackCooldown += anAmount;
        }
        
        public void SubtractHeavyAttackCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackCooldown -= anAmount;
        }
        
        //Heavy Attack Direction Lock Duration
        public float GetHeavyAttackDirectionLockDuration(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].heavyAttackDirectionLockDuration;
        }
        
        public void SetHeavyAttackDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackDirectionLockDuration = anAmount;
        }
        
        public void AddHeavyAttackDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackDirectionLockDuration += anAmount;
        }
        
        public void SubtractHeavyAttackDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackDirectionLockDuration -= anAmount;
        }
        
        //Heavy Attack Range
        public float GetHeavyAttackRange(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].heavyAttackRange;
        }
        
        public void SetHeavyAttackRange(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackRange = anAmount;
        }
        
        public void AddHeavyAttackRange(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackRange += anAmount;
        }
        
        public void SubtractHeavyAttackRange(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackRange -= anAmount;
        }
        
        //Heavy Attack Radius
        public float GetHeavyAttackRadius(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].heavyAttackRadius;
        }
        
        public void SetHeavyAttackRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackRadius = anAmount;
        }
        
        public void AddHeavyAttackRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackRadius += anAmount;
        }
        
        public void SubtractHeavyAttackRadius(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].heavyAttackRadius -= anAmount;
        }

        //Charging
        //Charge Speed
        public float GetChargeSpeed(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].chargeSpeed;
        }
        
        public void SetChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeSpeed = anAmount;
        }
        
        public void AddChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeSpeed += anAmount;
        }
        
        public void SubtractChargeSpeed(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeSpeed -= anAmount;
        }
        
        //Max Charge Time
        public float GetMaxChargeTime(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].maxChargeTime;
        }
        
        public void SetMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].maxChargeTime = anAmount;
        }
        
        public void AddMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].maxChargeTime += anAmount;
        }
        
        public void SubtractMaxChargeTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].maxChargeTime -= anAmount;
        }
        
        //Stopped Time
        public float GetStoppedTime(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].stoppedTime;
        }
        
        public void SetStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stoppedTime = anAmount;
        }
        
        public void AddStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stoppedTime += anAmount;
        }
        
        public void SubtractStoppedTime(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].stoppedTime -= anAmount;
        }
        
        //Charge Cooldown
        public float GetChargeCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].chargeCooldown;
        }
        
        public void SetChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeCooldown = anAmount;
        }
        
        public void AddChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeCooldown += anAmount;
        }
        
        public void SubtractChargeCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].chargeCooldown -= anAmount;
        }
        
        //Can Double Charge (bool)
        public bool GetCanDoubleCharge(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].canDoubleCharge;
        }
        
        public void SetCanDoubleCharge(int id, bool aBool)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].canDoubleCharge = aBool;
        }
        
        //Casting

        //Casting Spell 1 Id
        public int GetCastingSpell1Id(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].castingSpell1Id;
        }
        
        public void SetCastingSpell1Id(int id, int anId)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].castingSpell1Id = anId;
        }
        
        //Casting Spell 2 Id
        public int GetCastingSpell2Id(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].castingSpell2Id;
        }
        
        public void SetCastingSpell2Id(int id, int anId)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].castingSpell2Id = anId;
        }
        
        //Casting Spell 3 Id
        public int GetCastingSpell3Id(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].castingSpell3Id;
        }
        
        public void SetCastingSpell3Id(int id, int anId)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].castingSpell3Id = anId;
        }
        
        
        //Score
        public int GetScore(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].score;
        }
        
        public void SetScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].score = anAmount;
        }
        
        public void AddScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].score += anAmount;
        }
        
        public void SubtractScore(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].score -= anAmount;
        }
        
        //Health
        public int GetHealth(int id)
        {
            if (!didInit)
                Init();

            return global_UserDatas[id].health;
        }
        
        public void SetHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].health = anAmount;
        }
        
        public void AddHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].health += anAmount;
        }
        
        public void SubtractHealth(int id, int anAmount)
        {
            if (!didInit)
                Init();

            global_UserDatas[id].health -= anAmount;
        }
        
    }
}
