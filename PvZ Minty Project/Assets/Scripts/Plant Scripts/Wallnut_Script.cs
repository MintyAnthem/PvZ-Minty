using UnityEngine;

public class Wallnut_Script : MonoBehaviour
{
    public SpriteRenderer wallnutRenderer;
    public Sprite level3Wallnut;
    public Sprite level2Wallnut;
    public Sprite level1Wallnut;
    public Plant_Script plantScript;

    void Update()
    {
        if (plantScript.plantHealth <= 150 && plantScript.plantHealth > 100)
        {
            wallnutRenderer.sprite = level3Wallnut;
        }
        else if (plantScript.plantHealth <= 100 && plantScript.plantHealth > 50)
        {
            wallnutRenderer.sprite = level2Wallnut;
        }
        else if (plantScript.plantHealth <= 50)
        {
            wallnutRenderer.sprite = level1Wallnut;
        }
    }
}
