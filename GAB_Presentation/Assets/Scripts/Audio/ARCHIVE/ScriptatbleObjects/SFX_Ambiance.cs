using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/SimpleAmbiance")]
public class SFX_Ambiance : AudioEvent {

    public AudioClip ambiance;
    public AudioMixerGroup bus;

    public override void Play(AudioSource source)
    {
        source.clip = ambiance;
        source.loop = true;
        source.volume = 1;
        source.pitch = 1;
        source.spatialBlend = 0;
        source.outputAudioMixerGroup = bus;
        source.Play();
    }
}
