using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField]  AudioSource soundEffect1;
  
    [SerializeField]  AudioSource explosionSound;

    public void PlaySoundEffect1()
    {
        soundEffect1.Play();
    }

    public void PlayExplosionSound()
    {
        explosionSound.Play();
    }
}
