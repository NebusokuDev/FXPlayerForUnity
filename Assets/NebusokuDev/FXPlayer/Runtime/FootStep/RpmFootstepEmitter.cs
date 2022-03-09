using System;
using IgnoreAssets.Character_Movement_Fundamentals.Source.Scripts.Controllers;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public class RpmFootstepEmitter : FootStepEmitterBase
    {
        [SerializeField] private Controller controller;
        [SerializeField] private float minMoveDistance = .1f;
        [SerializeField] private float rpm = 120f;
        public override event Action OnFootStep;

        [SerializeField] private float _rpmTimer;

        private void Update()
        {
            var isMoving = controller.GetVelocity().sqrMagnitude > minMoveDistance * minMoveDistance;
            var isGrounded = controller.IsGrounded();
            if (isMoving == false || isGrounded == false)
            {
                TimerReset();
                return;
            }

            _rpmTimer += Time.deltaTime;

            if (_rpmTimer < 60f / rpm) return;

            TimerReset();

            OnFootStep?.Invoke();
        }

        private void TimerReset() => _rpmTimer = 0f;
    }
}