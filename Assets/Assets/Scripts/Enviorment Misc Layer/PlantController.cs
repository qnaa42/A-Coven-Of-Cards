using System.Collections;
using System.Collections.Generic;
using Articy.A_Coven_Of_Cards.GlobalVariables;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Enviorment_Misc_Layer
{
    public class PlantController : MonoBehaviour
    {
        public void HerbAdded()
        {
            GameManager.instance.playerManager.Character.itemCollected = true;
            var plantSpawner = transform.GetComponentInParent<PlantSpawner>();
            plantSpawner._plants--;
        }
    }
}
