using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PlayLayeredAudio : MonoBehaviour {
    private AudioSource[] sources;
    public AudioClip layer01;
    public AudioClip layer02;
    public AudioMixerGroup layer01Bus;
    public AudioMixerGroup layer02Bus;

    public AudioMixerSnapshot snapshotToLayer02;
    public AudioMixerSnapshot snapshotToLayer01;
    // Use this for initialization
    void Start () {
        sources = GetComponents<AudioSource>();
        sources[0].clip = layer01;
        sources[1].clip = layer02;
        sources[0].loop = true;
        sources[1].loop = true;
        sources[0].outputAudioMixerGroup = layer01Bus;
        sources[1].outputAudioMixerGroup = layer02Bus;
        sources[0].Play();
        sources[1].Play ();


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            snapshotToLayer01.TransitionTo(3f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            snapshotToLayer02.TransitionTo(3f);
        }

    }
}
