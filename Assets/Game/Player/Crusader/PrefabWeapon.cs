using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Animator anim;

    private void Update()
    {

    }

    public void BowAttack()
    {
        if (timeBtwShots <= 0)
        {
            anim.SetTrigger("Bow");
            Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
            Instantiate(projectile, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
