using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Misc
{
    public class ProjectileExplosionAoe : MonoBehaviour
    {
        public float _projectileExplosionAoeLifeSpawn;
        private void Start()
        {
            var thisTransform = this.GetComponent<Transform>();
            thisTransform.localScale += new Vector3(GameManager.instance.spellsManager.GetProjectileExplosionAoeRadius(), 0, GameManager.instance.spellsManager.GetProjectileExplosionAoeRadius());
            Destroy(gameObject, GameManager.instance.spellsManager.GetProjectileExplosionAoeLifeSpawn());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy");
            }
            else if (other.gameObject.CompareTag("Obstruction"))
            {
                Debug.Log("Hit Obstruction");
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player");
            }
        }
    }
}