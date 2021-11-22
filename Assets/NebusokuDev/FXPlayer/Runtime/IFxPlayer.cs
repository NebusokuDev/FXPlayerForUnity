using UnityEngine;


namespace Modules.FXPlayer
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