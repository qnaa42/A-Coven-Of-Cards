using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Spells_Control_Layer
{
    public class SpellsManager : MonoBehaviour
    {
        public SpellsStatsManager spellsStatsManager;
        public BaseSpellManager baseSpellManager;

        private Dictionary<string, List<float>> SpellBook;
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
                { "Spell6", new List<float> {5.0f, 0.05f, 1.8f, 2.0f} }
            };
            baseSpellManager.ResetSpells();
            foreach (var item in SpellBook)
            {
                baseSpellManager.AddNewSpell(item.Key, item.Value[0], item.Value[1], item.Value[2], item.Value[3]);
            }
            
        }
    }
}
