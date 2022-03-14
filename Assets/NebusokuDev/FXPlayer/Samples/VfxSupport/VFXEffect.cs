using NebusokuDev.FXPlayer.Runtime.Effect;
using UnityEngine;
using UnityEngine.VFX;

namespace NebusokuDev.FXPlayer.Samples.VfxSupport
{
    public class VFXEffect : EffectBase
    {
        [SerializeField] private VisualEffect vfx;

        public override void Play(Vector3 position, Quaternion rotation, Transform parent)
        {
            self.position = position;
            self.rotation = rotation;
            self.parent = parent;
            vfx.Play();
        }


        public override void Stop() => vfx.Stop();

        public override bool IsPlaying => vfx.culled;
    }
}