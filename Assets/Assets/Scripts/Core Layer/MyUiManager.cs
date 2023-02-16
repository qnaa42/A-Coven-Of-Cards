using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Core_Layer
{
    public class MyUiManager : MonoBehaviour
    {
        [Header("Tarot Inventory UI")]
        public TextMeshProUGUI[] playerName;

        public TextMeshProUGUI[] hp;
        public TextMeshProUGUI[] movementSpeed;
        
        [Header("Light Attack")]
        public TextMeshProUGUI[] lightAttackDuration;
        public TextMeshProUGUI[] lightAttackMovementSpeedMultiplier;
        public TextMeshProUGUI[] lightAttackCooldown;
        public TextMeshProUGUI[] lightAttackRange;
        public TextMeshProUGUI[] lightAttackRadius;
        
        [Header("Heavy Attack")]
        public TextMeshProUGUI[] heavyAttackDuration;
        public TextMeshProUGUI[] heavyAttackMovementSpeedMultiplier;
        public TextMeshProUGUI[] heavyAttackCooldown;
        public TextMeshProUGUI[] heavyAttackRange;
        public TextMeshProUGUI[] heavyAttackRadius;
        
        [Header("Charging")]
        public TextMeshProUGUI[] chargeSpeed;
        public TextMeshProUGUI[] maxChargeTime;
        public TextMeshProUGUI[] stoppedTime;
        public TextMeshProUGUI[] chargeCooldown;
        public TextMeshProUGUI[] canDoubleCharge;
        
        //Where index of array represent hierarchy in unity inspector for given stat

        public void UpdateTarotUi()
        {
            playerName[0].text = GameManager.instance.userManager.GetName();
            
            movementSpeed[0].text = GameManager.instance.userManager.GetMovementSpeed().ToString();
            //Light Attack
            lightAttackDuration[0].text = GameManager.instance.userManager.GetLightAttackDuration().ToString();
            lightAttackMovementSpeedMultiplier[0].text = GameManager.instance.userManager.GetLightAttackMovementSpeedMultiplier().ToString();
            lightAttackCooldown[0].text = GameManager.instance.userManager.GetLightAttackCooldown().ToString();
            lightAttackRange[0].text = GameManager.instance.userManager.GetLightAttackRange().ToString();
            lightAttackRadius[0].text = GameManager.instance.userManager.GetLightAttackRadius().ToString();
            
            //Heavy Attack
            heavyAttackDuration[0].text = GameManager.instance.userManager.GetHeavyAttackDuration().ToString();
            heavyAttackMovementSpeedMultiplier[0].text = GameManager.instance.userManager.GetHeavyAttackMovementSpeedMultiplier().ToString();
            heavyAttackCooldown[0].text = GameManager.instance.userManager.GetHeavyAttackCooldown().ToString();
            heavyAttackRange[0].text = GameManager.instance.userManager.GetHeavyAttackRange().ToString();
            heavyAttackRadius[0].text = GameManager.instance.userManager.GetHeavyAttackRadius().ToString();
            
            //Charging
            chargeSpeed[0].text = GameManager.instance.userManager.GetChargeSpeed().ToString();
            maxChargeTime[0].text = GameManager.instance.userManager.GetMaxChargeTime().ToString();
            stoppedTime[0].text = GameManager.instance.userManager.GetStoppedTime().ToString();
            chargeCooldown[0].text = GameManager.instance.userManager.GetChargeCooldown().ToString();
            canDoubleCharge[0].text = GameManager.instance.userManager.GetCanDoubleCharge().ToString();
            
        }
    }
}
