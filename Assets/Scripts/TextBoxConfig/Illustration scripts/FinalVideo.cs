using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class FinalVideo : MonoBehaviour
{
    [SerializeField] protected VideoPlayer vid;
    [SerializeField] protected GameObject levelLoader;


    void Start()
    {
        vid.loopPointReached += CheckOver;
    }

    // After the video end , play the soudn effect with the scene transition fading
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        levelLoader.GetComponent<SceneTranstion>().SceneMoving("Credit");
    }

}