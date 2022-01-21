using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime
{
    public interface IFxPlayer
    {
        void Play(string fxName);

        void Play(string fxName, Vector3 position);

        void Play(string fxName, Vector3 position, Transform parent);

        void Stop(string fxName);

        void StopAll();
    }
}