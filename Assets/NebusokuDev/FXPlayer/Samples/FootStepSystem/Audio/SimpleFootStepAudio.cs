using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Audio
{
    public sealed class SimpleFootStepAudio : FootStepAudioBase
    {
        [SerializeField] private string footstepCueName = "FootStep";
        [SerializeField] private string landCueName = "Land";
        [SerializeField] private string jumpCueName = "Jump";


        protected override void OnFootStep() => soundPlayer.Play(footstepCueName);

        protected override void OnLand(Vector3 velocity) => soundPlayer.Play(landCueName);

        protected override void OnJump(Vector3 velocity) => soundPlayer.Play(jumpCueName);
    }
}