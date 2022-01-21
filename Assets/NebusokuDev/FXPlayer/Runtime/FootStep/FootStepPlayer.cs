using NebusokuDev.FXPlayer.Runtime.Sound;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.FootStep
{
    public class FootStepPlayer : MonoBehaviour
    {
        [SerializeField] private GroundEmitterBase[] groundEmitters;
        [SerializeField] private FootStepEmitterBase[] footStepEmitters;

        [SerializeField] private string footstepCueName = "Footstep";
        [SerializeField] private string landCueName = "Land";
        [SerializeField] private string jumpCueName = "Jump";

        private ISoundPlayer _player;

        private void Start()
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

            _player = GetComponent<ISoundPlayer>();
        }

        private void OnFootStep() => _player.Play(footstepCueName);

        private void OnLand() => _player.Play(landCueName);

        private void OnJump() => _player.Play(jumpCueName);
    }
}