namespace NebusokuDev.FXPlayer.Runtime
{
    public abstract class CueBase<T>
    {
        public abstract string GetName();
        public abstract void Play();
        public abstract void Stop();
    }
}