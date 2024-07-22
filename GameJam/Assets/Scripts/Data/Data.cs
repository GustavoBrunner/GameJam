using Game.DataEvents;
using Game.Extension;
using System;
using UnityEngine;

namespace Game.Data
{
    [System.Serializable]
    public record Data 
    {
        public const float MAXGAS = 100f;

        public const float MINGAS = 0f;

        public float Speed;

        public float Gasoline;

        public float GasConsuming;


        public void ConsumGas(float gas)
        {
            Gasoline -= gas;
            PlayerDataEvents.onGasEvent.Invoke(Gasoline.FormateToHudBarFloat());
        }
    }
}