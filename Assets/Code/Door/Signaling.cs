using System.Collections;
using UnityEngine;

namespace Code.Door
{
    public class Signaling : MonoBehaviour
    {
        private const float SoundTimer = 0.20f;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _soundRiseRate;
        [SerializeField] private float _maxVolumeSound;

        private float _time;
        private bool _isActivateDefendHome = false;

        public void RaiseVolume()
        {
            _isActivateDefendHome = true;
            _audioSource.Play();
            StartCoroutine(FadeIn( _maxVolumeSound));
        }

        public void LowerVolume()
        {
           StartCoroutine(FadeIn( 0f));
        }

        private void Start()
        {
            _audioSource.volume = 0f;
        }

        private IEnumerator FadeIn(float targetValueSound)
        {
            WaitForSeconds waitForSecond = new WaitForSeconds(SoundTimer);
            
            while (_audioSource.volume != targetValueSound)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValueSound, _soundRiseRate * Time.deltaTime);
                yield return waitForSecond;
            }

            if (_isActivateDefendHome && _audioSource.volume == 0f)
            {
                _isActivateDefendHome = false;
                _audioSource.Stop();
            }
        }
        
    }
}
