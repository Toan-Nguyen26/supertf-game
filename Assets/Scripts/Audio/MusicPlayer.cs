using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameData;

// This code store the playerPref audio settings 
// Each time they changed , it update the volume of game
public class MusicPlayer : MonoBehaviour
{
    public GameObject musicObject;
    public Slider musicVolumeSlider;

    public Slider soundEffectVolumeSlider;

    private AudioSource audioSource;

    private float musicVolume = 0.5f;

    private float soundEffectVolume = 0.35f;

    private float previousVolume = 0.5f;

    void Start()
    {
        SettingMusicVolume();
        SettingSoundEffectVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousVolume != musicVolume)
        {
            PlayerPrefs.SetFloat("gameVolume", musicVolume);
            previousVolume = musicVolume;
        }

        audioSource.volume = musicVolume;
    }

    public void UpdateMusicVolume(float volume)
    {
        musicVolume = volume;
    }

    public void UpdateSoundEffectVolume(float volume)
    {
        soundEffectVolume = volume;
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
    }

    void SettingMusicVolume()
    {
        // Get the gameObject with the tag GameMusic
        musicObject = GameObject.FindGameObjectWithTag("GameMusic");

        // Get the AudioSource out of it
        audioSource = musicObject.GetComponent<AudioSource>();

        // Set the volume to the playerPref we have 
        if (PlayerPrefs.HasKey("gameVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("gameVolume");
        }

        // Set the audioSouce of the gameMusic and the slider corresponding to the musicVolume
        audioSource.volume = musicVolume;
        musicVolumeSlider.value = musicVolume;
    }

    void SettingSoundEffectVolume()
    {
        // Set the volume to the playerPref we have 
        if (PlayerPrefs.HasKey("soundEffectVolume"))
        {
            soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
        }
        soundEffectVolumeSlider.value = soundEffectVolume;
    }


}

