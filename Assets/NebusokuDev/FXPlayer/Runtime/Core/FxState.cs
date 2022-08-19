using System.Collections.Generic;

namespace NebusokuDev.FXPlayer.Runtime.Core
{
    public class FxState : IFxState
    {
        public IDictionary<string, int> IntValues { get; } = new Dictionary<string, int>();
        public IDictionary<string, float> FloatValues { get; } = new Dictionary<string, float>();
        public IDictionary<string, bool> BoolValues { get; } = new Dictionary<string, bool>();
        public IDictionary<string, string> StringValues { get; } = new Dictionary<string, string>();
    }
}