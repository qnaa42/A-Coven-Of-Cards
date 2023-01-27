using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Base.Data
{
    public class SpellData
    {
        public int id;
        
        public string spellName = "Default";
        
        public string element = "Default";

        public float castingSpellDuration;
        public float castingSpellMovementSpeedMultiplier;
        public float castingSpellCooldown;
        public float castingSpellDirectionLockDuration;
    }
}
