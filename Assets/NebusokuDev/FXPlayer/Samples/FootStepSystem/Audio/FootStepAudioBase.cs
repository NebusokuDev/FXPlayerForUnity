using NebusokuDev.FXPlayer.Runtime.Sound;
using NebusokuDev.FXPlayer.Samples.FootStepSystem.Emitter;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Audio
{
    public abstract class FootStepAudioBase : MonoBehaviour
    {
        [SerializeField] private GroundEmitterBase[] groundEmitters;
        [SerializeField] private FootStepEmitterBase[] footStepEmitters;

        protected ISoundPlayer soundPlayer;

        protected virtual void Start()
        {
            foreach (var groundEmitter in groundEmitters)
            {
                groundEmitter.OnLanding += OnLand;
                groundEmitter.OnJumping += OnJump;
            }

            foreach (var footStepEmitter in footStepEmitters)
            {
                footStepEmitter.OnFootStep += OnFootStep;
            }

            soundPlayer = GetComponent<ISoundPlayer>();
            
            Initialize();
        }

        protected virtual void Initialize(){}

        protected abstract void OnFootStep();

        protected abstract void OnLand(Vector3 velocity);

        protected abstract void OnJump(Vector3 velocity);
    }
}