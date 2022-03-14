using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public class RpmFootstepEmitter : FootStepEmitterBase
    {
        [SerializeField] private float minMoveDistance = .1f;
        [SerializeField] private float rpm = 120f;
        public override event Action OnFootStep;

        [SerializeField] private float _rpmTimer;
        private IMover _controller;

        private void Update()
        {
            var isMoving = _controller.Velocity.sqrMagnitude > minMoveDistance * minMoveDistance;
            var isGrounded = _controller.IsGrounded;
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