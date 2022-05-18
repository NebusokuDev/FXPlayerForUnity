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

        [SerializeField] private float tickTime;
        private IMovementSource _movementSource;

        private void Start()
        {
            _movementSource = GetComponent<IMovementSource>();
        }

        private void Update()
        {
            var isMoving = _movementSource.Velocity.sqrMagnitude > velocityThreshold * velocityThreshold;
            var isGrounded = _movementSource.IsGrounded;


            tickTime += Time.deltaTime;
            
            if (isMoving == false || isGrounded == false) return;
            if (tickTime < 60f / rpm) return;

            TimerReset();

            OnFootStep?.Invoke();
        }

        private void TimerReset() => tickTime = 0f;
    }
}