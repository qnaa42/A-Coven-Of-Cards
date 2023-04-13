using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core_Layer;
using UnityEngine;


namespace Assets.Scripts.Enviorment_Misc_Layer
{
    public class PlantSpawner : MonoBehaviour
    {
        public GameObject PlantPrefab;
        
        public int _plants;
        
        public int numberOfPlants = 5;
        
        public float timeToSpawn = 2;
        private float _timeToSpawn = 0;
        
        private bool _init = false;

        public float spawnX;
        public float spawnZ;
        
        //in start instantiate plants equal to number of plants in the distance from this.transform + _spawnX and _spawnZ
        
        private void Start()
        {
            if(!_init)
                Init();
        }

        private void Init()
        {
            for (int i = 0; i < numberOfPlants; i++)
            {
                var _spawnX = Random.Range(-spawnX, spawnX);
                var _spawnZ = Random.Range(-spawnZ, spawnZ);
                var _spawnPosition = new Vector3(this.transform.position.x + _spawnX, this.transform.position.y, this.transform.position.z + _spawnZ);
                var _rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                var plant = Instantiate(PlantPrefab, _spawnPosition, _rotation, this.transform);
                _plants++;
                _init = true;
            }
        }
        
        private void Update()
        {
            if (_plants < numberOfPlants)
            {
                _timeToSpawn += Time.deltaTime;
                if (_timeToSpawn >= timeToSpawn)
                {

                    var _spawnX = Random.Range(-spawnX, spawnX);
                    var _spawnZ = Random.Range(-spawnZ, spawnZ);
                    var _spawnPosition = new Vector3(this.transform.position.x + _spawnX, this.transform.position.y, this.transform.position.z + _spawnZ);
                    var _rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                    var plant = Instantiate(PlantPrefab, _spawnPosition, _rotation, this.transform);
                    _plants++;
                    _timeToSpawn = 0;
                }
            }
        }
    }
}
