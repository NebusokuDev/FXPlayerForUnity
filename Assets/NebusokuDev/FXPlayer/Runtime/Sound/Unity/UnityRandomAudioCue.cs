using System;
using System.Linq;
using NebusokuDev.FXPlayer.Runtime.Core;
using UnityEngine;
using static UnityEngine.Random;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    [Serializable, AddTypeMenu("Random")]
    public class UnityRandomAudioCue : UnityAudioCueBase
    {
        [Space(10)] [SerializeField] private AudioClip[] audioClips;

        [Header("Pitch")] [SerializeField, Range(0, 100f)]
        protected float minVolume = 80f;

        [SerializeField, Range(0f, 100f)] protected float maxVolume = 100f;

        [Header("Pitch")] [SerializeField, Range(-1200f, 1200f)]
        protected float minPitch;

        [SerializeField, Range(-1200f, 1200f)] protected float maxPitch;

        [SerializeField, Range(0f, 100f)] protected float spatialBlend = 100f;


        public override void OnValidate()
        {
            // pitch sort
            (minPitch, maxPitch) = minPitch > maxPitch ? (maxPitch, minPitch) : (minPitch, maxPitch);

            // volume sort
            (minVolume, maxVolume) = minVolume > maxVolume ? (maxVolume, minVolume) : (minVolume, maxVolume);
        }

        protected override AudioClip SelectAudioClip(IFxState state)
        {
            return audioClips.Any() ? audioClips[Range(0, audioClips.Length) % audioClips.Length] : null;
        }

        protected override float OutputSpatialBlend(IFxState state) => spatialBlend;

        protected override float OutputVolume(IFxState state)
        {
            return Mathf.Lerp(minVolume, maxVolume, Mathf.PerlinNoise(Time.time, Time.time));
        }

        protected override float OutputSentPitch(IFxState state)
        {
            return Mathf.Lerp(minPitch, maxPitch, Mathf.PerlinNoise(Time.time, Time.time));
        }
    }
}