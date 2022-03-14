using UnityEngine;
using UnityEngine.VFX;

namespace NebusokuDev.FXPlayer.Runtime.Effect
{
    public class VFXEffect : EffectBase
    {
        [SerializeField] private string startEventName = "OnStart";
        [SerializeField] private string stopEventName = "OnStop";
        [SerializeField] private VisualEffect vfx;
        public override void Play(Vector3 position, Quaternion rotation, Transform parent)
        {
            
        }


        public override void Stop() {}


        public override bool IsPlaying { get; }
    }
}