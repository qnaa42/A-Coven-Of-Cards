using System.Collections;
using System.Collections.Generic;
using Articy.A_Coven_Of_Cards.GlobalVariables;
using Assets.Scripts.Core_Layer;
using UnityEngine;


namespace Assets.Scripts.Enviorment_Misc_Layer
{
    public class PlantSpawner : MonoBehaviour
    {
        public enum PlantType { GeneralHerb, Nightcap, Belladona }

        public PlantType plantType;

        public GameObject GeneralHerbPrefab;
        public GameObject NightcapPrefab;
        public GameObject BelladonaPrefab;
        
        public GameObject PlantPrefab;
        public LayerMask terrainLayer; // Assign the terrain layer in the inspector
        public LayerMask obstacleLayer; // Assign the obstacle layer in the inspector
        public int numberOfPlants = 5;
        public float timeToSpawn = 2;
        public float spawnRadius = 1; // The radius to check for colliders
        public int maxAttemptsPerFrame = 10; // Limit the number of spawn attempts per frame

        private float _timeToSpawn = 0;
        public int _plants = 0;
        private bool _init = false;

        public float spawnX;
        public float spawnZ;

    private void Start()
    {
        if (!_init)
            Init();
    }

    private void Init()
    {
        StartCoroutine(SpawnPlants());
    }

    private IEnumerator SpawnPlants()
    {
        while (_plants < numberOfPlants)
        {
            for (int i = 0; i < maxAttemptsPerFrame; i++)
            {
                if (TrySpawnPlant())
                {
                    _plants++;
                    if (_plants >= numberOfPlants)
                        break;
                }
            }
            yield return null;
        }
        _init = true;
    }

    private void Update()
    {
        if (_plants < numberOfPlants)
        {
            _timeToSpawn += Time.deltaTime;
            if (_timeToSpawn >= timeToSpawn)
            {
                if (TrySpawnPlant())
                {
                    _plants++;
                }
                _timeToSpawn = 0;
            }
        }
    }

    private bool TrySpawnPlant()
    {
        float _spawnX = Random.Range(-spawnX, spawnX);
        float _spawnZ = Random.Range(-spawnZ, spawnZ);
        Vector3 _spawnPosition = new Vector3(this.transform.position.x + _spawnX, this.transform.position.y, this.transform.position.z + _spawnZ);

        if (Physics.CheckSphere(_spawnPosition, spawnRadius, obstacleLayer))
        {
            return false; // Don't spawn if there's a collider in the area
        }

        if (Physics.Raycast(_spawnPosition + Vector3.up * 1000, Vector3.down, out RaycastHit hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
            {
                _spawnPosition.y = hit.point.y;
                Quaternion _rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

                GameObject plantPrefab = GetPlantPrefabBasedOnTypeAndGameState();

                if (plantPrefab != null)
                {
                    Instantiate(plantPrefab, _spawnPosition, _rotation, this.transform);
                    return true;
                }
            }
        }

        return false;
    }
    
    private GameObject GetPlantPrefabBasedOnTypeAndGameState()
    {
        if (plantType == PlantType.GeneralHerb && (ArticyGlobalVariables.Default.gameState.act1|| ArticyGlobalVariables.Default.gameState.act2 || ArticyGlobalVariables.Default.gameState.act4))
        {
            return GeneralHerbPrefab;
        }
        else if (plantType == PlantType.Nightcap && ArticyGlobalVariables.Default.gameState.enteredDreamscape && !ArticyGlobalVariables.Default.gameState.act1 && !ArticyGlobalVariables.Default.gameState.act2 && !ArticyGlobalVariables.Default.gameState.act4)
        {
            return NightcapPrefab;
        }
        else if (plantType == PlantType.Belladona && ArticyGlobalVariables.Default.gameState.enteredDreamscape && !ArticyGlobalVariables.Default.gameState.act1 && !ArticyGlobalVariables.Default.gameState.act2 && !ArticyGlobalVariables.Default.gameState.act4)
        {
            return BelladonaPrefab;
        }

        return null;
    }
}
}
