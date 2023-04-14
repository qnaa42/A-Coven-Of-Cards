using System;
using System.Collections;
using System.Collections.Generic;
using DevionGames.InventorySystem;
using UnityEngine;
using Random = UnityEngine.Random;


public class DropData
{
    public string name;
    public GameObject prefab;
    public float dropChance;
}

public class EnemyLootController : MonoBehaviour
{
    public GameObject monsterBloodPrefab;
    public GameObject monsterFurPrefab;
    
    public List<DropData> dropList = new List<DropData>();

    private void Start()
    {
        DropData drop1 = new DropData();
        drop1.name = "Monster Blood";
        drop1.prefab = monsterBloodPrefab;
        drop1.dropChance = 0.5f;

        DropData drop2 = new DropData();
        drop2.name = "Monster Fur";
        drop2.prefab = monsterFurPrefab;
        drop2.dropChance = 0.5f;

        dropList.Add(drop1);
        dropList.Add(drop2);
    }
    
    public GameObject SpawnRandomDrop()
    {
        float roll = Random.Range(0f, 1f);
        float totalChance = 0;

        foreach (DropData dropData in dropList)
        {
            totalChance += dropData.dropChance;

            if (roll <= totalChance)
            {
                return dropData.prefab;
            }
        }

        return null; // 40% chance for nothing to be selected
    }
    
    public void SpawnAndDestroy(Transform targetTransform)
    {
        GameObject selectedDrop = SpawnRandomDrop();
        
        if (selectedDrop != null)
        {
            Instantiate(selectedDrop, targetTransform.position, targetTransform.rotation);
        }
        Destroy(gameObject);
    }
    
    
}
