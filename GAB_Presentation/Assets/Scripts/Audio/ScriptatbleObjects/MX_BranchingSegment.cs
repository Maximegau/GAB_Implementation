using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/MX/BranchingAudio")]
public class MX_BranchingSegment : AudioEvent {
    [System.Serializable]
    public class Segments
    {
        public AudioClip segment;
        public AudioMixerGroup group;
    }

    public AudioMixerSnapshot snapshotToLoad;public Segments[] musicSegments;
    public AudioClip transitionToSegment;
    public AudioMixerGroup transitionGroup;

    public int bPM;
    public int beatOfEndTail;
    public int sampleRateUsed;


    public int ReturnNextBeat (int currentSample, bool exitFromMusicSegment)
    {
        if (exitFromMusicSegment)
        {
            for (int i = 0; i < 1000; i++)
            {
                if ((((i * sampleRateUsed) * 60) / bPM) > currentSample && currentSample < musicSegments[0].segment.samples)
                {
                    return (((i * sampleRateUsed) * 60) / bPM);
                }
            }
        }
        else
        {
            return transitionToSegment.samples - (((60 * sampleRateUsed)/ bPM) * beatOfEndTail);
        }
        return 0;

    }

    public void PlayTransition (AudioSource source)
    {
        source.loop = false;
        source.outputAudioMixerGroup = transitionGroup;
        source.clip = transitionToSegment;
        source.Play();
    }
    public override void Play(AudioSource source)
    {
        source.loop = true;
        source.clip = musicSegments[0].segment;
        source.outputAudioMixerGroup = musicSegments[0].group;
        source.Play();
    }

    public void PlayLayer (AudioSource layerToPlay, int i)
    {
        layerToPlay.loop = true;
        layerToPlay.clip = musicSegments[i].segment;
        layerToPlay.outputAudioMixerGroup = musicSegments[i].group;
        layerToPlay.Play();
    }
}
