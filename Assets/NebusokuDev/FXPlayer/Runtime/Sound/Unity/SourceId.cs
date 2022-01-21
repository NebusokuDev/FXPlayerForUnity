using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Sound.Unity
{
    public class AudioSourceId : MonoBehaviour
    {
        public string id;

        public void SetId(string newId) => id = newId;
    }
}