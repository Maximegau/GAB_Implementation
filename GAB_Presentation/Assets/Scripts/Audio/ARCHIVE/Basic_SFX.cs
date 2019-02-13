using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Basic_SFX : MonoBehaviour {

    private AudioSource source;

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





    private void Start()
    {
        source = GetComponent<AudioSource>();
        Debug.Log(barefootClips.Count);
        if (numberOfNoRepeat >= barefootClips.Count -1)
        {
            numberOfNoRepeat = barefootClips.Count - 2;
        }
    }

    private float RandomNumber (float minValue, float maxValue)
    {

        return Random.Range(minValue, maxValue);
    }

    private void PitchVariation ()
    {
        source.pitch = RandomNumber(minPitchValue, maxPitchValue);
    }

    private void VolumeVariation()
    {
        source.volume = RandomNumber(minVolumeValue, maxVolumeValue);
    }

    private void PickAClipAtRandom ()
    {
        AudioClip clipToPick = barefootClips[Random.Range(0, barefootClips.Count - numberOfNoRepeat)];
        barefootClips.Remove(clipToPick);
        barefootClips.Add(clipToPick);
        source.clip = clipToPick;
    }

    private void SetBus ()
    {
        source.outputAudioMixerGroup = bus;
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PickAClipAtRandom();
            VolumeVariation();
            PitchVariation();
            SetBus();
            source.Play();
        }
    }

}
