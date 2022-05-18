using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.MovementSource
{
    public interface IMovementSource
    {
        Vector3 Velocity { get; }
        bool IsGrounded { get; }

        event Action<Vector3> OnLand;
        event Action<Vector3> OnJump;
    }
}