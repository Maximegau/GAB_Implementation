using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_05_AddingNoRepeats : MonoBehaviour {


    /// <summary>
    /// YOU NEED TO HAVE AN AUDIOSOURCE ON THE GAME OBJECT AND NEED TO HAVE ASSIGNED AUDIOCLIPS FOR THIS SCRIPT TO WORK AS WELL AS HAVING DEFINED
    /// VALUES FOR MIN AND MAX VOLUME (FOR PITCH AND VOLUME)
    /// 
    ///Here we are making sure that we don't repeat the last clip that way we can ensure that we don't encounter the Machine Gun Effect
    /// </summary>




    private AudioSource source;

    public AudioClip[] anvilClips; //NEEDS TO BE MORE THAN 1
    private AudioClip tempClip; //Holds a reference to our audioclip that needs to be not repeated

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
    private AudioClip RandomAudioClip()
    {
        //holds a reference to the clip we picked
        int arrayIndex;
        //chooses a clip number at random between the first value and the second to last value
        //This is important as you always ignore the last value so that you dont repeat it
        arrayIndex = Random.Range(0, anvilClips.Length - 1);
        //defines the tempClip so that we can move things around in the array
        tempClip = anvilClips[arrayIndex];
        //we are moving the last clip to the position of the clip selected
        anvilClips[arrayIndex] = anvilClips[anvilClips.Length - 1];
        //we are setting the last clip of the array to be equal to the clip we selected that way
        //it will not selected next time we play a clip as it ignores the last clip
        anvilClips[anvilClips.Length - 1] = tempClip;
        return tempClip;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound();
        }
    }
}