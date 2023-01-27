using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Combo Spell", menuName = "Combo Spell")]
    public class ComboSpell : ScriptableObject
    {
        public string comboSpellName = "Default";
        
        
        public float castingComboSpellDuration;
        public float castingComboSpellMovementSpeedMultiplier;
        public float castingComboSpellCooldown;
        public float castingComboSpellDirectionLockDuration;
    }
}
