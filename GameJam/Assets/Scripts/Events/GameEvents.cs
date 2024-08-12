using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Game.Events
{
    public class StartGame: UnityEvent { }

    public class DayReseted : UnityEvent { }

    public class GameEvents 
    {
        public static readonly StartGame StartGame = new StartGame();
        public static readonly DayReseted onResetDay = new DayReseted();
    }
}