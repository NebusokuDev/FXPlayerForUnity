using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Core
{
    public interface IFxPlayer
    {
        IFxState State { get; }
        void Play(string fxName);

        void Play(string fxName, Vector3 position);
        void Play(string fxName, Vector3 position, Transform parent);

        void Stop(string fxName);

        void StopAll();
    }
}