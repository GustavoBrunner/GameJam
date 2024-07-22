using Game.DataEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Ui
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private Image GasBar;

        private void Awake()
        {
            PlayerDataEvents.onGasEvent.AddListener(ConsumGas);
        }
        private void ConsumGas(float gas)
        {
            GasBar.fillAmount = gas;
        }
    }
}