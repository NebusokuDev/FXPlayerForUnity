using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Emitter
{
    public abstract class GroundEmitterBase : MonoBehaviour
    {
        public abstract event Action<Vector3> OnLanding;
        public abstract event Action<Vector3> OnJumping;
    }
}