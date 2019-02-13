using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MX_BasicLayer : MonoBehaviour {

    public AudioMixerSnapshot snapshotToTransiton;

    [Range(0,5)]
    public float transitionTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            snapshotToTransiton.TransitionTo(transitionTime);
        }
    }
}
