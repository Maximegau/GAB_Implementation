using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_OnCollisionPlayBrick : MonoBehaviour {

    public SFX_Basic basic;
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        basic.Play(source);
    }
}
