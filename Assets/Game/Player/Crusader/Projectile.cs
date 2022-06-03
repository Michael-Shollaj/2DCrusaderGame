using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed;

    public float lifeTime;
    public int damage;
    private Rigidbody2D rb;
    public GameObject destroyEffect;
    private Vector2 direction;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
 
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<BossHealth>().TakeDamage(damage);
        }
    }
}