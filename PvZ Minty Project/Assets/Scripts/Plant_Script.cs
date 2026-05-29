using UnityEngine;

public class Plant_Script : MonoBehaviour
{
    public int plantHealth;
    public GameObject plantObject;

    public void ChangeHealth(int changeHealth)
    {
        plantHealth += changeHealth;

        if (plantHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
