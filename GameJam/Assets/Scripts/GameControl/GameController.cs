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
                }
            } 
        }

        [SerializeField] private Flowchart Flowchart;

        [SerializeField] private UiController Ui;

        [SerializeField] private bool _gameStarted;


        private void Awake()
        {
            GetReferences();
            //StartGame();
            GameEvents.StartGame.AddListener(StartDialogue);
        }

        private void GetReferences()
        {
            Ui = FindAnyObjectByType<UiController>();
            Flowchart = GetComponent<Flowchart>();
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
    }
}