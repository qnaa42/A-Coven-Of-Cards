using System;
using System.Collections;
using System.Collections.Generic;
using Articy.A_Coven_Of_Cards.GlobalVariables;
using Articy.Unity;
using Assets.Scripts.Core_Layer;
using DevionGames.InventorySystem;
using UnityEngine;

public class MyNarrativeManager : MonoBehaviour
{
    public GameObject cauldron;
    public GameObject tarotInventory;
    public GameObject alembicInventory;
    public GameObject dreamScape;
    
    public ItemContainer inventory; 

    private bool _removedMinorPotions;
    private bool _activatedCauldron;
    private bool _activatedTarot;
    private bool _activatedAlembic;
    private bool _momSaveable;
    private bool _babySaveable;
    private bool _momSaved;
    private bool _babySaved;



    private void Update()
    {
        if (!_activatedCauldron && ArticyGlobalVariables.Default.gameState.act2)
        {
            cauldron.SetActive(true);
            _activatedCauldron = true;
        }

        if (!_activatedTarot && ArticyGlobalVariables.Default.gameState.act3)
        {
            tarotInventory.SetActive(true);
            _activatedTarot = true;
        }
        
        if(!_activatedAlembic && ArticyGlobalVariables.Default.gameState.act4)
        {
            alembicInventory.SetActive(true);
            _activatedAlembic = true;
        }

        if (!_momSaveable && ArticyGlobalVariables.Default.playerInventory.regentA > 0 && ArticyGlobalVariables.Default.playerInventory.regentB >0)
        {
            ArticyGlobalVariables.Default.gameState.motherCanSave = true;
            _momSaveable = true;
        }
        
        if (!_babySaveable && ArticyGlobalVariables.Default.playerInventory.regentC > 0 && ArticyGlobalVariables.Default.playerInventory.regentD >0)
        {
            ArticyGlobalVariables.Default.gameState.babyCanSave = true;
            _babySaveable = true;
        }
        

        if (!_removedMinorPotions && ArticyGlobalVariables.Default.gameState.healthPotFail)
        {
            for (int i = 0; i < 2; i++)
            {
                var healthPotion = InventoryManager.Database.items.Find(item => item.Name == "Minor Potion");
                inventory.RemoveItem(healthPotion, 1);
                ArticyGlobalVariables.Default.playerInventory.genericHealthPots += 1;
            }

            _removedMinorPotions = true;
        }

        if (!_momSaved && !ArticyGlobalVariables.Default.gameState.motherIll)
        {
            var momPotion = InventoryManager.Database.items.Find(item => item.Name == "Bloody Nighcap Infused Health Potion");
            inventory.RemoveItem(momPotion, 1);
            ArticyGlobalVariables.Default.playerInventory.sHealthPotM += 1;
            _momSaved = true;
        }
        
        if (!_babySaved && !ArticyGlobalVariables.Default.gameState.babyIll)
        {
            var babyPotion = InventoryManager.Database.items.Find(item => item.Name == "Fleshy Belladona Infused Health Potion");
            inventory.RemoveItem(babyPotion, 1);
            ArticyGlobalVariables.Default.playerInventory.sHealthPotB += 1;
            _babySaved = true;
        }
        
        
    }
    
    public void UnlockTarot()
    {
        ArticyGlobalVariables.Default.gameState.enteredDreamscape = true;
    }


}
