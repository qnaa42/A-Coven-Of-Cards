//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Articy.Unity;
using Articy.Unity.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Articy.A_Coven_Of_Cards.GlobalVariables
{
    
    
    [Articy.Unity.ArticyCodeGenerationHashAttribute(638113806985455541)]
    public class ArticyScriptFragments : BaseScriptFragments, ISerializationCallbackReceiver
    {
        
        #region Fields
        private System.Collections.Generic.Dictionary<uint, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>> Conditions = new System.Collections.Generic.Dictionary<uint, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>>();
        
        private System.Collections.Generic.Dictionary<uint, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>> Instructions = new System.Collections.Generic.Dictionary<uint, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>>();
        #endregion
        
        #region Script fragments
        /// <summary>
        /// ObjectID: 0x1000000000010FA
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932282?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000010FAText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return // Clicking on the father
true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001100
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932288?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001100Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return //Clicking on the mother

true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001106
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932294?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001106Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return // Clicking on Cassandra
true;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000110C
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932300?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000110CText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return // Clicking on the baby

true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001112
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932306?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001112Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return // Clicking on Nyx
true;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000111D
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932317?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000111DText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return //Clicking on cauldron
true;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000114F
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932367?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000114FText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == false;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001199
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932441?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001199Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act1 == true || aGlobalVariablesState.gameState.act2 == true || aGlobalVariablesState.gameState.act3 == true ;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000011ED
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932525?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000011EDText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.motherIll == true;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000011F5
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932533?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000011F5Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.motherIll == false
;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000014B9
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933241?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x1000000000014B9Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.motherAlive = false;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000011FB
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932539?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000011FBText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == false
;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000120F
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932559?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x10000000000120FText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.awake = true;
aGlobalVariablesState.gameState.act1 = true;
;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001228
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932584?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001228Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.awake = true;
aGlobalVariablesState.gameState.act1 = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001252
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932626?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001252Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act1 == true && aGlobalVariablesState.playerInventory.genericHerbAmount == 0;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001259
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932633?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001259Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act1 == true &&aGlobalVariablesState.playerInventory.genericHerbAmount > 0 && aGlobalVariablesState.playerInventory.genericHerbAmount < 4;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000125E
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932638?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000125EText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act1 == true && aGlobalVariablesState.playerInventory.genericHerbAmount >= 4;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001265
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932645?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001265Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.act1 = false;
aGlobalVariablesState.gameState.act2 = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000126D
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932653?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000126DText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act2 == true && aGlobalVariablesState.playerInventory.genericHealthPots >= 2;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001290
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932688?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001290Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.healthPotFail = true;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000012AB
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932715?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x1000000000012ABText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.playerInventory.genericHealthPots -= 2;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001141
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932353?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001141Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.babyIll == true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001147
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932359?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001147Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.babyIll == false;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001501
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933313?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001501Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.babyAlive = false;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000012B2
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932722?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000012B2Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act2 == true && aGlobalVariablesState.gameState.healthPotFail == true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001316
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932822?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001316Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.genericHerbAmount > 0;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001317
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932823?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001317Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.nyxInventory.genericHerbAmount = aGlobalVariablesState.playerInventory.genericHerbAmount;
aGlobalVariablesState.playerInventory.genericHerbAmount -= aGlobalVariablesState.playerInventory.genericHerbAmount;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000131D
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932829?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000131DText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.genericHerbAmount > 0;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001325
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932837?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001325Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.act2 = false;
aGlobalVariablesState.gameState.act3 = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000133F
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932863?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x10000000000133FText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.act2 = false;
aGlobalVariablesState.gameState.act3 = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000135F
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932895?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000135FText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == false;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000136A
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932906?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000136AText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.genericHerbAmount < 1;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001372
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932914?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001372Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.act2 = false;
aGlobalVariablesState.gameState.act3 = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001379
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932921?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001379Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.playerInventory.genericHealthPots = 2;
aGlobalVariablesState.nyxInventory.genericHerbAmount = aGlobalVariablesState.nyxInventory.genericHerbAmount - aGlobalVariablesState.nyxInventory.genericHerbAmount;;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000013EE
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933038?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x1000000000013EEText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.playerInventory.genericHealthPots = 1;
aGlobalVariablesState.nyxInventory.genericHerbAmount = aGlobalVariablesState.nyxInventory.genericHerbAmount - aGlobalVariablesState.nyxInventory.genericHerbAmount;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000112D
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932333?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000112DText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == false;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001139
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037932345?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001139Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000152E
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933358?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000152EText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act1 == true;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000154F
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933391?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000154FText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act2 == true && aGlobalVariablesState.gameState.healthPotFail == true;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000155E
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933406?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000155EText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act3 == true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001429
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933097?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001429Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.sHealthPotM == 1;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000142A
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933098?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000142AText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true

;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000014A2
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933218?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000014A2Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.regentA == 1 && aGlobalVariablesState.playerInventory.regentB == 1;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001432
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933106?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001432Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.sHealthPotB == 1;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000014F4
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933300?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000014F4Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.regentC == 1 && aGlobalVariablesState.playerInventory.regentD == 1;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000013E7
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933031?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000013E7Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.nyxInventory.genericHerbAmount <= 3 && aGlobalVariablesState.nyxInventory.genericHerbAmount >= 2;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000013F2
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933042?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000013F2Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.motherCanSave == true;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000013F3
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933043?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000013F3Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.awake == true && aGlobalVariablesState.gameState.act3 == true
;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000013F7
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933047?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000013F7Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.babyCanSave == true;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000013FC
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933052?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000013FCExpression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.gameState.babyCanSave == true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001407
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933063?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001407Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.nyxInventory.genericHerbAmount <= 1;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001418
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933080?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001418Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.nyxInventory.genericHerbAmount >= 4;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001592
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933458?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001592Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.playerInventory.genericHerbAmount <= 1;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000142E
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933102?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x10000000000142EExpression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.motherIll = false;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001437
        /// Articy Object ref: articy://localhost/view/ea19ebc8-e9d9-4ebe-8afc-312afcfcd317/72057594037933111?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001437Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.gameState.babyIll = false;
        }
        #endregion
        
        #region Unity serialization
        public override void OnBeforeSerialize()
        {
        }
        
        public override void OnAfterDeserialize()
        {
            Conditions = new System.Collections.Generic.Dictionary<uint, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>>();
            Instructions = new System.Collections.Generic.Dictionary<uint, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>>();
            Conditions.Add(1u, this.Script_0x1000000000010FAText);
            Conditions.Add(2u, this.Script_0x100000000001100Text);
            Conditions.Add(3u, this.Script_0x100000000001106Text);
            Conditions.Add(4u, this.Script_0x10000000000110CText);
            Conditions.Add(5u, this.Script_0x100000000001112Text);
            Conditions.Add(6u, this.Script_0x10000000000111DText);
            Conditions.Add(7u, this.Script_0x10000000000114FText);
            Conditions.Add(8u, this.Script_0x100000000001199Text);
            Conditions.Add(9u, this.Script_0x1000000000011EDText);
            Conditions.Add(10u, this.Script_0x1000000000011F5Text);
            Instructions.Add(11u, this.Script_0x1000000000014B9Text);
            Conditions.Add(12u, this.Script_0x1000000000011FBText);
            Instructions.Add(13u, this.Script_0x10000000000120FText);
            Instructions.Add(14u, this.Script_0x100000000001228Text);
            Conditions.Add(15u, this.Script_0x100000000001252Text);
            Conditions.Add(16u, this.Script_0x100000000001259Text);
            Conditions.Add(17u, this.Script_0x10000000000125EText);
            Instructions.Add(18u, this.Script_0x100000000001265Text);
            Conditions.Add(19u, this.Script_0x10000000000126DText);
            Instructions.Add(20u, this.Script_0x100000000001290Text);
            Instructions.Add(21u, this.Script_0x1000000000012ABText);
            Conditions.Add(22u, this.Script_0x100000000001141Text);
            Conditions.Add(23u, this.Script_0x100000000001147Text);
            Instructions.Add(24u, this.Script_0x100000000001501Text);
            Conditions.Add(25u, this.Script_0x1000000000012B2Text);
            Conditions.Add(26u, this.Script_0x100000000001316Text);
            Instructions.Add(27u, this.Script_0x100000000001317Text);
            Conditions.Add(28u, this.Script_0x10000000000131DText);
            Instructions.Add(29u, this.Script_0x100000000001325Text);
            Instructions.Add(30u, this.Script_0x10000000000133FText);
            Conditions.Add(31u, this.Script_0x10000000000135FText);
            Conditions.Add(32u, this.Script_0x10000000000136AText);
            Instructions.Add(33u, this.Script_0x100000000001372Text);
            Instructions.Add(34u, this.Script_0x100000000001379Text);
            Instructions.Add(35u, this.Script_0x1000000000013EEText);
            Conditions.Add(36u, this.Script_0x10000000000112DText);
            Conditions.Add(37u, this.Script_0x100000000001139Text);
            Conditions.Add(38u, this.Script_0x10000000000152EText);
            Conditions.Add(39u, this.Script_0x10000000000154FText);
            Conditions.Add(40u, this.Script_0x10000000000155EText);
            Conditions.Add(41u, this.Script_0x100000000001429Expression);
            Conditions.Add(42u, this.Script_0x10000000000142AText);
            Conditions.Add(43u, this.Script_0x1000000000014A2Expression);
            Conditions.Add(44u, this.Script_0x100000000001432Expression);
            Conditions.Add(45u, this.Script_0x1000000000014F4Expression);
            Conditions.Add(46u, this.Script_0x1000000000013E7Expression);
            Conditions.Add(47u, this.Script_0x1000000000013F2Expression);
            Conditions.Add(48u, this.Script_0x1000000000013F3Text);
            Conditions.Add(49u, this.Script_0x1000000000013F7Expression);
            Conditions.Add(50u, this.Script_0x1000000000013FCExpression);
            Conditions.Add(51u, this.Script_0x100000000001407Expression);
            Conditions.Add(52u, this.Script_0x100000000001418Expression);
            Conditions.Add(53u, this.Script_0x100000000001592Expression);
            Instructions.Add(54u, this.Script_0x10000000000142EExpression);
            Instructions.Add(55u, this.Script_0x100000000001437Expression);
        }
        #endregion
        
        #region Script execution
        public override void CallInstruction(Articy.Unity.Interfaces.IGlobalVariables aGlobalVariables, uint aHandlerId, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            if ((Instructions.ContainsKey(aHandlerId) == false))
            {
                return;
            }
            if ((aMethodProvider != null))
            {
                aMethodProvider.IsCalledInForecast = aGlobalVariables.IsInShadowState;
            }
            Instructions[aHandlerId].Invoke(((ArticyGlobalVariables)(aGlobalVariables)), aMethodProvider);
        }
        
        public override bool CallCondition(Articy.Unity.Interfaces.IGlobalVariables aGlobalVariables, uint aHandlerId, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            if ((Conditions.ContainsKey(aHandlerId) == false))
            {
                return true;
            }
            if ((aMethodProvider != null))
            {
                aMethodProvider.IsCalledInForecast = aGlobalVariables.IsInShadowState;
            }
            return Conditions[aHandlerId].Invoke(((ArticyGlobalVariables)(aGlobalVariables)), aMethodProvider);
        }
        #endregion
    }
}
