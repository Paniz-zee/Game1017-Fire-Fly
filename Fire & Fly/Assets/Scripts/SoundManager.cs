using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource soundEffects;

    public void PlaySound(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        soundEffects.volume = volume;
    }
}
