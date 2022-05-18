using NebusokuDev.FXPlayer.Samples.FootStepSystem.ObjectMaterial;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Audio
{
    public class ObjectMaterialFootStepAudio : FootStepAudioBase
    {
        // collision
        [SerializeField] private LayerMask collisionMask = -1;
        [SerializeField] private float collisionDistance = 1f;
        [SerializeField] private float collisionRadius = .5f;

        // footstep cues
        [SerializeField] private string footstepCueFormat = "FootStep-{0}-{1}";
        [SerializeField] private string fallbackFootStepCueName = "FootStep";

        // jump cues
        [SerializeField] private string jumpCueFormat = "FootStep-{0}-{1}";
        [SerializeField] private string fallbackJumpCueName = "Jump";

        // land cues
        [SerializeField] private string landCueFormat = "FootStep-{0}-{1}";
        [SerializeField] private string fallbackLandCueName = "Land";

        private string _state;
        protected Transform self;


        protected override void Initialize() => self = transform;

        protected virtual bool TryGetMaterial(out string mat)
        {
            mat = string.Empty;

            var ray = new Ray(self.position, -self.up);

            if (Physics.SphereCast(ray, collisionRadius, out var hit, collisionDistance, collisionMask) == false)
            {
                return false;
            }

            if (hit.collider.TryGetComponent(out IObjectMaterial material) == false) return false;

            mat = material.GetMaterial(hit.point);
            return true;
        }

        protected override void OnFootStep()
        {
            if (TryGetMaterial(out var mat))
            {
                soundPlayer.Play(string.Format(footstepCueFormat, mat, _state));
                return;
            }

            soundPlayer.Play(fallbackFootStepCueName);
        }

        protected override void OnLand(Vector3 velocity)
        {
            if (TryGetMaterial(out var mat))
            {
                soundPlayer.Play(string.Format(footstepCueFormat, mat, _state));
                return;
            }

            soundPlayer.Play(fallbackFootStepCueName);
        }

        protected override void OnJump(Vector3 velocity)
        {
            if (TryGetMaterial(out var mat))
            {
                soundPlayer.Play(string.Format(footstepCueFormat, mat, _state));
                return;
            }

            soundPlayer.Play(fallbackFootStepCueName);
        }

        public void SetState(string state) => _state = state ?? string.Empty;
    }
}