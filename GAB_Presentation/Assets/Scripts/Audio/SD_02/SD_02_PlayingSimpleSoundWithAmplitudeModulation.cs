using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_02_PlayingSimpleSoundWithAmplitudeModulation : MonoBehaviour {

    /// <summary>
    /// YOU NEED TO HAVE AN AUDIOSOURCE ON THE GAME OBJECT AND NEED TO HAVE ASSIGNED AN AUDIOCLIP FOR THIS SCRIPT TO WORK AS WELL AS HAVING DEFINED
    /// VALUES FOR MIN AND MAX VOLUME
    /// 
    ///One of the changes from the first scene is that we are now using different fonctions to do different things such as playing the sound 
    ///whereas in the first scene we were doing it in the update fonction
    /// </summary>




    private AudioSource source;

    public AudioClip radioClip;

    [Range(0, 1)] //this allows you to have a slider in the inspector that goes between the values inside the parenthesis (0 and 1 in this case)
    public float minimumVolume;//the minimum volume that for our audiosource
    [Range(0, 1)]
    public float maximumVolume;//the minimum volume that for our audiosource


    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = radioClip;
    }

    private void PlaySound ()
    {
        //Source.Volume = sets the volume according to the value that comes after the "=". In this case the function RandomVolume takes care of that (line 45)
        source.volume = RandomVolume();

        //This plays the audioclip assigned to the audiosource
        source.Play();
    }

    //this function returns (sends back information) about the volume by taking a random value between the one we defined in the inspector
    //PLEASE SET VALUES IN INSPECTOR
    private float RandomVolume ()
    {

        return Random.Range(minimumVolume, maximumVolume); //Random.Range picks a number at random between the two values in parenthesis
        //Return sends back information to where the function was called (in this case line 37) 
    }


    void Update()
    {
        //We are checking if you are pressing the key "A"
        if (Input.GetKeyDown(KeyCode.A))
        {
            //if the key is pressed then we will trigger the function PlaySound
            PlaySound();
        }
    }
}
