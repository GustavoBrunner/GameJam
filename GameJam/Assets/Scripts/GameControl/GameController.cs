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
            Ui.TurnObjsOff();

            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1)) 
            {
                AddEnergy();
            }
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
        public void SecondDialogue()
        {
            Flowchart.ExecuteBlock(InteractionsConsts.SECOND_BLOCK);
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
            Flowchart.SetIntegerVariable("Energy", GameDataController.GameData.EnergyCollected);
        }
        public void AddObject()
        {
            GameDataController.AddToDayObject();
            Ui.SetOrderText(GameDataController.GameData.DayObject, GameDataController.GameData.MaxObject);
            Flowchart.SetIntegerVariable("Object", GameDataController.GameData.DayObject);
        }
        public void ChangeDay(int day, int maxEnergy, int maxObj)
        {
            GameDataController.ResetEnergy();
            Flowchart.SetIntegerVariable("Energy", 0);
            GameDataController.ResetObjs();
            Flowchart.SetIntegerVariable("Objects", 0);
            GameDataController.SetMaxEnergy(maxEnergy);
            GameDataController.SetMaxObjects(maxObj);
            GameDataController.SetDay(day);
            Flowchart.SetIntegerVariable("Day", GameDataController.GameData.Day);
            Ui.SetEnergyText(GameDataController.GameData.EnergyCollected, GameDataController.GameData.MaxEnergy);
            Ui.SetOrderText(GameDataController.GameData.DayObject, GameDataController.GameData.MaxObject);
        }
        public GameDataController GetGameData()
        {
            return GameDataController;
        }
    }
}