using System;
using NebusokuDev.FXPlayer.Samples.FootStepSystem.MovementSource;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Emitter
{
    public class GroundEmitter : GroundEmitterBase
    {
        private IMovementSource _movementSource;

        private void Start()
        {
            if (TryGetComponent(out _movementSource) == false) return;
            _movementSource.OnJump += vector3 => OnJumping?.Invoke(_movementSource.Velocity);
            _movementSource.OnLand += vector3 => OnLanding?.Invoke(_movementSource.Velocity);
        }

        public override event Action<Vector3> OnLanding;
        public override event Action<Vector3> OnJumping;
    }
}