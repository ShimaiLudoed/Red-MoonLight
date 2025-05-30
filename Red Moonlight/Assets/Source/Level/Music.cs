using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    
    [SerializeField] [ItemCanBeNull] private AudioClip mainMenuMusic;
    [SerializeField] [ItemCanBeNull] private AudioClip gameMusic;  
    [SerializeField] [ItemCanBeNull] private Slider volumeSlider; 
    [SerializeField] [ItemCanBeNull] private AudioSource audioSource;

    private void Start()
    {
        audioSource.loop = true;
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        SetVolume(volumeSlider.value);
        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic()
    {
        PlayMusic(mainMenuMusic);
    }
    public void PlayGameMusic()
    {
        PlayMusic(gameMusic);
    }
    public void PlayRoomMusic(AudioClip roomMusic)
    {
        PlayMusic(roomMusic);
    }
    private void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip != clip) 
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
    private void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume); 
    }
}
