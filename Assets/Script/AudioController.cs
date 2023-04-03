using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioMixerGroup defaultHitSound;
    public AudioMixerGroup goaltHitSound;

    public static AudioController instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DefaultHitSound()
    {
        hitSound.outputAudioMixerGroup = defaultHitSound;
        hitSound.Play();
    }

    public void GoaltHitSound()
    {
        hitSound.outputAudioMixerGroup = goaltHitSound;
        hitSound.Play();
    }
}
