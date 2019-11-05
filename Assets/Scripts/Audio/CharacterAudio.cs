using UnityEngine;

namespace Audio
{
    public class CharacterAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip deathClip;
        [SerializeField] private AudioClip gameOverClip;
        [SerializeField] private AudioClip startTurnClip;
        [SerializeField] private AudioClip unitSelectClip;
        [SerializeField] private AudioShufflePlayer damagePlayer;

        public void PlayDeath()
        {
            Play(deathClip);
        }

        public void PlayGameOver()
        {
            Play(gameOverClip);
        }

        public void PlayStartTurn()
        {
            Play(startTurnClip);
        }

        public void PlayUnitSelect()
        {
            Play(unitSelectClip);
        }

        public void PlayDamage()
        {
            damagePlayer.PlayRandomClip();
        }

        private void Play(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}