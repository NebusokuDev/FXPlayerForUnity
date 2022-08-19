using System.Collections;
using System.Collections.Generic;
using NebusokuDev.FXPlayer.Runtime.Core;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    public abstract class UnityAudioCueSheetBase : CueSheetBase<UnityAudioCueBase>, IEnumerable<UnityAudioCueBase>
    {
        public abstract IEnumerator<UnityAudioCueBase> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
    }
}