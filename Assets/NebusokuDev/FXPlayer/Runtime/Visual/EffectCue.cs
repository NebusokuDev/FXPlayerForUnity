using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace NebusokuDev.FXPlayer.Runtime.Visual
{
    [Serializable]
    public class EffectCue
    {
        [SerializeField] private string cueName;
        [SerializeField] private EffectBase[] effects;
        [SerializeField] private float minScale = 1f;
        [SerializeField] private float maxScale;
        [SerializeField] private bool sticky;
        private List<IEffect> _effectList;

        public string CueName => cueName;


        private IEffect Effect
        {
            get
            {
                _effectList ??= new List<IEffect>();

                var scale = Random.Range(minScale, maxScale);

                foreach (var effect in _effectList)
                {
                    if (effect.IsPlaying == false)
                    {
                        effect.Scale = scale;

                        return effect;
                    }
                }

                var prefab = effects[Random.Range(0, int.MaxValue) % effects.Length];

                if (prefab == null) return null;

                var newEffect = Object.Instantiate(prefab);
                _effectList.Add(newEffect);

                newEffect.Scale = scale;

                return newEffect;
            }
        }


        public void Play(Vector3 position, Quaternion rotation, Transform parent)
        {
            var effect = Effect;
            if (effect == null) return;

            effect.Play(position, rotation, sticky ? parent : null);
        }


        public void Stop()
        {
            foreach (var effect in _effectList)
            {
                if (effect != null) effect.Stop();
            }
        }
    }
}