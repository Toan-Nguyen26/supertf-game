using UnityEngine;
public class CollisionController : MonoBehaviour
{
    [SerializeField] public GameObject player;

    [SerializeField] public Collider2D anotherCollider;


    [Header("Object")]
    // This field is optional , since it's only for the gameObject with with textBox in it
    [SerializeField] GameObject textBox;


    // Check if the player collide
    void OnMouseDown()
    {
        float distanceThreshold = Camera.main.orthographicSize * 0.5f;

        // If it's an object , we can ignore scene transition
        // Else move to the scene corresponding to the ID
        if (Vector2.Distance(player.transform.position, anotherCollider.transform.position) <= distanceThreshold)
        {
            // Secondly stop all player's movement
            collisonAction();
        }
    }

    // A control where it's virtual , so that child class can edit and such
    protected virtual void collisonAction()
    {
        GameData.GameStatus.isMoving = false;
        startConversation();
    }

    protected void startConversation()
    {
        // First make the textbox appear
        textBox.SetActive(true);

    }
}
