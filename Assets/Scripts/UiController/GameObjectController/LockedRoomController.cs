using UnityEngine;
using System;

public class LockedRoomController : TransitionController
{

    protected override void collisonAction()
    {
        if (!PlayerPrefs.HasKey(numToUnlock))
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