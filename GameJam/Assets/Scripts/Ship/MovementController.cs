using Game.Data;
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
        

        [SerializeField] private Quaternion playerRotation = Quaternion.identity;

        private void Awake()
        {
            PhysicsController = GetComponent<PhysicsController>();
            Agent = GetComponent<NavMeshAgent>();
            Data = GetComponent<PlayerDataController>();
            Agent.speed = Data.Data.Speed;
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
        //public void MoveFoward()
        //{
        //    PhysicsController.Rb.AddForce(transform.forward * 6f , ForceMode.Force);
        //}
        //public void MoveBackward()
        //{
        //    PhysicsController.Rb.AddForce(-transform.forward * 6f, ForceMode.Force);
        //}
        //public void RotateRight()
        //{
        //    playerRotation.y += Time.deltaTime * 50f;
            
        //    Quaternion rotation = Quaternion.Euler(playerRotation.x, playerRotation.y, playerRotation.z);
        //    PhysicsController.Rb.rotation = rotation;
        //    //this.transform.rotation = Quaternion.Lerp(transform.rotation,
        //    //    Quaternion.Euler(0f, playerRotation.eulerAngles.y, 0f), Time.deltaTime);
        //}
        //public void RotateLeft()
        //{
        //    playerRotation.y -= Time.deltaTime * 50f;
        //    Quaternion rotation = Quaternion.Euler(playerRotation.x, playerRotation.y, playerRotation.z);
        //    PhysicsController.Rb.rotation = rotation;
        //    //this.transform.rotation = Quaternion.Lerp(transform.rotation,
        //    //    Quaternion.Euler(0f, playerRotation.eulerAngles.y, 0f), Time.deltaTime);
        //}
    }
}