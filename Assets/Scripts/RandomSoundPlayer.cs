using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField] private string folderName = "";
    private AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClips = Resources.LoadAll<AudioClip>(folderName);

        if (audioClips.Length == 0)
            Debug.LogWarning("No audio clips found in Resources folder: " + folderName);
        else
            PlayRandomSound();
    }

    public void PlayRandomSound()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
        }
    }
}

