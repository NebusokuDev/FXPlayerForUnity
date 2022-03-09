using System;
using IgnoreAssets.Character_Movement_Fundamentals.Source.Scripts.Controllers;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public class CmfControllerGroundEmitter : GroundEmitterBase
    {
        [SerializeField] private Controller controller;

        private void Start()
        {
            controller.OnJump += vector3 => OnJumping?.Invoke();
            controller.OnLand += vector3 => OnLanding?.Invoke();
        }

        public override event Action OnLanding;
        public override event Action OnJumping;
    }
}