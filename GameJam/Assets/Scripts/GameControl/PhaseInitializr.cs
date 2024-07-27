using Game.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class PhaseInitializr : MonoBehaviour
    {
        [SerializeField] private List<Interactable> interactables = new List<Interactable>();

        [SerializeField] private List<int> intIndex = new List<int>();
        private void Awake()
        {
            interactables.AddRange(FindObjectsOfType<Interactable>());
            foreach (var interactable in interactables)
            {
                if(interactable.gameObject.name == "base")
                {
                    interactables.Remove(interactable);
                    break;
                }
                interactable.gameObject.SetActive(false);
            }
        }
        private void Start()
        {
            TurnInteractablesOn();
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.U))
            {
                InstantiateItems();
            }
        }

        private void TurnInteractablesOn()
        {
            int index = 1;
            var count = interactables.Count - (int)(interactables.Count * 0.25);
            Debug.Log($"{(int)(interactables.Count * 0.25)}, {count}");
            while (index <= count )
            {
                var randon = Random.Range(0, interactables.Count);
                Debug.Log(randon.ToString());
                if (!intIndex.Contains(randon))
                {
                    intIndex.Add(randon);
                    var interactable = interactables[randon];
                    interactable.gameObject.SetActive(true);
                    index++;
                }
                
            }
            Debug.Log(index.ToString());
        }

        public void InstantiateItems()
        {
            var spots = FindObjectsOfType<ItemSpot>();
            int selectedSpot= Random.Range(0, spots.Length);
            var item = FindAnyObjectByType<Item>();
            if (item != null) 
            {
                item.gameObject.SetActive(true);
                item.gameObject.transform.position = spots[selectedSpot].transform.position;
                Debug.Log($"Item spawned in: {spots[selectedSpot].transform.position}");
            }
            
        }


    }
}