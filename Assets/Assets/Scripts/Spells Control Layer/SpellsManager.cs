using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Spells_Control_Layer.Base.Data;
using Assets.Scripts.Scriptable_Objects;

namespace Assets.Scripts.Spells_Control_Layer
{
    public class SpellsManager : MonoBehaviour
    {
        public SpellsStatsManager spellsStatsManager;
        public BaseSpellManager baseSpellManager;
        
        public ComboSpellsStatsManager comboSpellsStatsManager;
        public BaseComboSpellManager baseComboSpellManager;

        public List<Spell> spellList;
        public List<ComboSpell> comboSpellList;
        
        
        public int Spell1Id = 0;
        public int Spell2Id = 1;
        public int Spell3Id = 2;

        //Initializing Spell Data Manager from list of scriptable objects Spell
        public void InitializeSpellList()
        {
            baseSpellManager.ResetSpells();
            foreach (var spell in spellList)
            {
                baseSpellManager.AddNewSpell
                    (
                        spell.spellName, 
                        spell.element,
                        spell.spellDescription,
                        spell.castingSpellDuration, 
                        spell.castingSpellMovementSpeedMultiplier, 
                        spell.castingSpellCooldown, 
                        spell.castingSpellDirectionLockDuration
                    );
            }
        }

        //Initializing Combo Spell Data Manager from list of scriptable objects ComboSpell
        public void InitializeComboSpellList()
        {

            baseComboSpellManager.ResetComboSpells();

            foreach (var comboSpell in comboSpellList)
            {
                baseComboSpellManager.AddNewComboSpell
                    (
                        comboSpell.comboSpellName, 
                        comboSpell.castingComboSpellDuration, 
                        comboSpell.castingComboSpellMovementSpeedMultiplier, 
                        comboSpell.castingComboSpellCooldown, 
                        comboSpell.castingComboSpellDirectionLockDuration
                    );
            }
        }
    }
}
