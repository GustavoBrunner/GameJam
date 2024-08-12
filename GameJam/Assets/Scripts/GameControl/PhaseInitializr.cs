using Game.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Events;

namespace Game
{
    public class PhaseInitializr : MonoBehaviour
    {
        [SerializeField] private List<Interactable> interactables = new List<Interactable>();

        [SerializeField] private List<int> intIndex = new List<int>();

        private GameDataController controller;
        private void Awake()
        {
            interactables.AddRange(FindObjectsOfType<Interactable>());
            
            controller = GetComponent<GameDataController>();

            //GameEvents.onResetDay.AddListener(TurnInteractablesOn);
        }
        private void Start()
        {
            TurnInteractablesOn();
            //InstantiateItems();
        }
        

        public void TurnInteractablesOn()
        {
            foreach (var interactable in interactables)
            {
                if (interactable.gameObject.name == "base" || interactable.gameObject.name == "entidade")
                {
                    interactables.Remove(interactable);
                    break;
                }
                interactable.gameObject.SetActive(false);
            }
            int index = 1;
            var count = interactables.Count - (int)(interactables.Count * 0.25);
            while (index <= count )
            {
                var randon = Random.Range(0, interactables.Count);
                if (!intIndex.Contains(randon))
                {
                    intIndex.Add(randon);
                    var interactable = interactables[randon];
                    interactable.gameObject.SetActive(true);
                    index++;
                }
                
            }
        }

        public void InstantiateItems()
        {
            
            var spots = FindObjectsOfType<ItemSpot>();
            int selectedSpot= Random.Range(0, spots.Length);
            var item = FindObjectOfType<Item>();
            if (item != null)
            {
                item.gameObject.SetActive(true);
                item.gameObject.transform.position = spots[selectedSpot].transform.position;
                Debug.Log($"Item spawned in: {spots[selectedSpot].transform.position}");
            }

            
        }
        public void TurnOnNextInteractable()
        {
            var interact = interactables.Where(i => !i.isActiveAndEnabled).FirstOrDefault().gameObject;
            interact.SetActive(true);
        }


    }
}