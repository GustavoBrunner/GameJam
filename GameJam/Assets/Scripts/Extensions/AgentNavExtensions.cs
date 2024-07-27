using Game.Data;
using Game.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Extension.Interactables
{
    public static class AgentNavExtensions 
    {
        public static void ChangeStoppingDistance(this NavMeshAgent agent, Interactable interactable) 
        {
            agent.stoppingDistance = interactable.MinDistance;
            //return Vector3.Distance(interactable.transform.position, agent.transform.position) < interactable.MinDistance;
        }
        public static void ResetStoppingDistance(this NavMeshAgent agent)
        {
            agent.stoppingDistance = 0;
        }
        public static bool CheckIfGasFull(this PlayerDataController controller) 
        {
            return controller.Data.Gasoline >= Data.Data.MAXGAS;
        }
    }
}