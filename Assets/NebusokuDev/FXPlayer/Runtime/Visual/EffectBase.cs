using UnityEngine;


namespace NebusokuDev.FXPlayer.Runtime.Visual
{
    public abstract class EffectBase : MonoBehaviour, IEffect
    {
        protected Transform self;

        private void Awake() => self = transform;

        public abstract void Play(Vector3 position, Quaternion rotation, Transform parent);

        public abstract void Stop();

        public abstract bool IsPlaying { get; }

        public float Scale
        {
            get => _scale;
            set
            {
                _scale = Mathf.Abs(value);

                self.localScale = Vector3.one * _scale;
            }
        }

        private float _scale;
    }
}