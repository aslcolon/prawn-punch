using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Separate music and SFX player
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip bellSignal1;
    public AudioClip bellSignal2;
    public AudioClip bellSignal3;
    public AudioClip punch;
    public AudioClip hurt;
    public AudioClip cursorExit;
    public AudioClip cursorHover;
    public AudioClip cursorSelect;

    private void Start()
    {
        // BG music play on start
        musicSource.clip = background;
        musicSource.Play();
    }

    // Created method that is accessible in other scripts
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
