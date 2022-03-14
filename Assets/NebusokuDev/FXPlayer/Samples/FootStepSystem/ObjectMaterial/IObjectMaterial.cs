using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.ObjectMaterial
{
    public interface IObjectMaterial
    {
        public string GetMaterial(Vector3 position);
    }
}