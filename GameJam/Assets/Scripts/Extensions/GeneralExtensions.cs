using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Extension
{
    public static class GeneralExtensions
    {
        public static float FormateToHudBarFloat(this float value)
        {
            return value / 100;
        }
    }
}