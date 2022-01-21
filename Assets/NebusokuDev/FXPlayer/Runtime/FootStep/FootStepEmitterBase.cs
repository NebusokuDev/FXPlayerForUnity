using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public abstract class FootStepEmitterBase : MonoBehaviour
    {
        public abstract event Action OnFootStep;
    }
}