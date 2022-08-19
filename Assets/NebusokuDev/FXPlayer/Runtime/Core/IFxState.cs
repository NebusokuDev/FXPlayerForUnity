using System.Collections.Generic;

namespace NebusokuDev.FXPlayer.Runtime.Core
{
    public interface IFxState
    {
        IDictionary<string, int> IntValues { get; }
        IDictionary<string, float> FloatValues { get; }
        IDictionary<string, bool> BoolValues { get; }
        IDictionary<string, string> StringValues { get; }
    }
}