using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
namespace Audio
{
    public class AudioShufflePlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private bool randomizePitch;
        [ShowIf("randomizePitch")] [SerializeField] private Vector2 pitchRange;

        public void PlayRandomClip()
        {
            var clip = audioClips[GetRandomIndex()];

            if (randomizePitch)
            {
                source.pitch = Random.Range(pitchRange.x, pitchRange.y);
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