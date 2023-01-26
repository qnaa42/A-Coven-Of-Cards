using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Spells_Control_Layer.Base.Data;

namespace Assets.Scripts.Spells_Control_Layer
{
    public class SpellsManager : MonoBehaviour
    {
        public SpellsStatsManager spellsStatsManager;
        public BaseSpellManager baseSpellManager;
        
        public ComboSpellsStatsManager comboSpellsStatsManager;
        public BaseComboSpellManager baseComboSpellManager;
        
        private Dictionary<string, List<float>> SpellBook;
        private Dictionary<string, List<float>> ComboSpellBook;
        public int Spell1Id = 1;
        public int Spell2Id = 2;
        public int Spell3Id = 3;

        public void InitializeSpellList()
        {
            SpellBook = new Dictionary<string, List<float>>
            {
                { "Spell1", new List<float> {1.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell2", new List<float> {2.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell3", new List<float> {3.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell4", new List<float> {0.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell5", new List<float> {1.0f, 0.05f, 1.8f, 2.0f} },
                { "Spell6", new List<float> {5.0f, 0.05f, 1.8f, 2.0f} },
                { "Spell7", new List<float> {1.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell8", new List<float> {2.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell9", new List<float> {3.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell10", new List<float> {0.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell11", new List<float> {1.0f, 0.05f, 1.8f, 2.0f} },
                { "Spell12", new List<float> {5.0f, 0.05f, 1.8f, 2.0f} },
                { "Spell13", new List<float> {1.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell14", new List<float> {2.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell15", new List<float> {3.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell16", new List<float> {0.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell17", new List<float> {1.0f, 0.05f, 1.8f, 2.0f} },
                { "Spell18", new List<float> {5.0f, 0.05f, 1.8f, 2.0f} },
                { "Spell19", new List<float> {1.5f, 0.05f, 1.5f, 2.0f} },
                { "Spell20", new List<float> {2.5f, 0.05f, 1.5f, 2.0f} }
            };
            baseSpellManager.ResetSpells();
            foreach (var item in SpellBook)
            {
                baseSpellManager.AddNewSpell(item.Key, item.Value[0], item.Value[1], item.Value[2], item.Value[3]);
            }
            
            
            
        }

        public void InitializeComboSpellList()
        {
            ComboSpellBook = new Dictionary<string, List<float>>
            {
                { "ComboSpell1", new List<float> { 1.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell2", new List<float> { 2.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell3", new List<float> { 3.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell4", new List<float> { 0.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell5", new List<float> { 1.0f, 0.05f, 1.8f, 2.0f } },
                { "ComboSpell6", new List<float> { 5.0f, 0.05f, 1.8f, 2.0f } },
                { "ComboSpell7", new List<float> { 1.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell8", new List<float> { 2.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell9", new List<float> { 3.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell10", new List<float> { 0.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell11", new List<float> { 1.0f, 0.05f, 1.8f, 2.0f } },
                { "ComboSpell12", new List<float> { 5.0f, 0.05f, 1.8f, 2.0f } },
                { "ComboSpell13", new List<float> { 1.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell14", new List<float> { 1.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell15", new List<float> { 2.5f, 0.05f, 1.5f, 2.0f } },
                { "ComboSpell16", new List<float> { 3.5f, 0.05f, 1.5f, 2.0f } },
            };
            
            baseComboSpellManager.ResetComboSpells();

            foreach (var ComboSpell in ComboSpellBook)
            {
                baseComboSpellManager.AddNewComboSpell(ComboSpell.Key, ComboSpell.Value[0], ComboSpell.Value[1], ComboSpell.Value[2], ComboSpell.Value[3]);
            }
        }
    }
}
