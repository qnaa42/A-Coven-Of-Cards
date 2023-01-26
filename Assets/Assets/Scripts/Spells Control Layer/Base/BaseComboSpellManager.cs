using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base.Data;
using UnityEngine;


namespace Assets.Scripts.Spells_Control_Layer.Base
{
    public class BaseComboSpellManager : MonoBehaviour
    {
        private static List<ComboSpellData> global_ComboSpellDatas;
        
        private bool didInit { get; set; }
        
        private void Init()
        {
            global_ComboSpellDatas ??= new List<ComboSpellData>();
            
            didInit = true;
        }
        
        public void ResetComboSpells()
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas = new List<ComboSpellData>();
        }
        
        public List<ComboSpellData> GetComboSpellList()
        {
            if (global_ComboSpellDatas == null)
                Init();

            return global_ComboSpellDatas;
        }
        
        public int AddNewComboSpell(string _name, float _castingComboSpellDuration, float _castingComboSpellMovementSpeedMultiplier, float _castingComboSpellCooldown, float _castingComboSpellDirectionLockDuration)
        {
            if (!didInit)
                Init();

            var newComboSpell = new ComboSpellData
            {
                id = global_ComboSpellDatas.Count,
                comboSpellName = _name,

                castingComboSpellDuration = _castingComboSpellDuration,
                castingComboSpellMovementSpeedMultiplier = _castingComboSpellMovementSpeedMultiplier,
                castingComboSpellCooldown = _castingComboSpellCooldown,
                castingComboSpellDirectionLockDuration = _castingComboSpellDirectionLockDuration,
            };
            
            global_ComboSpellDatas.Add(newComboSpell);
            
            return newComboSpell.id;
        }
        
        //Name
        public string GetComboSpellName(int id)
        {
            if (!didInit)
                Init();

            return global_ComboSpellDatas[id].comboSpellName;
        }
        
        public void SetComboSpellName(int id, string aName)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].comboSpellName = aName;
        }

        //Casting Combo Spell Duration
        public float GetCastingComboSpellDuration(int id)
        {
            if (!didInit)
                Init();

            return global_ComboSpellDatas[id].castingComboSpellDuration;
        }
        
        public void SetCastingComboSpellDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellDuration = anAmount;
        }
        
        public void AddCastingComboSpellDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellDuration += anAmount;
        }
        
        public void SubtractCastingComboSpellDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellDuration -= anAmount;
        }
        
        //Casting Combo Spell Movement Speed Multiplier
        public float GetCastingComboSpellMovementSpeedMultiplier(int id)
        {
            if (!didInit)
                Init();

            return global_ComboSpellDatas[id].castingComboSpellMovementSpeedMultiplier;
        }
        
        public void SetCastingComboSpellMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellMovementSpeedMultiplier = anAmount;
        }
        
        public void AddCastingComboSpellMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellMovementSpeedMultiplier += anAmount;
        }
        
        public void SubtractCastingComboSpellMovementSpeedMultiplier(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellMovementSpeedMultiplier -= anAmount;
        }
        
        //Casting Combo Spell Cooldown
        public float GetCastingComboSpellCooldown(int id)
        {
            if (!didInit)
                Init();

            return global_ComboSpellDatas[id].castingComboSpellCooldown;
        }
        
        public void SetCastingComboSpellCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellCooldown = anAmount;
        }
        
        public void AddCastingComboSpellCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellCooldown += anAmount;
        }
        
        public void SubtractCastingComboSpellCooldown(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellCooldown -= anAmount;
        }
        
        //Casting Combo Spell Direction Lock Duration
        public float GetCastingComboSpellDirectionLockDuration(int id)
        {
            if (!didInit)
                Init();

            return global_ComboSpellDatas[id].castingComboSpellDirectionLockDuration;
        }
        
        public void SetCastingComboSpellDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellDirectionLockDuration = anAmount;
        }
        
        public void AddCastingComboSpellDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellDirectionLockDuration += anAmount;
        }
        
        public void SubtractCastingComboSpellDirectionLockDuration(int id, float anAmount)
        {
            if (!didInit)
                Init();

            global_ComboSpellDatas[id].castingComboSpellDirectionLockDuration -= anAmount;
        }
    }
}
