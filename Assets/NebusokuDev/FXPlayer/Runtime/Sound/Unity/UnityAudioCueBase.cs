using System.Collections.Generic;
using System.Linq;
using NebusokuDev.FXPlayer.Runtime.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    [System.Serializable]
    public abstract class UnityAudioCueBase
    {
        [SerializeField] private string cueName;
        [SerializeField] private AudioMixerGroup audioMixerGroup;
        [Header("Polyphony")] [SerializeField] private int polyphony = 10;

        [SerializeField] private float delay;
        [SerializeField] private bool looping;

        public string CueName => cueName;

        protected const float Octave = 1200f;

        private bool _isMute;
        private Queue<AudioSource> _audioSources;


        public virtual void OnValidate() { }


        public void Play(float playerVolume, Vector3 position, Transform parent, IFxState state)
        {
            var playingSrc = GetAudioSource();


            var t = playingSrc.transform;
            t.position = position;
            t.parent = parent;

            playingSrc.clip = SelectAudioClip(state);

            if (playingSrc.clip == null) return;

            playingSrc.outputAudioMixerGroup = audioMixerGroup;
            playingSrc.pitch = Mathf.Pow(2f, OutputSentPitch(state) / Octave);
            playingSrc.spatialize = true;


            playingSrc.PlayDelayed(delay);

            var srcCount = _audioSources.Count - 1;

            foreach (var audioSource in _audioSources)
            {
                // -1dbは音量が1/3なので3のn乗で音量を減らす
                // value convert to percentage
                audioSource.volume = playerVolume * (OutputVolume(state) * .01f) / Mathf.Pow(3f, srcCount);
                audioSource.spatialBlend = OutputSpatialBlend(state) * .01f;
                audioSource.loop = looping;
                srcCount--;
            }
        }

        public void Stop()
        {
            _audioSources ??= new Queue<AudioSource>();
            foreach (var audioSource in _audioSources) audioSource.Stop();
        }

        public void Mute(bool isMute)
        {
            _audioSources ??= new Queue<AudioSource>();
            _isMute = isMute;
            if (_audioSources == null) return;
            foreach (var audioSource in _audioSources) audioSource.mute = isMute;
        }

        public bool IsMute => _isMute;

        private AudioSource GetAudioSource()
        {
            _audioSources ??= new Queue<AudioSource>();


            if (_audioSources.Count >= polyphony && _audioSources.Any())
            {
                var source = _audioSources.Dequeue();
                source.Stop();
                _audioSources.Enqueue(source);

                return source;
            }

            var newSrc = new GameObject(cueName).AddComponent<AudioSource>();
            newSrc.playOnAwake = false;

            _audioSources.Enqueue(newSrc);

            return newSrc;
        }

        protected abstract AudioClip SelectAudioClip(IFxState state);
        protected abstract float OutputSpatialBlend(IFxState state);
        protected abstract float OutputVolume(IFxState state);
        protected abstract float OutputSentPitch(IFxState state);
    }
}