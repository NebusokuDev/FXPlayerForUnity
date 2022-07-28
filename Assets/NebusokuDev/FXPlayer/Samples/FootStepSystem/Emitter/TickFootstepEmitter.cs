using System;
using NebusokuDev.FXPlayer.Samples.FootStepSystem.MovementSource;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Emitter
{
    public class TickFootstepEmitter : FootStepEmitterBase
    {
        [SerializeField] private float velocityThreshold = 5f;
        [SerializeField] private float rpm = 120f;
        public override event Action OnFootStep;

        private float _elapsedTime;
        private IMovementSource _movementSource;

        private void Start()
        {
            _movementSource = GetComponent<IMovementSource>();
        }

        private void Update()
        {
            var isMoving = _movementSource.Velocity.sqrMagnitude > velocityThreshold * velocityThreshold;
            var isGrounded = _movementSource.IsGrounded;

            if (isMoving == false || isGrounded == false) return;
            if (IsTimeOver == false) return;

            TimerReset();

            OnFootStep?.Invoke();
        }


        private bool IsTimeOver => Time.time - _elapsedTime >= 60f / rpm;

        private void TimerReset() => _elapsedTime = Time.time;
    }
}