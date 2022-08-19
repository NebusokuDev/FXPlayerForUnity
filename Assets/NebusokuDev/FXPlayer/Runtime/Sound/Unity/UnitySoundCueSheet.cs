using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    [CreateAssetMenu(menuName = "FxPlayer/Sound/" + nameof(UnitySoundCueSheet))]
    public class UnitySoundCueSheet : UnityAudioCueSheetBase
    {
        [SerializeField] private string regexPattern = "*";
        [SerializeReference, SubclassSelector] private UnityAudioCueBase[] audioCues;

        private List<KeyValuePair<int, UnityAudioCueBase>> _matchedCues;

        private void OnValidate()
        {
            foreach (var audioCue in audioCues) audioCue.OnValidate();
        }

        private IEnumerable<UnityAudioCueBase> AudioCues => audioCues;

        public override UnityAudioCueBase this[string cueName]
        {
            get
            {
                var format = $"{cueName}{regexPattern}";

                if (audioCues == null) return null;

                _matchedCues ??= new List<KeyValuePair<int, UnityAudioCueBase>>();

                _matchedCues.Clear();

                foreach (var cue in audioCues)
                {
                    var rex = Regex.Match(cue.CueName, format);

                    if (rex.Success)
                    {
                        _matchedCues.Add(new KeyValuePair<int, UnityAudioCueBase>(rex.Length, cue));
                    }
                }

                return _matchedCues.FirstOrDefault().Value;
            }
        }

        public override IEnumerator<UnityAudioCueBase> GetEnumerator() => AudioCues.GetEnumerator();
    }
}