using UnityEngine;

public class PoddaTroop_Script : MonoBehaviour
{
    public Rigidbody2D poddaBody;
    public float poddaSpeed;
    public RaycastHit2D lineOfSight;
    public float sightLength;
    public bool hasDetected;
    public LayerMask zombieMask;
    public bool isWalking;
    public float attackDelay;
    public int poddaDamage;
    public Zombie_Script zombieScript;

    void Start()
    {
        isWalking = true;
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            poddaBody.linearVelocity = transform.right * poddaSpeed;
        }
        else if (!isWalking)
        {
            poddaBody.linearVelocity = Vector2.zero;
        }

    }

    void Update()
    {
        lineOfSight = Physics2D.Raycast(transform.position, Vector2.right, sightLength, zombieMask);
        Debug.DrawRay(transform.position, Vector2.right * sightLength, Color.green);

        if (!hasDetected && lineOfSight)
        {
            isWalking = false;
            zombieScript = lineOfSight.collider.GetComponent<Zombie_Script>();
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

    public void Attack()
    {
        Debug.Log("Attacking");
        zombieScript.ChangeHealth(poddaDamage);
    }
}
