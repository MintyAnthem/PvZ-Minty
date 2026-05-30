using UnityEngine;

public class Peashooter_Script : MonoBehaviour
{
    public GameObject projectileObject;
    public Transform shootPoint;
    public float shootDelay;
    public RaycastHit2D lineOfSight;
    public float sightLength;
    public LayerMask zombieMask;
    public bool hasDetected;

    void Update()
    {
        lineOfSight = Physics2D.Raycast(transform.position, Vector2.right, sightLength, zombieMask);
        Debug.DrawRay(transform.position, Vector2.right * sightLength, Color.green);

        if (!hasDetected && lineOfSight)
        {
            InvokeRepeating("Shoot", shootDelay, shootDelay);
            hasDetected = true;
        }
        else if (hasDetected && !lineOfSight)
        {
            CancelInvoke("Shoot");
            hasDetected = false;
        }
    }

    public void Shoot()
    {
        Instantiate(projectileObject, shootPoint.position, Quaternion.identity);
    }
}
