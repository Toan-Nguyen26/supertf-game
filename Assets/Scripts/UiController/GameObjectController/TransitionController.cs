using UnityEngine;
using System;

public class TransitionController : CollisionController
{
    [Header("Transition")]
    // This field is optional , since it's only for the gameOject that's locked behind it
    [SerializeField] protected string numToUnlock;

    // This field is needed for transition , the gameObject and the sceneName that it's going to 
    [SerializeField] protected GameObject levelLoader;

    [SerializeField] protected string sceneName;

    protected override void collisonAction()
    {

        int unlock = Int32.Parse(numToUnlock);
        if (PlayerPrefs.GetInt("keys") < unlock)
        {
            GameData.GameStatus.isMoving = false;
            startConversation();
        }
        else
        {
            levelLoader.GetComponent<SceneTranstion>().SceneMoving(sceneName);
        }
    }

}