using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingSound : MonoBehaviour {

    [SerializeField]
    private AudioSource source;
    public AudioClip[] clips;
    private AudioClip placeholderClip;

    public List<AudioClip> clipsList = new List<AudioClip>();

    public Queue<AudioClip> clipsQueu = new Queue<AudioClip>();

    [Range(0, 1)]
    public float minValueVolume;
    [Range(0, 1)]
    public float maxValueVolume;

    [Range(0, 3)]
    public float minValuePitch;
    [Range(0, 3)]
    public float maxValuePitch;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        PlayingOurSound();
        foreach (AudioClip c in clips)
        {
            clipsQueu.Enqueue(c);
        }
    }

    private void PlayingOurSound ()
    {
        source.clip = PickAndRearangeClips();
        source.pitch = Random.Range(minValuePitch, maxValuePitch);
        source.volume = Random.Range(minValueVolume, maxValueVolume);
        source.Play();
    }


    private AudioClip PickAndRearangeClips ()
    {
        int index = Random.Range(0, clips.Length - 1);
        placeholderClip = clips[index];
        clips[index] = clips[clips.Length -1];
        clips[clips.Length -1] = placeholderClip;
        return placeholderClip;
    }


    private void PlayingOurSoundFromList ()
    {
        source.clip = PickAndRearangeClipsList();
        source.pitch = Random.Range(minValuePitch, maxValuePitch);
        source.volume = Random.Range(minValueVolume, maxValueVolume);
        source.Play();
    }
    private AudioClip PickAndRearangeClipsList()
    {
        placeholderClip = clipsList[Random.Range(0, clipsList.Count - 1)];
        clipsList.Remove(placeholderClip);
        clipsList.Add(placeholderClip);
        return placeholderClip;
    }

    private void PlayingOurSoundFromQueue()
    {
        source.clip = PickAndRearangeClipsQueue();
        source.pitch = Random.Range(minValuePitch, maxValuePitch);
        source.volume = Random.Range(minValueVolume, maxValueVolume);
        source.Play();
    }
    private AudioClip PickAndRearangeClipsQueue()
    {
        placeholderClip = clipsQueu.Dequeue();
        clipsQueu.Enqueue(placeholderClip);
        return placeholderClip;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            PlayingOurSoundFromQueue();
            Debug.Log(source.clip.name);
        }
    }
}
