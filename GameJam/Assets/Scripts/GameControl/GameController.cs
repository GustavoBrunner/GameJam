using Fungus;
using Game.Events;
using Game.Interaction;
using Game.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class GameController : MonoBehaviour
    {
        [field: SerializeField] public static bool isInteractionOn {  get; private set; }

        [property: SerializeField] public bool GameStarted 
        { 
            get => _gameStarted; 
            private set 
            {
                _gameStarted = value;
                if (!value)
                {
                    Ui.TurnMainMenu();
                }
                else
                {
                    Ui.TurnGameUi();
                    Ui.CloseResult();
                    Ui.CloseStore();
                }
            } 
        }
        [SerializeField] private GameDataController GameDataController;

        [SerializeField] private Flowchart Flowchart;

        [SerializeField] private UiController Ui;

        

        [SerializeField] private bool _gameStarted;


        private void Awake()
        {
            GetReferences();
            //StartGame();
            GameEvents.StartGame.AddListener(StartDialogue);
            
            Ui.CloseResult();
            Ui.CloseStore();
            ChangeDay(1, 5, 2);
        }

        private void GetReferences()
        {
            Ui = FindAnyObjectByType<UiController>();
            Flowchart = GetComponent<Flowchart>();
            GameDataController = GetComponent<GameDataController>();
        }
        public void StartDialogue()
        {
            Flowchart.ExecuteBlock(InteractionsConsts.START_BLOCK);
        }
        public void StartGame()
        {
            GameStarted = true;
        }
        public static void TurnInteractionOnOff(bool b = false)
        {
            isInteractionOn = b;
        }
        public void AddEnergy()
        {
            GameDataController.AddToEnergy();
            Ui.SetEnergyText(GameDataController.GameData.EnergyCollected, GameDataController.GameData.MaxEnergy);
        }
        public void AddObject()
        {
            GameDataController.AddToDayObject();
            Ui.SetOrderText(GameDataController.GameData.DayObject, GameDataController.GameData.MaxObject);
        }
        public void ChangeDay(int day, int maxEnergy, int maxObj)
        {
            GameDataController.ResetEnergy();
            GameDataController.ResetObjs();
            GameDataController.SetMaxEnergy(maxEnergy);
            GameDataController.SetMaxObjects(maxObj);
            GameDataController.SetDay(day);
            Ui.SetEnergyText(GameDataController.GameData.EnergyCollected, GameDataController.GameData.MaxEnergy);
            Ui.SetOrderText(GameDataController.GameData.DayObject, GameDataController.GameData.MaxObject);
        }
    }
}