using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Source")]
    public AudioClip background;
    public AudioClip loseBall;
    public AudioClip powerUp;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip collide;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
