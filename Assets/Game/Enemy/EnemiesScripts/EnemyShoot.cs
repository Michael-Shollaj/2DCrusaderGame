using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject theProjectile;
    public float shootTime;
    public int chanceShoot;
    public Transform shootFrom;

    float nextShootTime;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
                anim.SetTrigger("Shoot");
            }
        }
    }
}