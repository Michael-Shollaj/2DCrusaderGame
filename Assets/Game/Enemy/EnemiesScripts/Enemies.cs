using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //base class so it can be inherited from other scripts

    int moveSpeed;
    int attackDamage;
    int lifePoints;
    float attackRadius;

    //movement
    float followRadius;

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }

    public void setAttackDamage(int attdmg)
    {
        attackDamage = attdmg;
    }

    public void setLifePoints(int lp)
    {
        lifePoints = lp;
    }

    public int getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getAttackDamage()
    {
        return attackDamage;
    }

    public int getLifePoints()
    {
        return lifePoints;
    }


    //movement toward a player
    public void setFollowRadius(float r)
    {
        followRadius = r;
    }
    //attack radius 
    public void setAttackRadius(float r)
    {
        attackRadius = r;
    }

    //if player in radius move toward him 
    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius)
        {
            //player in range
            return true;
        }
        else
        {
            return false;
        }
    }

    //if player in radius attack him
    public bool checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius)
        {
            //in range for attack
            return true;
        }
        else
        {
            return false;
        }
    }
}