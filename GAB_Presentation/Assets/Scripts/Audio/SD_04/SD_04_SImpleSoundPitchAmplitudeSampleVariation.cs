using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_04_SImpleSoundPitchAmplitudeSampleVariation : MonoBehaviour {


    /// <summary>
    /// YOU NEED TO HAVE AN AUDIOSOURCE ON THE GAME OBJECT AND NEED TO HAVE ASSIGNED AUDIOCLIPS FOR THIS SCRIPT TO WORK AS WELL AS HAVING DEFINED
    /// VALUES FOR MIN AND MAX VOLUME (FOR PITCH AND VOLUME)
    /// 
    ///Here we are replacing the single clip we had before by a mutlitude of clips (needs to be set in the inspector). And pick one at random from 
    ///them. New function to pick one and different place of defining the clip of the audiosource
    /// </summary>




    private AudioSource source;

    //AudioClip[] indicates that it is an array (holds multiple of the object before the "[]", in this case AudioClips).
    public AudioClip[] anvilClips; //Needs to be added in the inspector. Reference to MULTIPLE AUDIO CLIPS

    [Range(0, 1)]
    public float minimumVolume;
    [Range(0, 1)]
    public float maximumVolume;

    [Range(0, 1)]
    public float minimumPitch;
    [Range(0, 1)]
    public float maximumPitch;


    void Start()
    {
        source = GetComponent<AudioSource>();

        //We Are not defining the clip of the source here anymore
    }

    private void PlaySound()
    {
        source.volume = RandomVolume();
        source.pitch = RandomPitch();

        //Source.Clip = sets the clip of the audiosource according to the clip you define after the "="
        source.clip = RandomAudioClip();

        source.Play();
    }

    private float RandomVolume()
    {

        return Random.Range(minimumVolume, maximumVolume);
    }


    private float RandomPitch()
    {
        return Random.Range(minimumPitch, maximumPitch);
    }


    //picks a clip from the ones we added in the inspector at random
    private AudioClip RandomAudioClip ()
    {
        //Chooses a clip at random
        //anvilClips[*insert whole number here*] indicates that you are choosing a value from the array we defined earlier (line 22)
        //Random.Range chooses a value between the two we put in the parenthesis (in this case 0 and the length of the array, so that
        //we choose a value from all the possible clips)
        return anvilClips[Random.Range(0, anvilClips.Length)];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound();
        }
    }
}
