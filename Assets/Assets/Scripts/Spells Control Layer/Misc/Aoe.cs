using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core_Layer;
using UnityEngine;

public class Aoe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var thisTransform = this.GetComponent<Transform>();
        thisTransform.localScale += new Vector3(GameManager.instance.spellsManager.GetAoeRadius(), 0, GameManager.instance.spellsManager.GetAoeRadius());
        Destroy(gameObject, GameManager.instance.spellsManager.GetAoeLifeSpawn());
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
