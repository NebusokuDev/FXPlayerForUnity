using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.ObjectMaterial
{
    public interface IObjectMaterial
    {
        public string GetMaterial(Vector3 position);
    }
}