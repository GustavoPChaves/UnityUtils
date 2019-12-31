using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : GenericSingletonClass<AudioManager>
{
    [SerializeField]
    private AudioClip[] _audioClips;

    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // public void Play(AudioClipType audioClipType)
    // {
    //     _audioSource.PlayOneShot();
    // }

}
