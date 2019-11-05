using System.Collections.Generic;
using UnityEngine;
namespace Audio
{
    public class AudioShufflePlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private bool randomizePitch;

        public void PlayRandomClip()
        {
            var clip = audioClips[GetRandomIndex()];

            if (randomizePitch)
            {
                source.pitch = Random.Range(0.5f, 1f);
            }
            
            source.clip = clip;
            source.Play();
        }
        
        private int GetRandomIndex()
        {
            return Random.Range(0, audioClips.Count);
        }
    }
}