using Fungus;
using Game.Contracts;
using Game.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactables
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [field:SerializeField] public float MinDistance { get ; set ; }

        [field: SerializeField] public Flowchart flowchart { get; private set; }

        private void Awake()
        {
            this.flowchart = GetComponent<Flowchart>();
        }
        public virtual void Interact()
        {
            GameController.TurnInteractionOnOff(true);
            flowchart.ExecuteBlock(InteractionsConsts.StartBlock);
        }
    }
}