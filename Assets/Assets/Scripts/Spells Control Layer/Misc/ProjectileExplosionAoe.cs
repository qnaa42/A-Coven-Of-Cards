using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Misc
{
    public class ProjectileExplosionAoe : MonoBehaviour
    {
        private void Start()
        {
            var thisTransform = this.GetComponent<Transform>();
            thisTransform.localScale += new Vector3(GameManager.instance.spellsManager.GetProjectileExplosionAoeRadius(), 0, GameManager.instance.spellsManager.GetProjectileExplosionAoeRadius());
            Destroy(gameObject, GameManager.instance.spellsManager.GetProjectileExplosionAoeLifeSpawn());
        }
    }
}