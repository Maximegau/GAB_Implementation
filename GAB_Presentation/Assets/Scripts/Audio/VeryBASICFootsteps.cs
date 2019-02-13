using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeryBASICFootsteps : MonoBehaviour {

    [System.Serializable]
    public class footstepClips
    {
        public AudioClip[] footstepAudioClips;
        public surfaces footstepSurface;
    }

    public footstepClips[] allFootsteps;

    public enum surfaces
    {
        wood,
        grass
    }

    private RaycastHit hit;
    private bool stopCoroutine = true;
    private Queue<AudioSource> sources = new Queue<AudioSource>();
    private AudioSource currentSource;
    [SerializeField]
    private surfaces currentSurface;

    private void Start()
    {
        foreach (AudioSource i in GetComponents<AudioSource>())
        {
            sources.Enqueue(i);
        }
    }

    private void PlayFootsteps (surfaces surface)
    {
        currentSource = sources.Dequeue();
        switch (surface)
        {
            case (surfaces.grass):
                for (int i = 0; i < allFootsteps.Length; i++)
                    if (allFootsteps[i].footstepSurface == surfaces.grass)
                        currentSource.clip = allFootsteps[i].footstepAudioClips[Random.Range (0, allFootsteps[i].footstepAudioClips.Length)];
                break;
            case (surfaces.wood):
                for (int i = 0; i < allFootsteps.Length; i++)
                    if (allFootsteps[i].footstepSurface == surfaces.wood)
                        currentSource.clip = allFootsteps[i].footstepAudioClips[Random.Range(0, allFootsteps[i].footstepAudioClips.Length)];
                break;
        }
        currentSource.Play();
        sources.Enqueue(currentSource);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayFootsteps(currentSurface);
            stopCoroutine = false;
            StartCoroutine(WalkCycle());
        }
        if (Input.GetKeyUp (KeyCode.W))
        {
            stopCoroutine = true;
        }

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            switch (hit.collider.tag)
            {
                case ("Grass"):
                    currentSurface = surfaces.grass;
                    break;
                case ("Wood"):
                    currentSurface = surfaces.wood;
                    break;
            }
        }
    }

    IEnumerator WalkCycle ()
    {
        yield return new WaitForSeconds(.7f);
        if (!stopCoroutine)
        {
            PlayFootsteps(currentSurface);
            StartCoroutine(WalkCycle());
        }

    }
}
