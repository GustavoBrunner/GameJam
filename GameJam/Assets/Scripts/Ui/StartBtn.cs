using Game.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Ui
{
    public class StartBtn : MonoBehaviour
    {
        public void StartGame()
        {
            GameEvents.StartGame.Invoke();
        }
    }
}