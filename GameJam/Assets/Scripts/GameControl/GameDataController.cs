using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameDataController : MonoBehaviour
    {
        public GameData GameData;

        public void ChangeMoney(int money)
        {
            GameData.Money += money;
        }
        public void AddToDayObject()
        {
            GameData.DayObject++;
            if(GameData.DayObject > GameData.MaxObject)
            {
                GameData.DayObject = GameData.MaxObject;
            }
        }

        public void AddToEnergy()
        {
            GameData.EnergyCollected++;
            if (GameData.EnergyCollected > GameData.MaxEnergy) 
            {
                GameData.EnergyCollected = GameData.MaxEnergy;
            }
        }
        public bool ReturnEnergyFull()
        {
            return GameData.EnergyCollected == GameData.MaxEnergy;
        }
        public void ResetEnergy()
        {
            GameData.EnergyCollected = 0;
        }
        public void ResetObjs()
        {
            GameData.DayObject = 0;
        }
        public void SetMaxEnergy(int maxEnergy)
        {
            GameData.MaxEnergy = maxEnergy;
        }
        public void SetMaxObjects(int obj)
        {
            GameData.MaxObject = obj;
        }
        public void SetDay(int day)
        {
            GameData.Day = day;
        }
    }
}