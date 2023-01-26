using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Base.Data
{
    public class ComboSpellData
    {
        public int id;
        
        public string comboSpellName = "Default";

        public float castingComboSpellDuration;
        public float castingComboSpellMovementSpeedMultiplier;
        public float castingComboSpellCooldown;
        public float castingComboSpellDirectionLockDuration;
    }
}
