using NebusokuDev.FXPlayer.Runtime.Core;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Sound
{
    public abstract class SoundPlayerBase : MonoBehaviour, ISoundPlayer
    {
        public abstract IFxState State { get; }
        public abstract void Play(string fxName);
        public abstract void Play(string fxName, Vector3 position);
        public abstract void Play(string fxName, Vector3 position, Transform parent);
        public abstract void Stop(string fxName);
        public abstract void StopAll();
        public abstract float Volume { get; set; }
        public abstract void SetMute(bool isMute);
        public abstract bool IsMute { get; }
    }
}