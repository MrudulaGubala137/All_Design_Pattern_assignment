using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    // Start is called before the first frame update
    public enum STATE { LOOKFOR, GOTO, ATTACK, DEAD };
    public STATE currentState = STATE.LOOKFOR;
    public float enemySpeed;
    public float attackDistance;
    public float gotoDistance;
    public Transform target;
    public string playerTag;
    public float attackTime;
    public float currentTime;
    PlayerMovement playerMovement;
    IEnumerator Start()
    {
        currentTime = attackTime;
        if (target != null)
        {
            playerMovement = target.GetComponent<PlayerMovement>();

        }
        while (true)
        {
            switch (currentState)
            {
                case STATE.LOOKFOR:
                    LookFor();

                    break;
                case STATE.GOTO:
                    Goto();
                    break;
                case STATE.ATTACK:
                    Attack();
                    break;
                case STATE.DEAD:
                    Dead();
                    break;
                default:
                    break;
            }
            yield return null;
        }

    }

    public void LookFor()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) < gotoDistance)
        {
            currentState = STATE.GOTO;
        }
        print("This is LookForState");
    }
    public void Goto()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            currentState = STATE.ATTACK;
        }
        print("This is GotoState");
    }
    public void Attack()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime < 0f)
        {
            playerMovement.health--;
            print(playerMovement.health);
            currentTime = attackTime;
        }
        if (playerMovement.health < 0)
        {
            currentState = STATE.DEAD;
        }
        if (Vector3.Distance(target.transform.position, this.transform.position) > attackDistance)
        {
            currentState = STATE.ATTACK;
        }
        print("This is AttackState");
    }
    public void Dead()
    {
        print("Game Over!!");
    }
    
}


