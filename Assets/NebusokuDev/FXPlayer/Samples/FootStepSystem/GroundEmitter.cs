using System;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public class GroundEmitter : GroundEmitterBase
    {
        private IMover _mover;

        private void Start()
        {
            _mover.OnJump += vector3 => OnJumping?.Invoke();
            _mover.OnLand += vector3 => OnLanding?.Invoke();
        }

        public override event Action OnLanding;
        public override event Action OnJumping;
    }
}