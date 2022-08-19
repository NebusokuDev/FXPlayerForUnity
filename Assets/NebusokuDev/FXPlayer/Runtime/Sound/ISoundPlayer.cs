using NebusokuDev.FXPlayer.Runtime.Core;

namespace NebusokuDev.FXPlayer.Runtime.Sound
{
    public interface ISoundPlayer : IFxPlayer
    {
        float Volume { get; set; }

        void SetMute(bool isMute);
        
        public bool IsMute { get; }
    }
}