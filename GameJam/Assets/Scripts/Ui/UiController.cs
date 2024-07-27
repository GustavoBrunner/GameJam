using Game.Consts;
using Game.DataEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Ui
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private Image GasBar;

        [SerializeField] private Animator Animator;

        [SerializeField] private GameObject GameUi, InitialMenu;
        private void Awake()
        {
            Animator = GetComponentInChildren<Animator>();
            PlayerDataEvents.onGasEvent.AddListener(ConsumGas);
        }
        private void ConsumGas(float gas)
        {
            GasBar.fillAmount = gas;
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


    }
}