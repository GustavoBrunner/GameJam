using Game.Cam;
using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Player
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private CameraController Cam;
        [SerializeField] private PlayerDataController PlayerData;
        [SerializeField] private GameController GameController;

        private void Awake()
        {
            Cam = FindAnyObjectByType<CameraController>();
            PlayerData = GetComponent<PlayerDataController>();
            GameController = FindAnyObjectByType<GameController>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) &&
                !GameController.isInteractionOn && 
                PlayerData.Data.Gasoline > 0f &&
                GameController.GameStarted) 
            {
                Cam.RaycastCam();
            }
        }
        private bool CheckMouseOverUi()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}