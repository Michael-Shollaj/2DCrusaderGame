using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo : MonoBehaviour
{
    public Animator playerAnim;
    bool comboPossible;
    int comboStep;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public static int AttackDamage = 2;

    public void Attack()
    {
        if (comboStep == 0)
        {
            playerAnim.Play("Hit1");
            comboStep = 1;
            return;
        }
        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BossHealth>().TakeDamage(AttackDamage);
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void Combo()
    {
        if (comboStep == 2)
            playerAnim.Play("Hit2");
        if (comboStep == 3)
        {
            playerAnim.Play("Hit3");
        }
    }
    public void ComboReset()
    {
        comboPossible = false;
        comboStep = 0;
    }

}
