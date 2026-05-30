using UnityEngine;

public class Aloe_Script : MonoBehaviour
{
    public int healAmount;
    public float healDelay;
    public Transform healPoint;
    public RaycastHit2D lineOfSight;
    public float sightLength;
    public LayerMask plantMask;
    public bool hasDetected;
    public Plant_Script plantScript;

    void Update()
    {
        lineOfSight = Physics2D.Raycast(healPoint.position, Vector2.right, sightLength, plantMask);
        Debug.DrawRay(healPoint.position, Vector2.right * sightLength, Color.blue);

        if (!hasDetected && lineOfSight)
        {
            plantScript = lineOfSight.collider.GetComponent<Plant_Script>();
            InvokeRepeating("Heal", healDelay, healDelay);
            hasDetected = true;
        }
        else if (hasDetected && !lineOfSight)
        {
            CancelInvoke("Heal");
            hasDetected = false;
        }
    }

    public void Heal()
    {
        plantScript.ChangeHealth(healAmount);
    }
}
