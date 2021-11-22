﻿using UnityEngine;


namespace NebusokuDev.FXPlayer.Runtime.Visual
{
    public interface IEffect
    {
        void Play(Vector3 position, Quaternion rotation, Transform parent);

        void Stop();

        bool IsPlaying { get; }
        
        float Scale { get; set; }
    }
}