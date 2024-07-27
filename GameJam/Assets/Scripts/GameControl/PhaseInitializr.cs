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

    }
}