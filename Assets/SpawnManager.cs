using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject asteroid;
    float time;
    float enemyTime;
    PlayerMovement PlayerMovement;
    
    // Start is called  the first frame update
    void Start()
    {
        PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       if (!PlayerMovement.isGameOver)
        {
           
            enemyTime=enemyTime + Time.deltaTime;
            if(enemyTime>8f)
            { 
            GameObject tempEnemy = (ObjectPool.instance.GetObjectsFromPool("Enemy"));
            tempEnemy.transform.position = new Vector3(Random.Range(-3.0f, 6f), Random.Range(-3.0f, 3f), 0f);
                     tempEnemy.SetActive(true);
                     enemyTime = 0;
                 }
            }
           
        }


    }
