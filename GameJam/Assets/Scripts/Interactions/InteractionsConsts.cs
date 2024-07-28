using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Interaction
{
    public record InteractionsConsts 
    {
        public const string START_BLOCK = "StartInteraction";
        public const string FINISHED_OBJECTS_BLOCK = "FinishedInteraction";
        public const string UNFINISHED_OBJECTS_BLOCK = "UnfinishedInteraction";
    }
}