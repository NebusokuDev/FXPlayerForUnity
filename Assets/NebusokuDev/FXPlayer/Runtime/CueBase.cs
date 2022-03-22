﻿using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime
{
    public abstract class CueBase<T>
    {
        public abstract string GetName();
        public abstract void Play(Vector3 position, Quaternion rotation, Transform parent);
        public abstract void Stop();
    }
}