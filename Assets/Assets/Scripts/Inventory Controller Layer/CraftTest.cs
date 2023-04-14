using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Articy.A_Coven_Of_Cards.GlobalVariables;
using Assets.Scripts.Core_Layer;
using DevionGames;
using DevionGames.InventorySystem;
using UnityEngine;

public class Recipe
{
    public string Name;
    public List<string> MainRegents;
    public List<string> SubRegents;
    public string FireRegent;

    public Recipe(string name, List<string> mainRegents, List<string> subRegents, string fireRegent)
    {
        Name = name;
        MainRegents = mainRegents;
        SubRegents = subRegents;
        FireRegent = fireRegent;
    }
}

public class CraftTest : MonoBehaviour
{

    public Slot mainRegent1;
    public Slot mainRegent2;
    public Slot mainRegent3;
    
    public Slot subRegent1;
    public Slot subRegent2;

    public Slot fireRegent1;

    
    private  Recipe healthPotionReciepie = new Recipe("Minor Potion", new List<string>() {"01", "01","00"}, new List<string>() {"02","00"}, "04");
    private  Recipe coalRecipe = new Recipe("Coal", new List<string>() {"00", "00", "00"}, new List<string>() {"00","00"}, "03");
    private List<Recipe> recipes = new List<Recipe>();


    private void Start()
    {
        recipes.Add(healthPotionReciepie);
        recipes.Add(coalRecipe);
    }

    public void CraftItem()
    {
        var slotsSeed = new List<Slot>();
        var mainRegent = new List<string>();
        var subRegent = new List<string>();
        var fireRegent = "";
        
        
        Debug.Log("Clicked");
        if (mainRegent1.ObservedItem != null)
        {
            mainRegent.Add(mainRegent1.ObservedItem.FindProperty("CraftingID").GetValue().ToString());
            slotsSeed.Add(mainRegent1);
        }
        else
        {
            mainRegent.Add("00");
        }
        if (mainRegent2.ObservedItem != null)
        {
            mainRegent.Add(mainRegent2.ObservedItem.FindProperty("CraftingID").GetValue().ToString());
            slotsSeed.Add(mainRegent2);
        }
        else
        {
            mainRegent.Add("00");
        }
        if (mainRegent3.ObservedItem != null)
        {
            mainRegent.Add(mainRegent3.ObservedItem.FindProperty("CraftingID").GetValue().ToString());
            slotsSeed.Add(mainRegent3);
        }
        else
        {
            mainRegent.Add("00");
        }
        
        if (subRegent1.ObservedItem != null)
        {
            subRegent.Add(subRegent1.ObservedItem.FindProperty("CraftingID").GetValue().ToString());
            slotsSeed.Add(subRegent1);
        }
        else
        {
            subRegent.Add("00");
        }
        if (subRegent2.ObservedItem != null)
        {
            subRegent.Add(subRegent2.ObservedItem.FindProperty("CraftingID").GetValue().ToString());
            slotsSeed.Add(subRegent2);
        }
        else
        {
            subRegent.Add("00");
        }
        
        if (fireRegent1.ObservedItem != null)
        {
            fireRegent = fireRegent1.ObservedItem.FindProperty("CraftingID").GetValue().ToString();
            slotsSeed.Add(fireRegent1);
        }
        else
        {
            fireRegent = "00";
        }
        
        
        
        
        


        foreach (var reciepie in recipes)
        { 
            Debug.Log("Checking" + reciepie.Name);
            if (CompareIngredients(reciepie, mainRegent, subRegent, fireRegent))
            {
                Debug.Log("Found" + reciepie.Name);
                var item = InventoryManager.Database.items.Find(item => item.Name == reciepie.Name);
                Item instance = ScriptableObject.Instantiate(item);
                instance.Stack = 1;
                ItemContainer.AddItem("Cauldron Inventory", instance);
                foreach (var slot in slotsSeed)
                {
                    slot.ClearSlot();
                }
            }
        }
        
        
        mainRegent.Clear();
        subRegent.Clear();
        fireRegent = "";
        slotsSeed.Clear();
    }
    
    public bool CompareIngredients(Recipe recipe, List<string> inputMainRegents, List<string> inputSubRegents, string inputFireRegent)
    {
        if (recipe.MainRegents.Count != inputMainRegents.Count || recipe.SubRegents.Count != inputSubRegents.Count)
        {
            return false;
        }

        // Compare main regents
        foreach (string mainRegent in recipe.MainRegents)
        {
            int recipeCount = recipe.MainRegents.Count(r => r == mainRegent);
            int inputCount = inputMainRegents.Count(r => r == mainRegent);

            if (recipeCount != inputCount)
            {
                return false;
            }
        }

        // Compare sub regents
        foreach (string subRegent in recipe.SubRegents)
        {
            int recipeCount = recipe.SubRegents.Count(r => r == subRegent);
            int inputCount = inputSubRegents.Count(r => r == subRegent);

            if (recipeCount != inputCount)
            {
                return false;
            }
        }

        // Compare fire regent
        if (recipe.FireRegent != inputFireRegent)
        {
            return false;
        }

        return true;
    }

    
    
    
    
}
