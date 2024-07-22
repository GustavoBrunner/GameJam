using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.DataEvents
{

    public class GasolineEvent : UnityEvent<float> { }



    public static class PlayerDataEvents 
    {
        public static readonly GasolineEvent onGasEvent = new GasolineEvent();
    }
}