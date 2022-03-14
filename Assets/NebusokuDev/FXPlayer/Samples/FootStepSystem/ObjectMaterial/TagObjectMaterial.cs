using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.ObjectMaterial
{
    public class TagObjectMaterial : MonoBehaviour, IObjectMaterial
    {
        private string _tag;
        public string GetMaterial(Vector3 position) => _tag ??= tag;
    }
}