using UnityEngine;

public class BedCheckingScript : MonoBehaviour
{
    [SerializeField] GameObject oldBed;

    [SerializeField] GameObject newBed;

    void Awake()
    {
        if (PlayerPrefs.HasKey("NewReality"))
        {
            oldBed.SetActive(true);

        }
        else
        {
            newBed.SetActive(true);
        }
    }

}
