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
            if (gameData != null) 
            {
                if (gameData.GameData.EnergyCollected == gameData.GameData.MaxEnergy &&
                    gameData.GameData.DayObject == gameData.GameData.MaxObject) 
                {
                    this.flowchart.ExecuteBlock(InteractionsConsts.FINISHED_OBJECTS_BLOCK);
                }
                else
                {
                    this.flowchart.ExecuteBlock(InteractionsConsts.UNFINISHED_OBJECTS_BLOCK);
                }
            }
        }
    }
}