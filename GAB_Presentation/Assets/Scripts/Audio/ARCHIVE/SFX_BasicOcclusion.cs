using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_BasicOcclusion : MonoBehaviour {

    private Transform player;
    private RaycastHit hit;
    private Vector3 directionFromObjToPlayer;
    private AudioLowPassFilter lowPass;

    private void Start()
    {
        player = GameObject.Find("RigidBodyFPSController").transform;
        lowPass = GetComponent<AudioLowPassFilter>();
    }

    private void Update()
    {
        directionFromObjToPlayer = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, directionFromObjToPlayer);
        if (Physics.Raycast(transform.position, directionFromObjToPlayer, out hit))
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Player")
            {
                lowPass.cutoffFrequency = 20000f;
            }
            else if (hit.collider.gameObject.tag == "Wall") lowPass.cutoffFrequency = 3000f;
        }
    }
}
