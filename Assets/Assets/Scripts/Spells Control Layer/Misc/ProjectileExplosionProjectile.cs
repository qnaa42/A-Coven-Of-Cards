using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Misc
{
    public class ProjectileExplosionProjectile : MonoBehaviour
    {
        private float _lifeSpan = 0f;
        private void Start()
        {
            
        }
        private void Update()
        {
            _lifeSpan += Time.deltaTime;
            if (_lifeSpan >= GameManager.instance.spellsManager.GetProjectileExplosionProjectileLifeSpawn())
            {
                Instantiate(GameManager.instance.spellsManager.GetProjectileExplosionAoePrefab());
                Destroy(gameObject);
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            var projectileExplosionAoePrefab = GameManager.instance.spellsManager.GetProjectileExplosionAoePrefab();
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy");
                Instantiate(projectileExplosionAoePrefab, collision.transform.position, projectileExplosionAoePrefab.transform.rotation);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Obstruction"))
            {
                Debug.Log("Hit Obstruction");
                Instantiate(projectileExplosionAoePrefab, collision.transform.position, projectileExplosionAoePrefab.transform.rotation);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player");
                Instantiate(projectileExplosionAoePrefab, collision.transform.position, projectileExplosionAoePrefab.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}