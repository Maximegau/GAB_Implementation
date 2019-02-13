using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlaySFX : MonoBehaviour {

    private AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            source.Play();
        }
    }

}
