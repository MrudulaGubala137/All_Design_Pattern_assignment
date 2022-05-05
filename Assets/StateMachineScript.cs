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
   // public string playerTag;
   
    PlayerMovement playerMovement;
    public Animator anim;
   // public GameObject enemy;
    public Vector3 offSet;
    float time;
    IEnumerator Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
       
            if (target == null)
            {
                target = GameObject.Find("Player").GetComponent<Transform>();
            }
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
       /* else if(Vector3.Distance(target.transform.position, this.transform.position)<attackDistance)
        {
            currentState=STATE.ATTACK;
        }*/
        print("This is LookForState");
    }
    public void Goto()
    {
        anim.SetTrigger("isRunning");
        if (Vector3.Distance(target.transform.position, this.transform.position) > attackDistance)
        {
            Debug.Log("Attacking");
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
        anim.SetTrigger("isAttacking");
    time = time + Time.deltaTime;
        if (time > 2f)
        {
            // GameObject temp=Instantiate(ObjectPoolScript.instance.GetObjectsFromPool("Asteroid"),new Vector3(Random.Range(-8.0f, 8f),4f,0f),Quaternion.identity);
            GameObject tempFire = ObjectPool.instance.GetObjectsFromPool("Fire");
            tempFire.SetActive(true);
            tempFire.transform.position = this.transform.position + offSet;


            time = 0;
        }
        if (Vector3.Distance(target.transform.position, this.transform.position) > attackDistance)
        {
            currentState = STATE.GOTO;
        }
        else if(Vector3.Distance(target.transform.position, this.transform.position) > gotoDistance)
        {
            currentState |= STATE.LOOKFOR;
        }
        print("This is AttackState");
    }
    public void Dead()
    {
        anim.SetTrigger("isDead");
        StartCoroutine(Fade());
       // this.gameObject.SetActive(false);
        print("Enemy Dead");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            collision.gameObject.SetActive(false);
            Dead();
        }
    }
    IEnumerator Fade()
    {

        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
   
    }




