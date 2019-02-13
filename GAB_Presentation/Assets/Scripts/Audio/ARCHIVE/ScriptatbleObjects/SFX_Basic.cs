using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/BasicSFX")]
public class SFX_Basic : AudioEvent {

    public AudioMixerGroup bus;
    public int numberOfNoRepeat;
    public List<AudioClip> barefootClips = new List<AudioClip>();
    [Range(0, 3)]
    public float minPitchValue;
    [Range(0, 3)]
    public float maxPitchValue;
    [Range(0.5f, 1)]
    public float minVolumeValue;
    [Range(0.5f, 1)]
    public float maxVolumeValue;

    public bool is3D;

    private AudioClip PickAClipAtRandom ()
    {
        AudioClip clipToPick = barefootClips[Random.Range(0, barefootClips.Count - numberOfNoRepeat)];
        barefootClips.Remove(clipToPick);
        barefootClips.Add(clipToPick);
        return clipToPick;
    }

    public override void Play(AudioSource source)
    {
        source.clip = PickAClipAtRandom();
        source.pitch = Random.Range(minPitchValue, maxPitchValue);
        source.volume = Random.Range(minVolumeValue, maxVolumeValue);
        source.outputAudioMixerGroup = bus;
        if (is3D)
        {
            source.spatialBlend = 1;
        }
        else source.spatialBlend = 0;


        source.Play();
    }


}
