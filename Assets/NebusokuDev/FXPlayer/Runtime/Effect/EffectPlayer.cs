using NebusokuDev.FXPlayer.Runtime.Core;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Effect
{
    public class EffectPlayer : MonoBehaviour, IEffectPlayer
    {
        [SerializeField] private EffectCueSheet cueSheet;
        [SerializeField] private Vector3 direction = Vector3.forward;
        [SerializeField] private bool selfOwned;
        private Transform _self;

        private void Awake()
        {
            _self = transform;
            _state = new FxState();
        }


        public IFxState State => _state;
        private FxState _state;

        public void Play(string cueName)
        {
            Play(cueName,
                _self.position,
                Quaternion.LookRotation(_self.rotation * direction),
                selfOwned ? _self : null
            );
        }


        public void Play(string fxName, Vector3 position) =>
            Play(fxName, position, Quaternion.identity, selfOwned ? _self : null);


        public void Play(string fxName, Vector3 position, Transform parent) =>
            Play(fxName, position, Quaternion.identity, selfOwned ? _self : parent);


        public void Play(string cueName, Vector3 position, Quaternion rotate, Transform parent)
        {
            if (cueSheet == null) return;

            foreach (var effectCue in cueSheet.EffectCues)
            {
                if (effectCue == null) continue;
                if (effectCue.CueName != cueName) continue;

                effectCue.Play(position, rotate, parent);
            }
        }


        public void StopAll()
        {
            if (cueSheet == null) return;

            foreach (var effectCue in cueSheet.EffectCues)
            {
                if (effectCue != null) effectCue.Stop();
            }
        }


        public void Stop(string cueName)
        {
            if (cueSheet == null) return;

            foreach (var effectCue in cueSheet.EffectCues)
            {
                if (effectCue == null) continue;
                if (effectCue.CueName != cueName) continue;

                effectCue.Stop();
            }
        }
    }
}