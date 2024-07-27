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
        public void AddToDayObject(int dayObject)
        {
            GameData.DayObject += dayObject;
        }
    }
}