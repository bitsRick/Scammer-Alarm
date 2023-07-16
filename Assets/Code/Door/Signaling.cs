using UnityEngine;

namespace Code.Door
{
    public class Signaling : MonoBehaviour
    {
        private const float SoundTimer = 0.25f;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _soundRiseRate;
        [SerializeField] private float _maxVolumeSound;

        private float _time;
        private bool isActivateDefendHome = false;

        private void Start()
        {
            _audioSource.volume = 0f;
        }

        private void Update()
        {
            if (isActivateDefendHome)
            {
                SettingVolumeAudio(_audioSource.volume, _maxVolumeSound);
            }

            if (isActivateDefendHome == false && _audioSource.volume > 0f)
            {
                SettingVolumeAudio(_audioSource.volume, 0f);
            }

            if (isActivateDefendHome == false && _audioSource.volume == 0f)
            {
                _audioSource.Stop();
            }
        }

        private void SettingVolumeAudio(float currentVolumeSound, float targetVolumeSound)
        {
            if (_time >= SoundTimer)
            {
                _time = 0;
                _audioSource.volume = Mathf.MoveTowards(currentVolumeSound, targetVolumeSound, _soundRiseRate * Time.deltaTime);
            }
            else
            {
                _time += Time.deltaTime;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            isActivateDefendHome = true;
            _audioSource.Play();
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            isActivateDefendHome = false;
        }
    }
}
