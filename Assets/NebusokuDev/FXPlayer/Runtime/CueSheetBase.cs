using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime
{
    public abstract class CueSheetBase<T> : ScriptableObject
    {
        public abstract T this[string cueName] { get; }

    }
}