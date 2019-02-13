using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MX_Branching : MonoBehaviour {

    public static MX_Branching instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public int numberOfAudioSources;
    //List<AudioSource> sources = new List<AudioSource>();
    private Queue<AudioSource> sources = new Queue<AudioSource>();

    public MX_BranchingSegment startingMusic;

    private bool changeAudio = false;
    private int changeOnNextSample;
    private AudioSource playingSource;
    private bool playingSegment = true;
    public MX_BranchingSegment currentBranch;

    void Start () {
        for (int i = 0; i < numberOfAudioSources; i ++)
        {
            AudioSource sourceToAdd = gameObject.AddComponent<AudioSource>();
            sourceToAdd.loop = true;
            sourceToAdd.playOnAwake = false;
            sourceToAdd.volume = 1;
            sourceToAdd.pitch = 1;
            sourceToAdd.spatialBlend = 0;
            sources.Enqueue(sourceToAdd);
        }

        StartMX();
    }

    private void StartMX ()
    {
        currentBranch = startingMusic;
        Debug.Log(currentBranch.musicSegments[0].segment.name);
        playingSource = sources.Dequeue();
        playingSource.clip = startingMusic.musicSegments[0].segment;
        playingSource.Play();
        sources.Enqueue(playingSource);


    }

    public void ChangeToNewBranch (MX_BranchingSegment nextSegment)
    {
        changeOnNextSample = currentBranch.ReturnNextBeat(playingSource.timeSamples, playingSegment);
        currentBranch = nextSegment;
        changeAudio = true;
    }

    void Update () 
    {
        Debug.Log(changeOnNextSample);

        if (playingSource.timeSamples > changeOnNextSample && changeAudio == true && playingSegment)
        {
            StartCoroutine(stopAfter3seconds(playingSource));
            currentBranch.snapshotToLoad.TransitionTo(1.5f);
            playingSource = sources.Dequeue();
            currentBranch.PlayTransition(playingSource);
            sources.Enqueue(playingSource);
            playingSegment = false;
            changeOnNextSample = currentBranch.ReturnNextBeat(playingSource.timeSamples, playingSegment);
        }
        else if (playingSource.timeSamples > changeOnNextSample && changeAudio == true && !playingSegment)
        {
            playingSource = sources.Dequeue();
            currentBranch.Play(playingSource);
            if (currentBranch.musicSegments.Length > 0)
            {
                for (int i = 1; i < currentBranch.musicSegments.Length; i++)
                {
                    AudioSource layer = sources.Dequeue();
                    currentBranch.PlayLayer(layer, i);
                    sources.Enqueue(layer);

                }
            }
            sources.Enqueue(playingSource);
            playingSegment = true;
            changeAudio = false;
        }
    }

    IEnumerator stopAfter3seconds (AudioSource source)
    {
        yield return new WaitForSecondsRealtime(1.5f);
        source.Stop();
    }
}
