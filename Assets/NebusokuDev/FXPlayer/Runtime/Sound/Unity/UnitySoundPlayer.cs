using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    public class UnitySoundPlayer : SoundPlayerBase
    {
        [SerializeField] private UnitySoundCueSheet cueSheet;
        [SerializeField, Range(0f, 1f)] private float volume = 1f;
        [SerializeField] private bool playAtParent;
        [SerializeField] private bool isMute;
        
        private Transform _self;

        private void Awake()
        {
            _self = transform;
            SetMute(isMute);
        }

        public override void Play(string fxName) => Play(fxName, _self.position);

        public override void Play(string fxName, Vector3 position) =>
            Play(fxName, position, playAtParent ? _self : null);

        public override void Play(string fxName, Vector3 position, Transform parent)
        {
            if (cueSheet == null) return;

            var cue = cueSheet[fxName];

            cue?.Play(Volume, _self.position, parent);
        }

        public override void Stop(string fxName)
        {
            if (cueSheet == null) return;
            var cue = cueSheet[fxName];
            cue?.Stop();
        }

        public override void StopAll()
        {
            foreach (var cue in cueSheet) cue?.Stop();
        }

        public override float Volume
        {
            get => volume;
            set => volume = Mathf.Clamp01(value);
        }

        public override void SetMute(bool mute)
        {
            if (Application.isPlaying == false) return;
            if (cueSheet == null) return;


            foreach (var cueSheetAudioCue in cueSheet)
            {
                cueSheetAudioCue?.Mute(mute);
            }

            isMute = mute;
        }

        public override bool IsMute => isMute;
    }
}