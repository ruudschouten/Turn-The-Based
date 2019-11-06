using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private List<AudioClip> audioClips;

        [SerializeField] private KeyCode nextSongKey = KeyCode.N;

        private int _prevIndex;
        private IEnumerator _musicRoutine;
        private bool _paused;

        private static MusicPlayer _instance;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(nextSongKey))
            {
                source.Stop();
            }

            if (_paused) return;
            
            if (!source.isPlaying)
            {
                PlayNextSong();
            }
        }

        public void Pause()
        {
            _paused = true;
            source.Pause();
        }

        public void Unpause()
        {
            _paused = false;
            source.UnPause();
        }
        
        private void PlayNextSong()
        {
            var index = GetRandomIndex();
            
            while (index == _prevIndex)
            {
                index = GetRandomIndex();
            }
            
            var clip = audioClips[index];

            source.clip = clip;
            source.Play();

            _prevIndex = index;
        }
        
        private int GetRandomIndex()
        {
            return Random.Range(0, audioClips.Count);
        }
    }
}