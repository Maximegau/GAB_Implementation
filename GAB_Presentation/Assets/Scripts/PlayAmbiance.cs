using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbiance : MonoBehaviour {

    AudioSource source;
    public AudioClip ambiance;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.loop = true;
        source.clip = ambiance;
        source.Play();
	}


}
