using UnityEngine;
using GameData;

// A code handle different type of cursor : point , question mark and exit door
public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorArrow;

    [SerializeField] Texture2D cursorEnter;

    // Default will alsways be point thingy
    void Awake()
    {
        ChangeCursor(cursorArrow);
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        ChangeCursor(cursorEnter);
    }

    void OnMouseExit()
    {
        ChangeCursor(cursorArrow);
    }

    void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (!GameData.GameStatus.isMoving) ChangeCursor(cursorArrow);
    }
}
