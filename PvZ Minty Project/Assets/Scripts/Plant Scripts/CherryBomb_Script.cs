using UnityEngine;

public class CherryBomb_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosionRadius, mask);
    Health health;
        foreach (Collider2D col in cols)
        {
            health = col.gameObject.transform.root.GetComponent<Health>();
            health?.TakeDamage(explosionDamage);
        }*/
}
