using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class GameController : MonoBehaviour
    {
        [field: SerializeField] public static bool isInteractionOn {  get; private set; }

        public static void TurnInteractionOnOff(bool b = false)
        {
            isInteractionOn = b;
        }
    }
}