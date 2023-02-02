using System;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Misc
{
    public class Projectile : MonoBehaviour
    {

        private void Start()
        {
            Destroy(gameObject, GameManager.instance.spellsManager.GetProjectileLifeSpawn());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy");
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Obstruction"))
            {
                Debug.Log("Hit Obstruction");
                Destroy(gameObject);
            }
        }
    }
}
