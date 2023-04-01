using UnityEngine;

public class OWFrogKey : ReplaceSpriteManager
{
    // Start is called before the first frame update
    void Update()
    {
        removeCollisionController();
    }
    protected override void removeCollisionController()
    {
        if (PlayerPrefs.HasKey(lockedKey))
        {
            CollisionController collisionControllerScript = GetComponent<CollisionController>();
            MouseManager mouseManagerScirpt = GetComponent<MouseManager>();
            ExclaimationMarkManager exclaimationMarkManagerScript = GetComponent<ExclaimationMarkManager>();


            Destroy(collisionControllerScript);
            Destroy(mouseManagerScirpt);
            Destroy(exclaimationMarkManagerScript);
            Destroy(gameObject.transform.GetChild(0).gameObject);

            enabled = false;
        }
    }
}
