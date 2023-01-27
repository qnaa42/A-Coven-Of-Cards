using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
    public class Spell : ScriptableObject
    {
        public string spellName = "Default";
        
        public string element = "Default";
        
        public string spellDescription = "Default";
        
        public float castingSpellDuration;
        public float castingSpellMovementSpeedMultiplier;
        public float castingSpellCooldown;
        public float castingSpellDirectionLockDuration;
    }
}
