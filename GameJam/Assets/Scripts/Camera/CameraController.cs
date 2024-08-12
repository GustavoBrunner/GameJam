using Game.Consts;
using Game.Contracts;
using Game.Data;
using Game.Events;
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

        [SerializeField] private Animator Animator;

        private GameController gameController;

        [SerializeField] private NavMeshAgent Agent;

        [Range(0f,20f)]
        [SerializeField] private float TransitionSpeed;

        [SerializeField] private GameObject FadeOne, FadeTwo, FadeThree, FadeFour, FadeFourText;
        
        private void Awake()
        {
            movementController = FindAnyObjectByType<MovementController>();

            gameController = FindAnyObjectByType<GameController>();

            Agent = FindAnyObjectByType<NavMeshAgent>();

            Animator = GetComponent<Animator>();
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
                    var data = Agent.GetComponent<PlayerDataController>();
                    if(!data.CheckIfGasFull())
                    {
                        (obj as Interactable).flowchart.SetBooleanVariable("GasFull", false);
                    }
                    else
                    {
                        (obj as Interactable).flowchart.SetBooleanVariable("GasFull", true);
                    }

                    StartCoroutine(CheckIfInteractionBegun((obj as Interactable).transform.position));
                }
            }
        }
        IEnumerator CheckIfInteractionBegun(Vector3 intPos)
        {
            while (true)
            {
                if(Vector3.Distance(Agent.transform.position, intPos) < 3.5f && Agent.velocity.magnitude <= 0)
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
            if (gameController.GameStarted)
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(Agent.transform.position.x, transform.position.y, Agent.transform.position.z),
                    Time.deltaTime * TransitionSpeed);
            }
        }
        public void PlayFirstBlackFade()
        {
            StartCoroutine(FirstFade());
        }
        public void PlaySecondBlackFade()
        {
            StartCoroutine(SecondFade());
        }
        public void PlayThirdBlackFade()
        {
            StartCoroutine(ThirdFade());
        }
        public void PlayForthBlackFade()
        {
            StartCoroutine(FourthFade());
        }
        public void ResetEvent()
        {
            GameEvents.onResetDay.Invoke();
        }

        public IEnumerator FirstFade()
        {
            FadeOne.SetActive(true);
            yield return new WaitForSeconds(2f);
            GameEvents.onResetDay.Invoke();
            yield return new WaitForSeconds(3f);
            FadeOne.SetActive(false);

        }
        public IEnumerator SecondFade()
        {
            FadeTwo.SetActive(true);
            yield return new WaitForSeconds(2f);
            GameEvents.onResetDay.Invoke();
            yield return new WaitForSeconds(3f);
            FadeTwo.SetActive(false);
            GameController.TurnInteractionOnOff(false);
        }
        public IEnumerator ThirdFade()
        {
            FadeThree.SetActive(true);
            yield return new WaitForSeconds(2f);
            yield return new WaitForSeconds(3f);
            FadeThree.SetActive(false);
            Application.Quit();
        }
        public IEnumerator FourthFade()
        {
            FadeFour.SetActive(true);
            yield return new WaitForSeconds(2f);
            FadeFourText.SetActive(true);
            yield return new WaitForSeconds(5f);
            
            Application.Quit();
        }
    }
}