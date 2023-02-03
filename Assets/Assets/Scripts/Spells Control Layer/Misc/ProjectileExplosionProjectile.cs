using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Misc
{
    public class ProjectileExplosionProjectile : MonoBehaviour
    {
        private float _lifeSpan = 0f;
        
        private GameObject _projectileExplosionAoePrefab;
        private GameObject _projectileExplosionAoeLifeSpawn;
        private void Start()
        {
            _projectileExplosionAoePrefab = GameManager.instance.spellsManager.GetProjectileExplosionAoePrefab();
        }
        private void Update()
        {
            _lifeSpan += Time.deltaTime;
            if (_lifeSpan >= GameManager.instance.spellsManager.GetProjectileExplosionProjectileLifeSpawn())
            {
                var aoeExplosion = Instantiate(_projectileExplosionAoePrefab, transform.position, _projectileExplosionAoePrefab.transform.rotation );
                var projectileExplosionAoe = aoeExplosion.AddComponent<ProjectileExplosionAoe>();
                projectileExplosionAoe._projectileExplosionAoeLifeSpawn = GameManager.instance.spellsManager.GetProjectileExplosionAoeLifeSpawn();
                Destroy(gameObject);
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {
             
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy");
                var aoeExplosion = Instantiate(_projectileExplosionAoePrefab, collision.transform.position, _projectileExplosionAoePrefab.transform.rotation );
                var projectileExplosionAoe = aoeExplosion.AddComponent<ProjectileExplosionAoe>();
                projectileExplosionAoe._projectileExplosionAoeLifeSpawn = GameManager.instance.spellsManager.GetProjectileExplosionAoeLifeSpawn();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Obstruction"))
            {
                Debug.Log("Hit Obstruction");
                var aoeExplosion = Instantiate(_projectileExplosionAoePrefab, collision.transform.position, _projectileExplosionAoePrefab.transform.rotation );
                var projectileExplosionAoe = aoeExplosion.AddComponent<ProjectileExplosionAoe>();
                projectileExplosionAoe._projectileExplosionAoeLifeSpawn = GameManager.instance.spellsManager.GetProjectileExplosionAoeLifeSpawn();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player");
                var aoeExplosion = Instantiate(_projectileExplosionAoePrefab, collision.transform.position, _projectileExplosionAoePrefab.transform.rotation );
                var projectileExplosionAoe = aoeExplosion.AddComponent<ProjectileExplosionAoe>();
                projectileExplosionAoe._projectileExplosionAoeLifeSpawn = GameManager.instance.spellsManager.GetProjectileExplosionAoeLifeSpawn();
                Destroy(gameObject);
            }
        }
    }
}