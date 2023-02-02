using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Spells_Control_Layer.Base;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Core_Layer;
using Assets.Scripts.Spells_Control_Layer.Base.Data;
using Assets.Scripts.Scriptable_Objects;
using Assets.Scripts.Spells_Control_Layer.Misc;

namespace Assets.Scripts.Spells_Control_Layer
{
    public class SpellsManager : MonoBehaviour
    {
        public Transform castingPoint;
        
        public SpellsStatsManager spellsStatsManager;
        public BaseSpellManager baseSpellManager;
        
        
        public ComboSpellsStatsManager comboSpellsStatsManager;
        public BaseComboSpellManager baseComboSpellManager;

        public List<Spell> spellList;
        public List<ComboSpell> comboSpellList;
        

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
                        spell.spellType,
                        spell.castingSpellDuration, 
                        spell.castingSpellMovementSpeedMultiplier, 
                        spell.castingSpellCooldown, 
                        spell.castingSpellDirectionLockDuration,
                        //Projectile type Spell
                        spell.projectileSpeed,
                        spell.projectilePrefab,
                        spell.projectileLifeSpawn,
                        //Aeo type Spell
                        spell.aoeProjectileDistanceFromCastingPoint,
                        spell.aoeLifeSpawn,
                        spell.aoeRadius,
                        spell.aoePrefab,
                        //Dash type Spell
                        spell.dashChargeSpeed,
                        spell.dashMaxChargeTime,
                        spell.dashStoppedTime,
                        spell.dashTrailPrefab,
                        spell.dashTrailLifeSpawn,
                        //Projectile explosion type Spell
                        spell.projectileExplosionProjectilePrefab,
                        spell.projectileExplosionAoePrefab,
                        spell.projectileExplosionProjectileSpeed,
                        spell.projectileExplosionProjectileLifeSpawn,
                        spell.projectileExplosionAoeLifeSpawn,
                        spell.projectileExplosionAoeRadius
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

        public void CastSpell()
        {
            if (spellsStatsManager.GetSpellType() == 0)
            {
                
            }
            else if (spellsStatsManager.GetSpellType() == 1)
            {
                //Projectile type Spell
                var spellPrefab = spellsStatsManager.GetProjectilePrefab();
                var spell = Instantiate(spellPrefab, castingPoint.position, spellPrefab.transform.rotation);
                spell.AddComponent<Projectile>();
                var spellRB = spell.GetComponent<Rigidbody>();
                spellRB.AddForce(castingPoint.forward * spellsStatsManager.GetProjectileSpeed(), ForceMode.Impulse);
                
            }
            else if (spellsStatsManager.GetSpellType() == 2)
            {
                //Aeo type Spell
                var aoePrefab = spellsStatsManager.GetAoePrefab();
                var aoe = Instantiate(aoePrefab, castingPoint.position , aoePrefab.transform.rotation);
                aoe.transform.position += castingPoint.forward * spellsStatsManager.GetAoeDistanceFromCastingPoint();
                aoe.AddComponent<Aoe>();
            }
            else if (spellsStatsManager.GetSpellType() == 3)
            {
                var dashTrailPrefab = spellsStatsManager.GetDashTrailPrefab();
                var dashTrail = Instantiate(dashTrailPrefab, castingPoint.position, castingPoint.rotation);
                dashTrail.transform.position += castingPoint.forward * -(spellsStatsManager.GetDashChargeSpeed()/5.5f);
                dashTrail.AddComponent<DashTrail>();
                
            }
            else if (spellsStatsManager.GetSpellType() == 4)
            {
                
            }
            else if (spellsStatsManager.GetSpellType() == 5)
            {
                
            }
            else if (spellsStatsManager.GetSpellType() == 6)
            {
                var projectileExplosionProjectilePrefab = spellsStatsManager.GetProjectileExplosionProjectilePrefab();
                var projectileExplosionProjectile = Instantiate(projectileExplosionProjectilePrefab, castingPoint.position, projectileExplosionProjectilePrefab.transform.rotation);
                projectileExplosionProjectile.AddComponent<ProjectileExplosionProjectile>();
                var projectileExplosionProjectileRB = projectileExplosionProjectile.GetComponent<Rigidbody>();
                projectileExplosionProjectileRB.AddForce(castingPoint.forward * spellsStatsManager.GetProjectileExplosionProjectileSpeed(), ForceMode.Impulse);
            }
            
            
        }
    }
}
