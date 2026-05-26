using UnityEngine;

public class Peashooter_Script : MonoBehaviour
{
    public GameObject projectileObject;
    public Transform shootPoint;
    public float shootDelay;
    bool shootLoop;

    void Start()
    {
        InvokeRepeating("Shoot", shootDelay, shootDelay);
    }

    public void Shoot()
    {
        Instantiate(projectileObject, shootPoint.position, Quaternion.identity);
    }
}
