﻿using System;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Emitter
{
    public abstract class FootStepEmitterBase : MonoBehaviour
    {
        public abstract event Action OnFootStep;
    }
}