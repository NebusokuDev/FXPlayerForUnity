using System;
using System.Linq;
using NebusokuDev.FXPlayer.Runtime.Attribute;
using UnityEngine;

namespace NebusokuDev.FXPlayer.Samples.FootStepSystem.ObjectMaterial
{
    public class TerrainObjectMaterial : MonoBehaviour, IObjectMaterial
    {
        [SerializeField, TagField] private string[] materials;
        private TerrainData _terrainData;


#if UNITY_EDITOR
        private void OnValidate() =>
            Array.Resize(ref materials, GetComponent<Terrain>().terrainData.terrainLayers.Length);
#endif


        private void Awake() => _terrainData = GetComponent<Terrain>().terrainData;

        public string GetMaterial(Vector3 position)
        {
            var offsetX = (int) (_terrainData.alphamapWidth * (position.x) / _terrainData.size.x);
            var offsetZ = (int) (_terrainData.alphamapHeight * (position.z) / _terrainData.size.z);
            var alphamaps = _terrainData.GetAlphamaps(offsetX, offsetZ, 1, 1);

            var weights = alphamaps.Cast<float>().ToArray();
            if (weights.Length < 1) return "";
            var terrainLayer = Array.IndexOf(weights, weights.Max());
            if (materials.Length < terrainLayer || materials.Length < 1) return "";
            return materials[terrainLayer];
        }
    }
}