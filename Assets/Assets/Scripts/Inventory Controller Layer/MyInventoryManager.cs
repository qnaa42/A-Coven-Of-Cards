using Assets.Scripts.Character_Controller_Layer;
using Assets.Scripts.Core_Layer;
using DevionGames.InventorySystem;
using UnityEngine;
using Assets.Scripts.Core_Layer;
using Assets.Scripts.Spells_Control_Layer;

namespace Assets.Scripts.Inventory_Controller_Layer
{
    public class MyInventoryManager : MonoBehaviour
    {
        public int Robe1ItemId = -1;
        public int Robe2ItemId = -1;
        public int Robe3ItemId = -1;

        public int Dagger1ItemId = -1;
        public int Dagger2ItemId = -1;
        public int Dagger3ItemId = -1;



        public void UpdateRobeTarotInventoryOnAdd(Slot slot)
        {
            var spellId = slot.ObservedItem.FindProperty("ID").GetValue();
            var spellManager = GameManager.instance.spellsControlManager.spellsStatsManager;
            var userManager = GameManager.instance.userManager;
            Debug.Log("spellId: " + spellId);
            var spellIdInt = int.Parse(spellId.ToString());
            switch (slot.Container.Name)
            {
                case "Robe Inventory 1":
                    Debug.Log("adding item to robe 1");
                    Robe1ItemId = spellIdInt;
                    break;
                case "Robe Inventory 2":
                    Robe2ItemId = spellIdInt;
                    break;
                case "Robe Inventory 3":
                    Robe3ItemId = spellIdInt;
                    break;
            }

            spellManager.SetSpellDetails(spellIdInt);
            userManager.AddMovementSpeed(spellManager.GetChangeToMovementSpeed());
            //Change to Charge 
            //Change to Charge Speed
            userManager.AddChargeSpeed(spellManager.GetChangeToChargeSpeed());
            //Change to Max Charge Time
            userManager.AddMaxChargeTime(spellManager.GetChangeToMaxChargeTime());
            //Change to Stopped Time
            userManager.AddStoppedTime(spellManager.GetChangeToChargeStoppedTime());
            //Change to Charge Cooldown
            userManager.AddChargeCooldown(spellManager.GetChangeToChargeCooldown());
            //Change to Can Double Charge
            userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
            GameManager.instance.uiManager.UpdateTarotUi();
        }

        public void UpdateRobeTarotInventoryOnRemove(Slot slot)
        {
            int spellId;
            var spellManager = GameManager.instance.spellsManager;
            var userManager = GameManager.instance.userManager;
            int spellIdInt;
            switch (slot.Container.Name)
            {
                case "Robe Inventory 1":
                    spellIdInt = Robe1ItemId;
                    Debug.Log("Im removing item from robe 1 with Id" + spellIdInt);
                    spellManager.SetSpellDetails(spellIdInt);
                    //change To Movement Speed
                    userManager.SubtractMovementSpeed(spellManager.GetChangeToMovementSpeed());
                    //Change to Charge 
                    //Change to Charge Speed
                    userManager.SubtractChargeSpeed(spellManager.GetChangeToChargeSpeed());
                    //Change to Max Charge Time
                    userManager.SubtractMaxChargeTime(spellManager.GetChangeToMaxChargeTime());
                    //Change to Stopped Time
                    userManager.SubtractStoppedTime(spellManager.GetChangeToChargeStoppedTime());
                    //Change to Charge Cooldown
                    userManager.SubtractChargeCooldown(spellManager.GetChangeToChargeCooldown());
                    //Change to Can Double Charge
                    if (spellManager.GetCanDoubleCharge())
                    {
                        if (Robe2ItemId != -1 || Robe3ItemId != -1)
                        {
                            if (Robe2ItemId >= 0)
                            {
                                spellId = Robe2ItemId;
                                spellManager.SetSpellDetails(spellId);
                                userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
                            }
                            else if (Robe3ItemId >= 0)
                            {
                                spellId = Robe3ItemId;
                                spellManager.SetSpellDetails(spellId);
                                userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
                            }
                        }
                        else
                        {
                            userManager.SetCanDoubleCharge(false);
                        }
                    }

                    GameManager.instance.uiManager.UpdateTarotUi();
                    Robe1ItemId = -1;
                    break;
                case "Robe Inventory 2":
                    spellIdInt = Robe2ItemId;
                    Debug.Log("Im removing item from robe 1 with Id" + spellIdInt);
                    spellManager.SetSpellDetails(spellIdInt);
                    //change To Movement Speed
                    userManager.SubtractMovementSpeed(spellManager.GetChangeToMovementSpeed());
                    //Change to Charge 
                    //Change to Charge Speed
                    userManager.SubtractChargeSpeed(spellManager.GetChangeToChargeSpeed());
                    //Change to Max Charge Time
                    userManager.SubtractMaxChargeTime(spellManager.GetChangeToMaxChargeTime());
                    //Change to Stopped Time
                    userManager.SubtractStoppedTime(spellManager.GetChangeToChargeStoppedTime());
                    //Change to Charge Cooldown
                    userManager.SubtractChargeCooldown(spellManager.GetChangeToChargeCooldown());
                    //Change to Can Double Charge
                    if (spellManager.GetCanDoubleCharge())
                    {
                        if (Robe1ItemId != -1 || Robe3ItemId != -1)
                        {
                            if (Robe1ItemId >= 0)
                            {
                                spellId = Robe1ItemId;
                                spellManager.SetSpellDetails(spellId);
                                userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
                            }
                            else if (Robe3ItemId >= 0)
                            {
                                spellId = Robe3ItemId;
                                spellManager.SetSpellDetails(spellId);
                                userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
                            }
                        }
                        else
                        {
                            userManager.SetCanDoubleCharge(false);
                        }
                    }

                    GameManager.instance.uiManager.UpdateTarotUi();
                    Robe2ItemId = -1;
                    break;
                case "Robe Inventory 3":
                    spellIdInt = Robe3ItemId;
                    Debug.Log("Im removing item from robe 1 with Id" + spellIdInt);
                    spellManager.SetSpellDetails(spellIdInt);
                    //change To Movement Speed
                    userManager.SubtractMovementSpeed(spellManager.GetChangeToMovementSpeed());
                    //Change to Charge 
                    //Change to Charge Speed
                    userManager.SubtractChargeSpeed(spellManager.GetChangeToChargeSpeed());
                    //Change to Max Charge Time
                    userManager.SubtractMaxChargeTime(spellManager.GetChangeToMaxChargeTime());
                    //Change to Stopped Time
                    userManager.SubtractStoppedTime(spellManager.GetChangeToChargeStoppedTime());
                    //Change to Charge Cooldown
                    userManager.SubtractChargeCooldown(spellManager.GetChangeToChargeCooldown());
                    //Change to Can Double Charge
                    if (spellManager.GetCanDoubleCharge())
                    {
                        if (Robe1ItemId != -1 || Robe2ItemId != -1)
                        {
                            if (Robe1ItemId >= 0)
                            {
                                spellId = Robe2ItemId;
                                spellManager.SetSpellDetails(spellId);
                                userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
                            }
                            else if (Robe2ItemId >= 0)
                            {
                                spellId = Robe2ItemId;
                                spellManager.SetSpellDetails(spellId);
                                userManager.SetCanDoubleCharge(spellManager.GetCanDoubleCharge());
                            }
                        }
                        else
                        {
                            userManager.SetCanDoubleCharge(false);
                        }
                    }

                    GameManager.instance.uiManager.UpdateTarotUi();
                    Robe3ItemId = -1;
                    break;
            }
        }

        //Update Dagger tarot inventory on add
        public void UpdateDaggerTarotInventoryOnAdd(Slot slot)
        {
            var spellId = slot.ObservedItem.FindProperty("ID").GetValue();
            var spellManager = GameManager.instance.spellsControlManager.spellsStatsManager;
            var userManager = GameManager.instance.userManager;
            Debug.Log("spellId: " + spellId);
            var spellIdInt = int.Parse(spellId.ToString());
            switch (slot.Container.Name)
            {
                case "Athame Inventory 1":
                    Dagger1ItemId = spellIdInt;
                    break;
                case "Athame Inventory 2":
                    Dagger2ItemId = spellIdInt;
                    break;
                case "Athame Inventory 3":
                    Dagger3ItemId = spellIdInt;
                    break;
            }

            spellManager.SetSpellDetails(spellIdInt);
            //Change to Light Attack
            //Change to Light Attack Duration
            userManager.AddLightAttackDuration(spellManager.GetChangeToLightAttackDuration());
            //Change to Light Attack Movement Speed
            userManager.AddLightAttackMovementSpeedMultiplier(spellManager.GetChangeToLightAttackMovementSpeed());
            //Change to Light Attack Cooldown
            userManager.AddLightAttackCooldown(spellManager.GetChangeToLightAttackCooldown());
            //Change to Light Attack Range
            userManager.AddLightAttackRange(spellManager.GetChangeToLightAttackRange());
            //Change to Light Attack Radius
            userManager.AddLightAttackRadius(spellManager.GetChangeToLightAttackRadius());
            //Change to Heavy Attack
            //Change to Heavy Attack Duration
            userManager.AddHeavyAttackDuration(spellManager.GetChangeToHeavyAttackDuration());
            //Change to Heavy Attack Movement Speed
            userManager.AddHeavyAttackMovementSpeedMultiplier(spellManager.GetChangeToHeavyAttackMovementSpeed());
            //Change to Heavy Attack Cooldown
            userManager.AddHeavyAttackCooldown(spellManager.GetChangeToHeavyAttackCooldown());
            //Change to Heavy Attack Range
            userManager.AddHeavyAttackRange(spellManager.GetChangeToHeavyAttackRange());
            //Change to Heavy Attack Radius
            userManager.AddHeavyAttackRadius(spellManager.GetChangeToHeavyAttackRadius());
            GameManager.instance.uiManager.UpdateTarotUi();
        }

        public void UpdateDaggerInventoryOnRemove(Slot slot)
        {
            var spellManager = GameManager.instance.spellsControlManager.spellsStatsManager;
            var userManager = GameManager.instance.userManager;
            int spellIdInt;
            switch (slot.Container.Name)
            {
                case "Athame Inventory 1":
                    spellIdInt = Dagger1ItemId;
                    Debug.Log("Im removing item from robe 1 with Id" + spellIdInt);
                    spellManager.SetSpellDetails(spellIdInt);
                    //Change to Light Attack
                    //Change to Light Attack Duration
                    userManager.SubtractLightAttackDuration(spellManager.GetChangeToLightAttackDuration());
                    //Change to Light Attack Movement Speed
                    userManager.SubtractLightAttackMovementSpeedMultiplier(spellManager
                        .GetChangeToLightAttackMovementSpeed());
                    //Change to Light Attack Cooldown
                    userManager.SubtractLightAttackCooldown(spellManager.GetChangeToLightAttackCooldown());
                    //Change to Light Attack Range
                    userManager.SubtractLightAttackRange(spellManager.GetChangeToLightAttackRange());
                    //Change to Light Attack Radius
                    userManager.SubtractLightAttackRadius(spellManager.GetChangeToLightAttackRadius());
                    //Change to Heavy Attack
                    //Change to Heavy Attack Duration
                    userManager.SubtractHeavyAttackDuration(spellManager.GetChangeToHeavyAttackDuration());
                    //Change to Heavy Attack Movement Speed
                    userManager.SubtractHeavyAttackMovementSpeedMultiplier(spellManager
                        .GetChangeToHeavyAttackMovementSpeed());
                    //Change to Heavy Attack Cooldown
                    userManager.SubtractHeavyAttackCooldown(spellManager.GetChangeToHeavyAttackCooldown());
                    //Change to Heavy Attack Range
                    userManager.SubtractHeavyAttackRange(spellManager.GetChangeToHeavyAttackRange());
                    //Change to Heavy Attack Radius
                    userManager.SubtractHeavyAttackRadius(spellManager.GetChangeToHeavyAttackRadius());
                    GameManager.instance.uiManager.UpdateTarotUi();
                    Dagger1ItemId = -1;
                    break;
                case "Athame Inventory 2":
                    spellIdInt = Dagger2ItemId;
                    Debug.Log("Im removing item from robe 1 with Id" + spellIdInt);
                    spellManager.SetSpellDetails(spellIdInt);
                    //Change to Light Attack
                    //Change to Light Attack Duration
                    userManager.SubtractLightAttackDuration(spellManager.GetChangeToLightAttackDuration());
                    //Change to Light Attack Movement Speed
                    userManager.SubtractLightAttackMovementSpeedMultiplier(spellManager
                        .GetChangeToLightAttackMovementSpeed());
                    //Change to Light Attack Cooldown
                    userManager.SubtractLightAttackCooldown(spellManager.GetChangeToLightAttackCooldown());
                    //Change to Light Attack Range
                    userManager.SubtractLightAttackRange(spellManager.GetChangeToLightAttackRange());
                    //Change to Light Attack Radius
                    userManager.SubtractLightAttackRadius(spellManager.GetChangeToLightAttackRadius());
                    //Change to Heavy Attack
                    //Change to Heavy Attack Duration
                    userManager.SubtractHeavyAttackDuration(spellManager.GetChangeToHeavyAttackDuration());
                    //Change to Heavy Attack Movement Speed
                    userManager.SubtractHeavyAttackMovementSpeedMultiplier(spellManager
                        .GetChangeToHeavyAttackMovementSpeed());
                    //Change to Heavy Attack Cooldown
                    userManager.SubtractHeavyAttackCooldown(spellManager.GetChangeToHeavyAttackCooldown());
                    //Change to Heavy Attack Range
                    userManager.SubtractHeavyAttackRange(spellManager.GetChangeToHeavyAttackRange());
                    //Change to Heavy Attack Radius
                    userManager.SubtractHeavyAttackRadius(spellManager.GetChangeToHeavyAttackRadius());
                    GameManager.instance.uiManager.UpdateTarotUi();
                    Dagger2ItemId = -1;
                    break;
                case "Athame Inventory 3":
                    spellIdInt = Dagger3ItemId;
                    Debug.Log("Im removing item from robe 1 with Id" + spellIdInt);
                    spellManager.SetSpellDetails(spellIdInt);
                    //Change to Light Attack
                    //Change to Light Attack Duration
                    userManager.SubtractLightAttackDuration(spellManager.GetChangeToLightAttackDuration());
                    //Change to Light Attack Movement Speed
                    userManager.SubtractLightAttackMovementSpeedMultiplier(spellManager
                        .GetChangeToLightAttackMovementSpeed());
                    //Change to Light Attack Cooldown
                    userManager.SubtractLightAttackCooldown(spellManager.GetChangeToLightAttackCooldown());
                    //Change to Light Attack Range
                    userManager.SubtractLightAttackRange(spellManager.GetChangeToLightAttackRange());
                    //Change to Light Attack Radius
                    userManager.SubtractLightAttackRadius(spellManager.GetChangeToLightAttackRadius());
                    //Change to Heavy Attack
                    //Change to Heavy Attack Duration
                    userManager.SubtractHeavyAttackDuration(spellManager.GetChangeToHeavyAttackDuration());
                    //Change to Heavy Attack Movement Speed
                    userManager.SubtractHeavyAttackMovementSpeedMultiplier(spellManager
                        .GetChangeToHeavyAttackMovementSpeed());
                    //Change to Heavy Attack Cooldown
                    userManager.SubtractHeavyAttackCooldown(spellManager.GetChangeToHeavyAttackCooldown());
                    //Change to Heavy Attack Range
                    userManager.SubtractHeavyAttackRange(spellManager.GetChangeToHeavyAttackRange());
                    //Change to Heavy Attack Radius
                    userManager.SubtractHeavyAttackRadius(spellManager.GetChangeToHeavyAttackRadius());
                    GameManager.instance.uiManager.UpdateTarotUi();
                    Dagger3ItemId = -1;
                    break;
            }
        }
    }
}
