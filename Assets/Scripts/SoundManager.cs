using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> soundEffects = new List<AudioClip>();

    private AudioSource audioSource;

    private void Start()

    {

        audioSource = GetComponent<AudioSource>();

    }

    public void PlaySoundEffect(int index)
    {

        if (index < 0 || index >= soundEffects.Count)
        {

            Debug.LogWarning("Sound effect index out of range:+index");
            return;

        }

        audioSource.clip = soundEffects[index];
        audioSource.Play();

    }

    public void AirhornSound()
    {

        PlaySoundEffect(0);
    }

}
