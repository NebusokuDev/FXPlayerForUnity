using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public abstract class GroundEmitterBase : MonoBehaviour
    {
        public abstract event Action OnLanding;
        public abstract event Action OnJumping;
    }
}