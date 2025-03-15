using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour

    {
        public bool isPauseGame { get; private set; }
        
         public void PausedGame()
         {
             if (isPauseGame)
             {
                 Time.timeScale = 1;
             }
             else
             {
                 Time.timeScale = 0;
             }
        
             isPauseGame = !isPauseGame;
        }
    }

