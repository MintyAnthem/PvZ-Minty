using UnityEngine;

public class Plant_Script : MonoBehaviour
{
    public int plantHealth;
    public int maxHealth;
    public GameObject plantObject;

    public void ChangeHealth(int changeHealth)
    {
        plantHealth += changeHealth;

        if (plantHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (plantHealth > maxHealth)
        {
            plantHealth = maxHealth;
        }
    }


}
