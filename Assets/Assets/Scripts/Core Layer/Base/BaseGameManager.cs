using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core_Layer;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Core_Layer
{
    [System.Serializable]
    public class BaseGameManager : MonoBehaviour
    {
        public Game.State currentGameState;
        public Game.State targetGameState;
        public Game.State lastGameState;

        public bool paused;
        
        public void SetTargetState(Game.State aState)
        {
            targetGameState = aState;

            if (targetGameState != currentGameState)
                UpdateTargetState();
        }
        
        public Game.State GetCurrentState()
        {
            return currentGameState;
        }

        [Header("Game Events")] 
        public UnityEvent OnLoading;
        public UnityEvent OnLoaded;
        
        public UnityEvent OnGameStarting;
        public UnityEvent OnGameStarted;
        
        public UnityEvent OnGamePlaying;
        
        public UnityEvent OnGameEnded;
        
        public UnityEvent OnGamePausing;
        public UnityEvent OnGameUnPaused;
    
        public UnityEvent OnRestarting;
        
        //can you write public virtual voids for each of above unity events
        
        public virtual void Loading() {OnLoading.Invoke();}
        public virtual void Loaded() {OnLoaded.Invoke();}
        
        public virtual void GameStarting() {OnGameStarting.Invoke();}
        public virtual void GameStarted() {OnGameStarted.Invoke();}
        
        public virtual void GamePlaying() {OnGamePlaying.Invoke();}

        public virtual void GameEnded()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        }
        
        public virtual void GamePausing() {OnGamePausing.Invoke();}
        public virtual void GameUnPausing() {OnGameUnPaused.Invoke();}

        public virtual void Restarting()
        {
            var thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name); 
            OnRestarting.Invoke();
        }
        
        public virtual void UpdateTargetState()
        {
            if(targetGameState == currentGameState)
                return;
            switch (targetGameState)
            {
                case Game.State.idle:
                    break;
                case Game.State.loading:
                    break;
                
                case Game.State.loaded:
                    break;
                
                case Game.State.gameStarting:
                    break;
                
                case Game.State.gameStarted:
                    break;
                
                case Game.State.gamePlaying:
                    break;
                
                case Game.State.gameEnded:
                    break;
                
                case Game.State.gamePausing:
                    break;
                
                case Game.State.gameUnPausing:
                    break;
                
                case Game.State.restarting:
                    break;
            }
            currentGameState = targetGameState;
        }

        public virtual void UpdateCurrentState()
        {
            switch (currentGameState)
            {
                case Game.State.idle:
                    break;
                case Game.State.loading:
                    break;

                case Game.State.loaded:
                    break;

                case Game.State.gameStarting:
                    break;

                case Game.State.gameStarted:
                    break;

                case Game.State.gamePlaying:
                    break;

                case Game.State.gameEnded:
                    break;

                case Game.State.gamePausing:
                    break;

                case Game.State.gameUnPausing:
                    break;

                case Game.State.restarting:
                    break;
            }
        }

        public virtual void GamePaused()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            OnGamePausing.Invoke();
            Paused = true;
        }
        
        public virtual void GameUnPaused()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            OnGameUnPaused.Invoke();
            Paused = false;
        }

        public bool Paused
        {
            get => paused;

            set
            {
                paused = value;

                Time.timeScale = paused ? 0f : 1f;
            }
        }
    }
}
