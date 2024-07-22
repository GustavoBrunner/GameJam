using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Contracts
{
    public interface IInteractable 
    {
        float MinDistance { get; set; }
        void Interact();
    }
}