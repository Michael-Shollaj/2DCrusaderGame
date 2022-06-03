using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : Enemies
{
    //variables
    public int _moveSpeed;
    public int attackDamage;
    public int _lifePoints;
    public float _attackRadius;
    public GameObject Effect;
    public Vector3 attackOffset2;
    public float attackRange2 = 1f;
    public LayerMask attackMask2;

    public GameObject Notice;




    //movement
    public float _followRadius;
    //end
    Transform playerTransform;


    Animator enemyAnim;
    SpriteRenderer enemySR;

    void Start()
    {

        //get the player transform   
        playerTransform = FindObjectOfType<PlayerHealth>().GetComponent<Transform>();
        //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
        Notice.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("Attack", true);
                    Debug.Log("Attack");
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("Attack", false);
                    //walk
                    enemyAnim.SetBool("Walking", true);
                    Notice.SetActive(true);
                    StartCoroutine(EnemyNoticeUs());
                    enemySR.flipX = true;
                    Debug.Log("Rotate");
                }

            }
            //if player is behind enemies
            else if (playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("Attack", true);
                    Debug.Log("Attack");
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("Attack", false);
                    //walk
                    enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = false;
                    Debug.Log("Walk");

                }


            }
        }
        else
        {
            enemyAnim.SetBool("Walking", false);
            Debug.Log("Idle");

        }


    }

    public void Attack1()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset2.x;
        pos += transform.up * attackOffset2.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange2, attackMask2);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Instantiate(Effect, transform.position, Effect.transform.rotation);

        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset2.x;
        pos += transform.up * attackOffset2.y;

        Gizmos.DrawWireSphere(pos, attackRange2);
    }

    private IEnumerator EnemyNoticeUs()
    {
        yield return new WaitForSeconds(.5f);
        Notice.SetActive(false);
    }
}