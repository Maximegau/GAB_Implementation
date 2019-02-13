using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlayAmbiance : MonoBehaviour {

    public AudioClip ambiantClip;
    private AudioSource ambiantSource;
	// Use this for initialization
	void Start () {
        ambiantSource = GetComponent<AudioSource>();
        ambiantSource.loop = true;
        ambiantSource.clip = ambiantClip;

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ambiantSource.Play();
        }
    }
}
