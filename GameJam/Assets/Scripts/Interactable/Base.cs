using Game.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactables
{
    public class Base : Interactable
    {
        public override void Interact()
        {
            var gameData = FindAnyObjectByType<GameController>().GetGameData();
            flowchart.SetIntegerVariable("Object", gameData.GameData.DayObject);
            flowchart.SetIntegerVariable("Energy", gameData.GameData.EnergyCollected);
            flowchart.SetIntegerVariable("Day", gameData.GameData.Day);
            base.Interact();
        }
    }
}