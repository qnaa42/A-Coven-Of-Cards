using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Combat_Controller_Layer
{
    public class CombatManager : MonoBehaviour
    {
        public float lightAttackConeLengthGizmoDebug = 10f;
        public float lightAttackConeRadiusGizmoDebug = 5f;
        
        public float heavyAttackConeLengthGizmoDebug = 10f;
        public float heavyAttackConeRadiusGizmoDebug = 5f;

        public bool GizmoLightAttack;
        
        
        public GameObject attackPoint;
        
        
        public GameObject lightAttackDebugCone;
        public GameObject heavyAttackDebugCone;
        
        
        public LayerMask layerMask;
        
        
        
        public void ShowLightAttackDebugCone()
        {
            lightAttackDebugCone.SetActive(true);
        }

        public void SowHeavyAttackDebugCone()
        {
            heavyAttackDebugCone.SetActive(true);
        }

        public void HideLightAttackDebugCone()
        {
            lightAttackDebugCone.SetActive(false);
        }
        
        public void HideHeavyAttackDebugCone()
        {
            heavyAttackDebugCone.SetActive(false);
        }
        

        public void Attack(float attackRange, float attackRadius, bool isCombo)
        {
            var coneTip = attackPoint.transform.position + transform.forward * lightAttackConeLengthGizmoDebug;
            var hits = Physics.SphereCastAll(attackPoint.transform.position, attackRadius, transform.forward, attackRange, layerMask);

            foreach (var hit in hits)
            {
                switch (isCombo)
                {
                    case true:
                        Debug.Log("Hit object with combo attack: " + hit.collider.gameObject.name);
                        break;
                    case false:
                        Debug.Log("Hit object: " + hit.collider.gameObject.name);
                        break;
                }
            }
        }


        private void OnDrawGizmos()
        {
            if(GizmoLightAttack)
            {
                var coneTip = attackPoint.transform.position + transform.forward * lightAttackConeLengthGizmoDebug;
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attackPoint.transform.position, lightAttackConeRadiusGizmoDebug/2);
                Gizmos.DrawWireSphere(coneTip, lightAttackConeRadiusGizmoDebug);
                Gizmos.DrawLine(attackPoint.transform.position, coneTip);
            }
            else
            {
                var coneTip = attackPoint.transform.position + transform.forward * heavyAttackConeLengthGizmoDebug;
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attackPoint.transform.position, heavyAttackConeRadiusGizmoDebug/2);
                Gizmos.DrawWireSphere(coneTip, heavyAttackConeRadiusGizmoDebug);
                Gizmos.DrawLine(attackPoint.transform.position, coneTip);
            }
        }
    }
}
