using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_03_SimpleSoundWithPitchAndAmplitudeModulation : MonoBehaviour
{

    /// <summary>
    /// YOU NEED TO HAVE AN AUDIOSOURCE ON THE GAME OBJECT AND NEED TO HAVE ASSIGNED AN AUDIOCLIP FOR THIS SCRIPT TO WORK AS WELL AS HAVING DEFINED
    /// VALUES FOR MIN AND MAX VOLUME (FOR PITCH AND VOLUME)
    /// 
    ///We just are adding another function compared to the previous one which allows us to modulate pitch too
    /// 
    /// BE CAREFUL PITCH IS A LOT MORE NOTICABLE THAN AMPLITUDE ESPESCIALLY ON TONAL MATERIAL
    /// </summary>




    private AudioSource source;

    public AudioClip radioClip;

    [Range(0, 1)] 
    public float minimumVolume;
    [Range(0, 1)]
    public float maximumVolume;

    [Range(0, 1)]
    public float minimumPitch;//the minimum pitch that for our audiosource
    [Range(0, 1)]
    public float maximumPitch;//the minimum pitch that for our audiosource

    void Start()
    {

        source = GetComponent<AudioSource>();
        source.clip = radioClip;
    }

    private void PlaySound()
    {
        source.volume = RandomVolume();

        //Source.Pitch = sets the volume according to the value that comes after the "=". 
        //In this case the function RandomPitch takes care of that (line 61)
        source.pitch = RandomPitch();
        source.Play();
    }


    private float RandomVolume()
    {
        return Random.Range(minimumVolume, maximumVolume);
    }


    //Same Function as RandomVolume but for pitch
    //this function returns (sends back information) about the pitch by taking a random value between the one we defined in the inspector
    //PLEASE SET VALUES IN INSPECTOR
    private float RandomPitch()
    {

        return Random.Range(minimumPitch, maximumPitch); //Random.Range picks a number at random between the two values in parenthesis
        //Return sends back information to where the function was called (in this case line 47) 
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound();
        }
    }
}