using UnityEngine;

public class Projectile_Script : MonoBehaviour
{
    public Rigidbody2D projectileBody;
    public float projectileSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        projectileBody.linearVelocity = transform.right * projectileSpeed;
    }
}
