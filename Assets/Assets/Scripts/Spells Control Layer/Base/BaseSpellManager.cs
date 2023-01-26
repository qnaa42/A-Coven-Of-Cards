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

        public int AddNewSpell(string _name, float _castingSpellDuration, float _castingSpellMovementSpeedMultiplier, float _castingSpellCooldown, float _castingSpellDirectionLockDuration)
        {
            if (!didInit)
                Init();

            var newSpell = new SpellData
            {
                id = global_SpellDatas.Count,
                spellName = _name,

                castingSpellDuration = _castingSpellDuration,
                castingSpellMovementSpeedMultiplier = _castingSpellMovementSpeedMultiplier,
                castingSpellCooldown = _castingSpellCooldown,
                castingSpellDirectionLockDuration = _castingSpellDirectionLockDuration,
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
    }
}
