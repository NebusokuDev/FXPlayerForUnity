using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.ObjectMaterial
{
    public class TagObjectMaterial : MonoBehaviour, IObjectMaterial
    {
        private string _tag;
        public string GetMaterial(Vector3 position) => _tag ??= tag;
    }
}