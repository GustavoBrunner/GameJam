using Game.Consts;
using Game.DataEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.Events;

namespace Game.Ui
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private Slider GasBar;

        [SerializeField] private Animator Animator;

        [SerializeField] private GameObject GameUi, InitialMenu, StoreMenu, ResultMenu, ObjsUi;

        [SerializeField] private TMP_Text Energy, Item;
        private void Awake()
        {
            Animator = GetComponentInChildren<Animator>();
            PlayerDataEvents.onGasEvent.AddListener(ConsumGas);
            
        }
        private void ConsumGas(float gas)
        {
            GasBar.value = gas;
        }
        

        public void TurnObjsOn()
        {
            ObjsUi.gameObject.SetActive(true);
        }
        public void TurnObjsOff()
        {
            ObjsUi.gameObject.SetActive(false);
        }

        internal void TurnMainMenu()
        {
            GameUi.SetActive(false);
            InitialMenu.SetActive(true);
        }

        internal void TurnGameUi()
        {
            InitialMenu.SetActive(false);
            GameUi.SetActive(true);
        }

        public void TurnMenuFadeOn()
        {
            Animator.Play(AnimationNames.FADE_MENU_ANIM);
        }

        public void SetOrderText(int collected, int toCollect)
        {
            Item.text = $"{collected}/{toCollect}";
        }
        public void SetEnergyText(int collected, int toCollect) 
        {
            Energy.text = $"{collected}/{toCollect}";
        }
        public void OpenStore()
        {
            StoreMenu.gameObject.SetActive(true);

        }
        public void CloseStore()
        {
            StoreMenu.gameObject.SetActive(false);

        }
        public void OpenResult()
        {
            ResultMenu.gameObject.SetActive(true);

        }
        public void CloseResult()
        {
            ResultMenu.gameObject.SetActive(false);

        }

        public void Exit()
        {
            Application.Quit();
        }
        
    }
}