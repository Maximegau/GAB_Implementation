﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_ActivateOtherObjOnTrigger : MonoBehaviour {

    private AudioSource source;
    public SFX_Basic basicFS;

    private void Start()
    {
        source = GameObject.Find("Cube_DEMO").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            basicFS.Play(source);
        }
    }
}
