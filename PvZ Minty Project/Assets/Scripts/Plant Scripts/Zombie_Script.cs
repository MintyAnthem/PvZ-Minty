using UnityEngine;

public class Zombie_Script : MonoBehaviour
{
    public Rigidbody2D zombieBody;
    public float zombieSpeed;
    public int zombieHealth;

    // Update is called once per frame
    void FixedUpdate()
    {
        zombieBody.linearVelocity = -transform.right * zombieSpeed;
    }

    public void ChangeHealth(int changeHealth)
    {
        zombieHealth += changeHealth;

        if (zombieHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
