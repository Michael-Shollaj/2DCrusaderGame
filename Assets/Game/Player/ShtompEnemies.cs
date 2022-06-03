using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShtompEnemies : MonoBehaviour
{
    public int damage;
    public float bounce;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<BossHealth>().TakeDamage(damage);
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
    }
}
