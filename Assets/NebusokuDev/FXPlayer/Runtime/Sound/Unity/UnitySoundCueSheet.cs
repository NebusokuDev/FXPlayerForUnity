using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    [CreateAssetMenu(menuName = "FxPlayer/Sound/" + nameof(UnitySoundPlayer))]
    public class UnitySoundCueSheet : ScriptableObject, IEnumerable<UnityAudioCue>
    {
        [SerializeField] private UnityAudioCue[] audioCues;
        
        private void OnValidate()
        {
            foreach (var audioCue in audioCues) audioCue.OnValidate();
        }

        private IEnumerable<UnityAudioCue> AudioCues => audioCues;

        public UnityAudioCue this[string cueName]
        {
            get
            {
                if (audioCues == null) return null;

                foreach (var cue in audioCues)
                {
                    if (cue.CueName == cueName) return cue;
                }

                return null;
            }
        }

        public IEnumerator<UnityAudioCue> GetEnumerator() => AudioCues.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) AudioCues).GetEnumerator();
    }
}