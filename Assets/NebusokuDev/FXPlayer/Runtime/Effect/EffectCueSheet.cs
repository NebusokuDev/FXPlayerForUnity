using UnityEngine;


namespace NebusokuDev.FXPlayer.Runtime.Visual
{
    [CreateAssetMenu(menuName = "FxPlayer/Effect/EffectCueSheet")]
    public class EffectCueSheet : ScriptableObject
    {
        [SerializeField] private EffectCue[] effectCues;

        public EffectCue this[string cueName]
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