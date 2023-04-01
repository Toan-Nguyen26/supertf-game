using UnityEngine;

public class Scale : CollisionController
{
    // Override parents methods, shouldn't be doing anything 
    protected override void collisonAction()
    {
        return;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameData.GameStatus.isMoving = false;
        startConversation();
    }
}
