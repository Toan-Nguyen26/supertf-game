using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class MovingRealityHandler : MonoBehaviour
{
    [SerializeField] protected VideoPlayer vid;
    [SerializeField] GameObject kingCrimsonObject;

    [SerializeField] GameObject supertf;
    [SerializeField] protected GameObject levelLoader;

    private AudioSource audioSource;

    private GameObject musicObject;

    void Start()
    {
        supertf.GetComponent<KeyboardController>().SetLayer("Ignore Raycast");
        musicObject = GameObject.FindGameObjectWithTag("GameMusic");
        audioSource = musicObject.GetComponent<AudioSource>();
        vid.loopPointReached += CheckOver;
    }

    // After the video end , play the soudn effect with the scene transition fading
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        StartCoroutine(CrimsonNoise());
    }

    IEnumerator CrimsonNoise()
    {
        // First stop playing the song right now
        audioSource.Stop();

        // Then play the king Crimson noise
        kingCrimsonObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(3f);

        levelLoader.GetComponent<SceneTranstion>().SceneMoving("StartingRoomNew");
        PlayerPrefs.SetString("NewReality", "ANewWorld");
    }
}