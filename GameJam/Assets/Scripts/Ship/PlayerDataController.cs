using Fungus;
using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    public class PlayerDataController : MonoBehaviour
    {
        public Data Data;

        public void UpdateGas(float gas)
        {
            Data.UpdateGas(gas);
        }
        
        



    }
}