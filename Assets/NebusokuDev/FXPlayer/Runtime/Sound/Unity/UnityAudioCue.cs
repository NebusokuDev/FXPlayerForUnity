using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Random;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    [Serializable]
    public class UnityAudioCue
    {
        [SerializeField] private string cueName;
        [SerializeField] private AudioClip[] audioClips;
        [SerializeField] private AudioMixerGroup audioMixerGroup;

        [Header("Pitch")] [SerializeField, Range(0, 100f)]
        private float minVolume = 0.8f;

        [SerializeField, Range(0f, 100f)] private float maxVolume = 1f;

        [Header("Pitch")] [SerializeField, Range(-1200f, 1200f)]
        private float minPitch;

        [SerializeField, Range(-1200f, 1200f)] private float maxPitch;

        [SerializeField, Range(0f, 100f)] private float spatialBlend = 100f;

        [Header("Polyphony")]
        [SerializeField, Range(0, 1000)] private int polyphony = 10;
        [SerializeField] private AnimationCurve polyphonyDecayCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0.1f);

        [SerializeField] private float delay;
        [SerializeField] private bool looping;

        public string CueName => cueName;

        private const float Octave = 1200f;

        private bool _isMute;
        private Queue<AudioSource> _audioSources;


        public void OnValidate()
        {
            // pitch sort
            (minPitch, maxPitch) = minPitch > maxPitch ? (maxPitch, minPitch) : (minPitch, maxPitch);

            // volume sort
            (minVolume, maxVolume) = minVolume > maxVolume ? (maxVolume, minVolume) : (minVolume, maxVolume);
        }

        public AudioSource Play(float playerVolume, Vector3 position, Transform parent)
        {
            var playingSrc = GetAudioSource();


            var t = playingSrc.transform;
            t.position = position;
            t.parent = parent;

            playingSrc.clip = SelectClip;
            playingSrc.outputAudioMixerGroup = audioMixerGroup;
            playingSrc.pitch = OutputPitch;
            playingSrc.spatialize = true;


            playingSrc.PlayDelayed(delay);

            int srcCount = 01;

            foreach (var audioSource in _audioSources)
            {
                audioSource.volume = playerVolume * OutputVolume *
                                     polyphonyDecayCurve.Evaluate((float) srcCount / _audioSources.Count);

                audioSource.spatialBlend = OutputSpatialBlend;
                audioSource.loop = looping;
                srcCount--;
            }

            return playingSrc;
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


            if (_audioSources.Count >= polyphony && polyphony > 0 && _audioSources.Any())
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

        private float OutputSpatialBlend => spatialBlend / 100f;

        private float OutputVolume => Range(minVolume, maxVolume) / 100f;

        private float OutputPitch => Mathf.Pow(2f, Range(minPitch, maxPitch) / Octave);


        private AudioClip SelectClip => audioClips[Range(0, audioClips.Length) % audioClips.Length];
    }
}