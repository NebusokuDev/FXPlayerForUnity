using UnityEngine;

namespace NebusokuDev.FXPlayer.Runtime.Sound
{
    public class SoundEmitter : MonoBehaviour
    {
        [SerializeField] private string soundName;

        private ISoundPlayer _player;

        private void Start()
        {
            _player = GetComponent<ISoundPlayer>();
            if (_player != null)
            {
                _player.Play(soundName);
            }
        }
    }
}