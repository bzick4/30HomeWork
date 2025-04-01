using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private List<AudioClip> songs = new List<AudioClip>();
    private int currentSongIndex = -1;

    private void Start()
    {
        AudioClip[] loadedSongs = Resources.LoadAll<AudioClip>("Audio");
        
        if (loadedSongs.Length == 0)
        {
            Debug.LogError("No songs found in Resources/Audio!");
            return;
        }

        songs.AddRange(loadedSongs);
        PlayRandomSong();
    }

    private void PlayRandomSong()
    {
        if (songs.Count == 0) return;

        int newIndex;
        do {
            newIndex = Random.Range(0, songs.Count);
        } while (newIndex == currentSongIndex && songs.Count > 1);

        currentSongIndex = newIndex;
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        StartCoroutine(WaitForSongEnd());
    }

    private IEnumerator WaitForSongEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        PlayRandomSong();
    }

    public void NextSong()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        PlayRandomSong();
    }



}

