using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Effect
{
    [CreateAssetMenu(menuName = "FxPlayer/Effect/EffectCueSheet")]
    public class EffectCueSheet : CueSheetBase<EffectCue>
    {
        [SerializeField] private EffectCue[] effectCues;


#if UNITY_EDITOR
        private void OnValidate()
        {
            foreach (var effectCue in effectCues) effectCue.OnValidate();
        }
#endif

        public override EffectCue this[string cueName]
        {
            get
            {
                foreach (var effectCue in effectCues)
                {
                    if (effectCue.CueName == cueName) return effectCue;
                }

                return null;
            }
        }

        public EffectCue[] EffectCues => effectCues;
    }
}