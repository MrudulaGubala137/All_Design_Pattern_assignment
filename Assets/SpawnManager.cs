using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject asteroid;
    float time;
    float enemyTime;
    PlayerMovement PlayerMovement;
    public GameObject enemy;
    public Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (!PlayerMovement.isGameOver)
        {*/
            time = time + Time.deltaTime;
        if (time > 3f)
        {
            // GameObject temp=Instantiate(ObjectPoolScript.instance.GetObjectsFromPool("Asteroid"),new Vector3(Random.Range(-8.0f, 8f),4f,0f),Quaternion.identity);
            GameObject tempFire = (ObjectPool.instance.GetObjectsFromPool("Fire"));

            tempFire.transform.position = enemy.transform.position + offSet;
            tempFire.SetActive(true);

            time = 0;
        }
            enemyTime=enemyTime + Time.deltaTime;
            if(enemyTime>6f)
            { 
            GameObject tempEnemy = (ObjectPool.instance.GetObjectsFromPool("Enemy"));
            tempEnemy.transform.position = tempEnemy.transform.position+new Vector3(Random.Range(-3.0f, 3f), 2f, 0f);
                     tempEnemy.SetActive(true);
                     enemyTime = 0;
                 }
            //}
           
        }


    }
