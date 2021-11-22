using UnityEngine;


namespace NebusokuDev.FXPlayer.Runtime.Visual
{
    public class ParticleEffect : EffectBase
    {
        private ParticleSystem _particle;


        public override void Play(Vector3 position, Quaternion rotation, Transform parent)
        {
            if (_particle == null)
            {
                if (TryGetComponent(out _particle) == false) return;
            }

            self.position = position;
            self.rotation = rotation;
            self.parent = parent;
            _particle.Play();
        }
        
        public override void Stop()
        {
            if (_particle == null)
            {
                if (TryGetComponent(out _particle) == false) return;
            }

            _particle.Stop();
        }


        public override bool IsPlaying
        {
            get
            {
                if (_particle == null) return false;

                return _particle.isPlaying;
            }
        }
    }
}