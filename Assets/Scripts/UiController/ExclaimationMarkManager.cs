using UnityEngine;
using GameData;

public class ExclaimationMarkManager : MonoBehaviour
{
    [SerializeField] GameObject Exclaimation_mark;

    // Check to see if it's active or not
    void Update()
    {
        if ((Input.GetMouseButton(1)) && (GameData.GameStatus.isMoving)) Exclaimation_mark.SetActive(true);
        else Exclaimation_mark.SetActive(false);
    }
}
