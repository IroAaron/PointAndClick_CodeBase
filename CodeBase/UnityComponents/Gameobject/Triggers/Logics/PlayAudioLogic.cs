using System.Collections;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class PlayAudioLogic : TriggerLogic
    {
        [SerializeField]
        private AudioClip _audioClip;
        private AudioSource _audioSource;

        [SerializeField]
        private bool _isWaitForAudio = true;

        public override void Processing()
        {
            base.Processing();
            _audioSource = gameObject.AddComponent<AudioSource>();

            _audioSource.playOnAwake = false;
            _audioSource.clip = _audioClip;
            _audioSource.Play();

            StartCoroutine(WaitForSound(_audioClip.length));

            if (!_isWaitForAudio)
            {
                Deactivate();
            }
        }

        private IEnumerator WaitForSound(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            Destroy(_audioSource);

            if (_isWaitForAudio)
            {
                Deactivate();
            }
        }
    }
}