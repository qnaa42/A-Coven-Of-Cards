using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character_Controller_Layer;
using Assets.Scripts.Core_Layer;
using UnityEngine;

namespace Assets.Scripts.Core_Layer
{
    public class GameManager : BaseGameManager
    {
        public UserStatsManager userManager;
        public BaseUserManager baseUserManager;
        
        //Singleton
        public static GameManager instance { get; private set; }
        
        public GameManager()
        {
            instance = this;
        }
        
        private void Awake()
        {
            // ------------------------------------------------------
            // this code section isn't in the book, but it's provided to make
            // the game run without having to start it via the menu. It
            // is purely for test reasons. Basically, the game adds a player
            // to the BaseUserManager component in the menu. If you try to
            // run this scene from the core scene, that player hasn't been
            // added so the game would throw an error. We check here that
            // a player has been added and, if not, add one as needed
            if (baseUserManager == null)
                baseUserManager = GetComponent<BaseUserManager>();

            if (baseUserManager.GetPlayerList().Count < 1) // get the player list from baseusermanager component and check players are in it
            {
                // reset baseusermanager
                baseUserManager.ResetUsers();

                // add a new player to the game
                baseUserManager.AddNewPlayer();

                
            }
            // ------------------------------------------------------
        }
        
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Set TargetGameState = " + targetGameState);
            SetTargetState(Game.State.loaded);
        }
        
        public override void UpdateTargetState()
        {
            Debug.Log("TargetGameState = " + targetGameState);
            if (targetGameState == currentGameState)
                return;

            switch (targetGameState)
            {
                case Game.State.idle: 
                    SetTargetState((Game.State.loading));
                    break;

                case Game.State.loading:
                    SetTargetState(Game.State.loaded);
                    break;

                case Game.State.loaded:
                    Loaded();
                    break;
                
                case Game.State.gameStarting:
                    GameStarting();
                    StartGame();
                    SetTargetState(Game.State.gameStarted);
                    break;
                
                case Game.State.gameStarted:
                    GameStarted();
                    SetTargetState(Game.State.gamePlaying);
                    break;
                
                case Game.State.gamePlaying:
                    break;
                    
                case Game.State.gameEnded:
                    EndGame();
                    GameEnded();
                    break;
                
                case Game.State.gamePausing:
                    GamePaused();
                    break;
                
                case Game.State.gameUnPausing:
                    GameUnPaused();
                    SetTargetState(Game.State.gamePlaying);
                    break;
                
                case Game.State.restarting:
                    Restarting();
                    break;
            }

            currentGameState = targetGameState;
        }

        public override void Loaded()
        {
            Debug.Log("Loaded");
            SetTargetState(Game.State.gameStarting);
        }

        public void StartGame()
        {
            
        }

        public void EndGame()
        {
            
        }
        
        
    }
}
