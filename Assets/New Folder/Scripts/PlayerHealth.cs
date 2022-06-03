using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerHealth : MonoBehaviour
{

    public GameObject deathVFXPrefab;
    public PlayerHealthBar healthBar;

    public Animator anim;
    public float health;
    private float maxHealth;
    public float bounceForce;

    public GameObject blueblood;
    public GameObject Hurt;
    public GameObject deathEffect, head, body, leg, hand;
    private RippleProcessor camRipple;


    private void Start()
    {
        
        maxHealth = 10;

        camRipple = Camera.main.GetComponent<RippleProcessor>();
        Hurt.SetActive(false);
        health = maxHealth;

        anim = GetComponent<Animator>();


    }


    private void Update()
    {


    }

    public void TakeDamage(int damage)
    {
        Instantiate(blueblood, transform.position, Quaternion.identity);
        Hurt.SetActive(true);
        camRipple.RippleEffect();
        health -= damage;


        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }
    }




    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("PlayerDeath");
        Instantiate(blueblood, transform.position, Quaternion.identity);
        Instantiate(head, transform.position, Quaternion.identity);
        Instantiate(body, transform.position, Quaternion.identity);
        Instantiate(leg, transform.position, Quaternion.identity);
        Instantiate(hand, transform.position, Quaternion.identity);
        camRipple.RippleEffect();
        Instantiate(deathVFXPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        GameManager.PlayerDied();
        AudioManager.PlayDeathAudio();
    }



    IEnumerator DamageAnimation()
    {



        {
            SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

            for (int i = 0; i < 3; i++)
            {
                foreach (SpriteRenderer sr in srs)
                {
                    Color c = sr.color;
                    c.a = 0;
                    sr.color = c;
                }

                yield return new WaitForSeconds(.1f);

                foreach (SpriteRenderer sr in srs)
                {
                    Color c = sr.color;
                    c.a = 1;
                    sr.color = c;
                }



                yield return new WaitForSeconds(.1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            Die();
            GameManager.PlayerDied();
            AudioManager.PlayDeathAudio();
            camRipple.RippleEffect();
        }

    }


}