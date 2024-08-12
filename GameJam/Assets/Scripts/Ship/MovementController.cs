using Game.Data;
using Game.Events;
using Game.GamePhysics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Game.Player
{
    [RequireComponent(typeof(PhysicsController), typeof(NavMeshAgent))]
    public class MovementController : MonoBehaviour
    {
        [field: SerializeField] public PhysicsController PhysicsController {  get; private set; }
        [field: SerializeField] public NavMeshAgent Agent {  get; private set; }
        [field: SerializeField] public PlayerDataController Data {  get; private set; }

        [SerializeField] private Vector3 initialPos;
        

        [SerializeField] private Quaternion playerRotation = Quaternion.identity;

        private void Awake()
        {
            PhysicsController = GetComponent<PhysicsController>();
            Agent = GetComponent<NavMeshAgent>();
            Data = GetComponent<PlayerDataController>();
            Agent.speed = Data.Data.Speed;
            initialPos = transform.position;
            GameEvents.onResetDay.AddListener(ResetPosition);
        }
        private void FixedUpdate()
        {
            ConsumeGas();
        }

        public void MoveTo(Vector3 pos)
        {
            Agent.SetDestination(pos);
        }
        public void ConsumeGas()
        {
            if(Agent.velocity.magnitude > 0)
            {
                Data.Data.ConsumGas(Time.deltaTime * Data.Data.GasConsuming);
            }
        }
        private void ResetPosition()
        {
            Agent.destination = initialPos;

        }
    }
}