using System.Collections;
using System.Collections.Generic;
using DevionGames.InventorySystem;
using UnityEngine;
using System.Linq;


public class AlembicRecipe
{
    public string Name;
    public List<string> MainRegents;
    public List<string> SubRegents;
    public string PotionRegent;
    public string FireRegent;

    public AlembicRecipe(string name, List<string> mainRegents, List<string> subRegents,string potionRegent, string fireRegent)
    {
        Name = name;
        MainRegents = mainRegents;
        SubRegents = subRegents;
        FireRegent = fireRegent;
        PotionRegent = potionRegent;
    }
}


public class AlembicController : MonoBehaviour
{
    public Slot mainRegent1;
    public Slot mainRegent2;
    
    public Slot subRegent1;
    public Slot subRegent2;
    
    public Slot potionRegent1;
    
    public Slot fireRegent1;
    
    private AlembicRecipe bloodyNightcapHealthPotion = new AlembicRecipe("Bloody Nighcap Infused Health Potion", new List<string>() {"06","00"}, new List<string>() {"08","00"}, "05", "04");
    private AlembicRecipe fleshyBelladonaHealthPotion = new AlembicRecipe("Fleshy Belladona Infused Health Potion", new List<string>() {"09","00"}, new List<string>() {"07","00"}, "05", "04");
    private List<AlembicRecipe> recipes = new List<AlembicRecipe>();
    
    // Start is called before the first frame update
    void Start()
    {
        recipes.Add(bloodyNightcapHealthPotion);
        recipes.Add(fleshyBelladonaHealthPotion);
    }

    public void CraftItem()
    {
        var slotsSeed = new List<Slot>();
        var mainRegent = new List<string>();
        var subRegent = new List<string>();
        var potionRegent = "";
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
        
        if (potionRegent1.ObservedItem != null)
        {
            potionRegent = potionRegent1.ObservedItem.FindProperty("CraftingID").GetValue().ToString();
            slotsSeed.Add(potionRegent1);
        }
        else
        {
            potionRegent = "00";
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
            if (CompareIngredients(reciepie, mainRegent, subRegent, potionRegent, fireRegent))
            {
                Debug.Log("Found" + reciepie.Name);
                var item = InventoryManager.Database.items.Find(item => item.Name == reciepie.Name);
                Item instance = ScriptableObject.Instantiate(item);
                instance.Stack = 1;
                ItemContainer.AddItem("Alembic Inventory", instance);
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
    
    public bool CompareIngredients(AlembicRecipe recipe, List<string> inputMainRegents, List<string> inputSubRegents, string inputPotionRegent, string inputFireRegent)
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

        // Compare potion regent
        if (recipe.PotionRegent != inputPotionRegent)
        {
            return false;
        }

        // Compare fire regent
        if (recipe.FireRegent != inputFireRegent)
        {
            return false;
        }

        return true;
    }
}

