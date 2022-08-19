using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Core
{
    public abstract class CueSheetBase<T> : ScriptableObject
    {
        public abstract T this[string cueName] { get; }
    }
}