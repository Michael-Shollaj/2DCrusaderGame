using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    public BossHealthBar HealthBar;
    public int health = 200;
    public Animator anim;
    private RippleProcessor camRipple;
    public float pushback;

    public GameObject blood;
    

    public GameObject deathEffect, head, body, leg, hand, Enraged;

    public bool isInvulnerable = false;

    public SpriteRenderer[] BodyParts;
    public Color hurtColor;
    private void Start()
    {
        Enraged.SetActive(false);
        camRipple = Camera.main.GetComponent<RippleProcessor>();
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator FLash()
    {
        for(int i = 0; i < BodyParts.Length; i++)
        {
            BodyParts[i].color = hurtColor;
        }
        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < BodyParts.Length; i++)
        {
            BodyParts[i].color = Color.white;
        }
    }

    public void TakeDamage(int damage)
    {

        rb.velocity = new Vector2(rb.velocity.x, pushback);

        StartCoroutine(FLash());
        if (isInvulnerable)
            return;

        Instantiate(blood, transform.position, Quaternion.identity);

        anim.SetTrigger("Hurt");
        health -= damage;

        camRipple.RippleEffect();



        if (health <= 5)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
            Instantiate(Enraged, transform.position, Quaternion.identity);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(head, transform.position, Quaternion.identity);
        Instantiate(body, transform.position, Quaternion.identity);
        Instantiate(leg, transform.position, Quaternion.identity);
        Instantiate(hand, transform.position, Quaternion.identity);



        Destroy(gameObject);

        Debug.Log("EnemyDeath");


    }
}