using Game.Contracts;
using Game.Extension.Interactables;
using Game.Interactables;
using Game.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Game.Cam
{
    public class CameraController : MonoBehaviour
    {
        private Action interactionAct;
        private RaycastHit hit;
        private Ray ray;
        [SerializeField] private MovementController movementController;

        [SerializeField] private NavMeshAgent Agent;

        [Range(0f,20f)]
        [SerializeField] private float TransitionSpeed;
        
        private void Awake()
        {
            movementController = FindAnyObjectByType<MovementController>();
            Agent = FindAnyObjectByType<NavMeshAgent>();
        }
        private void FixedUpdate()
        {
            MoveCam();
        }

        public void RaycastCam()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(transform.position,ray.direction, out hit, Mathf.Infinity)) 
            {
                if(hit.collider.GetComponent<Floor>())
                {
                    movementController.MoveTo(hit.point);
                    Agent.ResetStoppingDistance();
                }
                var obj = hit.collider.GetComponent<IInteractable>();
                if (obj is not null)
                {
                    Agent.ChangeStoppingDistance(obj as Interactable);
                    movementController.MoveTo((obj as Interactable).transform.position);
                    interactionAct = obj.Interact;
                    StartCoroutine(CheckIfInteractionBegun((obj as Interactable).transform.position));
                }
            }
        }
        IEnumerator CheckIfInteractionBegun(Vector3 intPos)
        {
            while (true)
            {
                if(Vector3.Distance(Agent.transform.position, intPos) < 4f)
                {
                    interactionAct.Invoke();
                    interactionAct = null;
                    break;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        private void MoveCam()
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(Agent.transform.position.x, transform.position.y, Agent.transform.position.z),
                Time.deltaTime * TransitionSpeed);
        }
    }
}