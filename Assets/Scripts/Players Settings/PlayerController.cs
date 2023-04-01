using System.Collections.Generic;
using GameData;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // variable to hold a reference to our SpriteRenderer component
    [SerializeField] SpriteRenderer mySpriteRenderer;

    [SerializeField] Rigidbody2D rb;

    private Vector2 moveDirection;

    // The animator responsible for the animation of the player
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    // Starting will find the prev and cur room in the GameData , and then load the player's 
    // cord corresponding to the number declare in the database
    void Start()
    {
        // if (!PlayerPrefs.HasKey("NewGame")) GameData.GameStatus.isMoving = false;
        // else GameData.GameStatus.isMoving = true;

        string previousRoom = PlayerPrefs.GetString("PreviousRoom");
        string currentRoom = PlayerPrefs.GetString("CurrentRoom");
        List<GameDataInfo> gameDataInfoList = GameData.GameData.Instance.gameDataInfo;

        foreach (GameDataInfo i in gameDataInfoList)
        {
            if (previousRoom == i.previousLocation && currentRoom == i.nextLocation)
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(i.x_cord, i.y_cord);
                break;
            }
        }
    }

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        // Physiscal Calculation
        Move();
    }

    void ProcessInputs()
    {
        bool curStatus = GameData.GameStatus.isMoving;
        // If super is allowed to move 
        if (curStatus)
        {
            // Get the current virtual axis
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            // Apply that to the animator , mkig it play whenever we move
            animator.SetFloat("Speed", Mathf.Abs(moveX) + Mathf.Abs(moveY));

            // Check to see if the player is facing left or right , flipX if 
            if (moveX < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (moveX > 0)
            {
                // flip the sprite
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            // Get the moveDiretion of super
            moveDirection = new Vector2(moveX, moveY).normalized;
        }
        else
        {

            // Else , halt all movement and animation , like when pausing the menu , interating with the object , etc.. 
            animator.SetFloat("Speed", Mathf.Abs(0f) + Mathf.Abs(0f));
        }
        print(animator.GetFloat("Speed"));
    }

    void Move()
    {
        bool curStatus = GameData.GameStatus.isMoving;
        float moveSpeed;

        // Calculate the move speed based on the screen width
        float screenWidth = Screen.width;
        float moveSpeedScale = screenWidth / 1920f; // Adjust 1280f based on your desired base screen width
        moveSpeed = 1.65f * moveSpeedScale;

        // Set the velocity of the player based on the move direction and move speed
        if (curStatus)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }





}
