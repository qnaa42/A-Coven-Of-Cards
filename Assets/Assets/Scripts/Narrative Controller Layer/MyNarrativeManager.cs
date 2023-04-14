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
    public GameObject dreamScape;
    
    public ItemContainer inventory; 

    private bool _removedMinorPotions;
    private bool _activatedCauldron;
    private bool _activatedTarot;



    private void Update()
    {
        if (!_activatedCauldron && ArticyGlobalVariables.Default.gameState.act2)
        {
            cauldron.SetActive(true);
            _activatedCauldron = true;
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
    }
    
    public void UnlockTarot()
    {
        if (!_activatedTarot)
        {
            tarotInventory.SetActive(true);
            _activatedTarot = true;
        }
    }


}
