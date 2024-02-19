using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    #region Attributes
    public List<AudioClip> musicClips = new List<AudioClip>();
    public MusicQueue musicQueue;
    public static AudioSource music;
    AudioClip currentTrack;
    private float length;
    private Coroutine musicLoop;
    private AudioSource musicSource;

    #endregion

    void Start()
    {
        musicQueue = new MusicQueue(musicClips);

        musicSource = GetComponent<AudioSource>();

        StartMusic();
    }

    #region Audio Playing

    public void PlayMusicClip(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicLoop != null)
            StopCoroutine(musicLoop);

        music.Stop();
    }

    public void StartMusic()
    {
        musicLoop = StartCoroutine(musicQueue.LoopMusic(this, 0, PlayMusicClip));
    }

    #endregion
}

public class MusicQueue
{
    List<AudioClip> clips;

    public MusicQueue(List<AudioClip> clips)
    {
        this.clips = clips;
    }

    public IEnumerator LoopMusic(MonoBehaviour player, float delay, System.Action<AudioClip> playFunction)
    {
        while (true)
        {
            yield return player.StartCoroutine(Run(RandomizeList(clips), delay, playFunction));
        }
    }

    public IEnumerator Run(List<AudioClip> tracks,
        float delay, System.Action<AudioClip> playFunction)
    {
        foreach (AudioClip clip in tracks)
        {
            playFunction(clip);

            yield return new WaitForSeconds(clip.length + delay);
        }
    }

    public List<AudioClip> RandomizeList(List<AudioClip> list)
    {
        List<AudioClip> copy = new List<AudioClip>(list);

        int n = copy.Count;


        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);

            AudioClip value = copy[k];

            copy[k] = copy[n];
            copy[n] = value;
        }

        return copy;
    }
}