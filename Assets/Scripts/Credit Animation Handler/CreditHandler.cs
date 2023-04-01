using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is responsible for the final animation plaing
public class CreditHandler : MonoBehaviour
{
    [SerializeField] Animator creditAnimation;

    [SerializeField] GameObject levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(QuitVideo());
    }

    IEnumerator QuitVideo()
    {
        yield return new WaitForSeconds(130f);
        ReturnMainMenu();
    }



    void ReturnMainMenu()
    {
        levelLoader.GetComponent<SceneTranstion>().SceneMoving("MainMenu");
    }

    public void Return()
    {
        ReturnMainMenu();
    }
}
