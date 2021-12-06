using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance = null;
    AudioSource _audioSource;
    bool isPlaying = false;

    private void Awake()
    {

        #region Singleton Pattern (Simple)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);

        }
        #endregion
    }

    public void PlaySong(AudioClip clip)
    {
        if (isPlaying == false)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
            isPlaying = true;

        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
