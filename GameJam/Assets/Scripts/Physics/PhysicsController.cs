using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GamePhysics
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsController : MonoBehaviour
    {
        public Rigidbody Rb { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            Rb.useGravity = false;
        }
    }
}
