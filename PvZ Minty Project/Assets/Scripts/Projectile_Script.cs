using UnityEngine;

public class Projectile_Script : MonoBehaviour
{
    public Rigidbody2D projectileBody;
    public float projectileSpeed;
    public int projectileDamage;
    public Zombie_Script zombieScript;
    public LayerMask projectileTarget;

    // Update is called once per frame
    void FixedUpdate()
    {
        projectileBody.linearVelocity = transform.right * projectileSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if ((projectileTarget.value & (1 << hitInfo.gameObject.layer)) != 0)
        {
            zombieScript = hitInfo.GetComponent<Zombie_Script>();
            if (zombieScript != null)
            {
                zombieScript.ChangeHealth(projectileDamage);
            }
            Destroy(gameObject);
            Debug.Log(hitInfo.name);
        }
    }
}
