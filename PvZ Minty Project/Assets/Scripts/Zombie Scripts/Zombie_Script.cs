using UnityEngine;

public class Zombie_Script : MonoBehaviour
{
    public Rigidbody2D zombieBody;
    public float zombieSpeed;
    public int zombieHealth;
    public RaycastHit2D lineOfSight;
    public LayerMask plantMask;
    public bool isWalking;
    public float attackDelay;
    public int zombieDamage;

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
        lineOfSight = Physics2D.Raycast(transform.position, Vector2.left, 0.25f, plantMask);
        Debug.DrawRay(transform.position, -Vector2.right * 0.25f, Color.purple);

        if (lineOfSight)
        {
            isWalking = false;
            //plantScript = hitInfo.GetComponent<Plant_Script>();
            InvokeRepeating("Attack", attackDelay, attackDelay);
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
        /*plantScript.ChangeHealth(zombieDamage);
        if (plantScript = null)
        {
            CancelInvoke("Attack");
            isWalking = true;
        }
        */
    }
}
