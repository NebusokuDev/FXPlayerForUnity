using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public interface IMover
    {
        Vector3 Velocity { get; }
        bool IsGrounded { get; }

        event Action<Vector3> OnLand;
        event Action<Vector3> OnJump;
    }
}