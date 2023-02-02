using Assets.Scripts.Core_Layer;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Spells_Control_Layer.Misc
{
    public class DashTrail : MonoBehaviour
    {
        private void Start()
        {
            var thisTransform = this.GetComponent<Transform>();
            thisTransform.localScale += new Vector3(0, 0,GameManager.instance.spellsManager.GetDashChargeSpeed()/5);
            Destroy(gameObject, GameManager.instance.spellsManager.GetDashTrailLifeSpawn());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy with trail");
            }
            else if (other.gameObject.CompareTag("Obstruction"))
            {
                Debug.Log("Hit Obstruction with trail");
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player with trail");
            }
        }
        
    }
}