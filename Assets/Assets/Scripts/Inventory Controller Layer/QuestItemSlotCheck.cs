using System.Collections;
using System.Collections.Generic;
using Articy.A_Coven_Of_Cards.GlobalVariables;
using DevionGames.InventorySystem;
using UnityEngine;

public class QuestItemSlotCheck : MonoBehaviour
{
    private Item _item;
    
    
    public void QuestItem(Slot slot)
    {
        Debug.Log(slot.ObservedItem);
        if (slot.ObservedItem.FindProperty("QuestItemID") != null)
        {
            _item = slot.ObservedItem;
            if ((int)slot.ObservedItem.FindProperty("QuestItemID").GetValue() == 1)
            {
                ArticyGlobalVariables.Default.playerInventory.genericHerbAmount += 1;
            }
            else if ((int)slot.ObservedItem.FindProperty("QuestItemID").GetValue() == 2)
            {
                ArticyGlobalVariables.Default.playerInventory.genericHealthPots += 1;
            }
        }
    }
    
    
    public void OnRemoveQuestItem()
    {
        if (_item != null)
        {
            if ((int)_item.FindProperty("QuestItemID").GetValue() == 1)
            {
                ArticyGlobalVariables.Default.playerInventory.genericHerbAmount -= 1;
            }
            else if ((int)_item.FindProperty("QuestItemID").GetValue() == 2)
            {
                ArticyGlobalVariables.Default.playerInventory.genericHealthPots -= 1;
            }
            _item = null;
        }
    }
    
    
}
