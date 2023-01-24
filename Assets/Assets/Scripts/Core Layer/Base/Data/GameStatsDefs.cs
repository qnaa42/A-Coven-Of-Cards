using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core_Layer
{
    public class Game
    {
        public enum State
        {
            idle,
            loading,
            loaded,
            gameStarting,
            gameStarted,
            gamePlaying,
            gameEnded,
            gamePausing,
            gameUnPausing,
            restarting,
        }
    }
}
