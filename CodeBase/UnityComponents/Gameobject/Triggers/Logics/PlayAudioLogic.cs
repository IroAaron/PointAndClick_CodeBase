using System.Collections;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class PlayAudioLogic : TriggerLogic
    {
        [SerializeField]
        private AudioClip _audioClip;
        private AudioSource _audioSource;

        public override void Processing()
        {
            base.Processing();
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            StartCoroutine(WaitForSound(_audioClip.length));
        }

        public override void Deactivate()
        {
            Destroy(_audioSource);
            base.Deactivate();
        }

        private IEnumerator WaitForSound(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            Deactivate();
        }
    }
}