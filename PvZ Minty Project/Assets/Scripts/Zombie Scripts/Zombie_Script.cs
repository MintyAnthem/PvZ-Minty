using UnityEngine;

public class Zombie_Script : MonoBehaviour
{
    public Rigidbody2D zombieBody;
    public float zombieSpeed;
    public int zombieHealth;
    public RaycastHit2D lineOfSight;
    public float sightLength;
    public bool hasDetected;
    public LayerMask plantMask;
    public bool isWalking;
    public float attackDelay;
    public int zombieDamage;
    public Plant_Script plantScript;

    void Start()
    {
        isWalking = true;
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            zombieBody.linearVelocity = -transform.right * zombieSpeed;
        }
        else if (!isWalking)
        {
            zombieBody.linearVelocity = Vector2.zero;
        }
        
    }

    void Update()
    {
        lineOfSight = Physics2D.Raycast(transform.position, Vector2.left, sightLength, plantMask);
        Debug.DrawRay(transform.position, -Vector2.right * sightLength, Color.purple);

        if (!hasDetected && lineOfSight)
        {
            isWalking = false;
            plantScript = lineOfSight.collider.GetComponent<Plant_Script>();
            InvokeRepeating("Attack", attackDelay, attackDelay);
            hasDetected = true;
        }
        else if (hasDetected && !lineOfSight)
        {
            CancelInvoke("Attack");
            hasDetected = false;
            isWalking = true;
        }
    }

    public void ChangeHealth(int changeHealth)
    {
        zombieHealth += changeHealth;

        if (zombieHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack()
    {
        Debug.Log("Attacking");
        plantScript.ChangeHealth(zombieDamage);
    }
}
