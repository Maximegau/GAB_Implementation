using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_01_SimpleSound : MonoBehaviour {

    /// <summary>
    /// YOU NEED TO HAVE AN AUDIOSOURCE ON THE GAME OBJECT AND NEED TO HAVE ASSIGNED AN AUDIOCLIP FOR THIS SCRIPT TO WORK
    /// </summary>




    private AudioSource source;
    public AudioClip radioClip; //Needs to be added in the inspector

	// Happens at the start of the game (happens once)
	void Start () {
        //we are finding the audiosource that is attached on the gameobject
        source = GetComponent<AudioSource>();

        //We are telling the audio soure on the gameobject that the audioclip (or sample) that it is assigned is radioClip (see line 15)
        source.clip = radioClip;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //We are checking if you are pressing the key "A"
		if (Input.GetKeyDown (KeyCode.A))
        {
            //if the key is pressed then the audioclip (sample) assigned to the audiosource will play
            source.Play();
        }
    }
}
