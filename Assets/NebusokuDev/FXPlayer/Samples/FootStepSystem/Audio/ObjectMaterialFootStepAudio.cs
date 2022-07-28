using System;
using NebusokuDev.FXPlayer.Samples.FootStepSystem.ObjectMaterial;
using UnityEngine;
using static UnityEngine.QueryTriggerInteraction;
using static UnityEngine.Physics;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.Audio
{
    public class ObjectMaterialFootStepAudio : FootStepAudioBase
    {
        // collision
        [SerializeField] private LayerMask collisionMask = -1;
        [SerializeField] private float collisionDistance = 2f;
        [SerializeField] private float collisionRadius = .5f;
        [SerializeField] private Vector3 collisionOffset;

        // footstep cues
        [SerializeField] private string footstepCueFormat = "FootStep_{0}_{1}";
        [SerializeField] private string fallbackFootStepCueName = "FootStep";

        // jump cues
        [SerializeField] private string jumpCueFormat = "Jump_{0}_{1}";
        [SerializeField] private string fallbackJumpCueName = "Jump";

        // land cues
        [SerializeField] private string landCueFormat = "Land_{0}_{1}";
        [SerializeField] private string fallbackLandCueName = "Land";

        private string _state;
        protected Transform self;


        protected override void Initialize() => self = transform;

        protected virtual bool TryGetMaterial(out string mat)
        {
            mat = string.Empty;

            var ray = new Ray(self.position + collisionOffset, -self.up);

            if (SphereCast(ray, collisionRadius, out var hit, collisionDistance, collisionMask, Ignore) == false)
            {
                return false;
            }

            if (hit.transform.TryGetComponent(out IObjectMaterial material) == false) return false;

            mat = material.GetMaterial(hit.point);

            return true;
        }

        protected override void OnFootStep() => PlaySound(footstepCueFormat, fallbackFootStepCueName);

        protected override void OnLand(Vector3 velocity) => PlaySound(landCueFormat, fallbackLandCueName);

        protected override void OnJump(Vector3 velocity) => PlaySound(jumpCueFormat, fallbackJumpCueName);

        private void PlaySound(string format, string fallBackCueName)
        {
            if (TryGetMaterial(out var mat))
            {
                var cue = string.Format(format, mat, _state);

                Debug.Log($"cue: {cue}");
                soundPlayer.Play(cue);
                return;
            }

            soundPlayer.Play(fallBackCueName);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var ray = new Ray(transform.position, -transform.up);

            Gizmos.DrawRay(transform.position + collisionOffset, -transform.up * collisionDistance);
        }
#endif

        public void SetState(string state) => _state = state ?? string.Empty;
    }
}