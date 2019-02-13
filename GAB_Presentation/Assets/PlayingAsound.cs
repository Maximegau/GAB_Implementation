using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingAsound : MonoBehaviour {
    private AudioSource source;
    public AudioClip[] arrayOfSFX;
    private AudioClip temporaryClipHolder;

    [Range(0, 1)]
    public float minVolumeValue;
    [Range(0, 1)]
    public float maxVolumeValue;

    [Range(0, 3)]
    public float minPitchValue;
    [Range(0,3)]
    public float maxPitchValue;

    void Start () {
        source = GetComponent<AudioSource>();
	}
	
    private float PickARandomNumber (float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    private void PlaySound ()
    {
        source.volume = PickARandomNumber(minVolumeValue, maxVolumeValue);
        source.pitch = PickARandomNumber(minPitchValue, maxPitchValue);

        int indexOfArray = Random.Range(0, arrayOfSFX.Length - 1);
        source.clip = arrayOfSFX[indexOfArray];

        ReorganizeArray(indexOfArray);
        source.Play();
    }

    private void ReorganizeArray (int index)
    {
        temporaryClipHolder = arrayOfSFX[index];
        arrayOfSFX[index] = arrayOfSFX[arrayOfSFX.Length - 1];
        arrayOfSFX[arrayOfSFX.Length - 1] = temporaryClipHolder;
    }


    void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
        {
            PlaySound();
        }
    }
}
