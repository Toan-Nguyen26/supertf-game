using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour
{
    // Our Audio Source
    [SerializeField] AudioClip defaultClip;

    // Our Audio Source
    [SerializeField] AudioSource audioSource;
    // Check to see if there's more than 1 gameObject in the scene , if it does than we remove it  
    // Else Insititate it
    private void Awake()
    {
        LoadAudioClipForScene();
        DontDestroyOnLoad(gameObject);
        audioSource.volume = PlayerPrefs.GetFloat("gameVolume", 0.5f);
    }

    void LoadAudioClipForScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "MainMenu":
                PlayAudioClip(GameData.GameData.Instance.gameSongs[0]);
                break;
            case "StartingRoomNew":
                if (PlayerPrefs.GetInt("keys") == 0) PlayAudioClip(GameData.GameData.Instance.gameSongs[1]);
                else PlayAudioClip(defaultClip);
                break;
            case "Gym":
                PlayAudioClip(GameData.GameData.Instance.gameSongs[2]);
                break;
            case "Museum":
                PlayAudioClip(GameData.GameData.Instance.gameSongs[3]);
                break;
            case "BirthdayRoom":
                PlayAudioClip(GameData.GameData.Instance.gameSongs[4]);
                break;
            case "FinalVideo":
                DestroyOtherGameObjects();
                break;
            case "Credit":
                PlayAudioClip(GameData.GameData.Instance.gameSongs[5]);
                break;
            default:
                PlayAudioClip(defaultClip);
                break;
        }

    }
    private void PlayAudioClip(AudioClip clip)
    {

        // If the song is different , destroy the old song , and replace a new gameObject with this new song
        // Store the song in the playerPref for last played song
        if (clip.name != GameData.GameStatus.lastSong)
        {
            DestroyOtherGameObjects();
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            GameData.GameStatus.lastSong = clip.name;
        }
        // Else they're the same song , just delete it
        else
        {
            Destroy(gameObject);
        }

    }

    private void DestroyOtherGameObjects()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("GameMusic");
        foreach (GameObject j in music)
        {
            if (j != gameObject) Destroy(j);
        }
    }
}