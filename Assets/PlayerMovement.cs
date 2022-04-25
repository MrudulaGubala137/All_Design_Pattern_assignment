using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed;
    public float health;
    // public GameObject bulletPrefab;
    
    public Vector3 offSet;
    //public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        transform.Translate(inputX*playerSpeed*Time.deltaTime, inputY * playerSpeed * Time.deltaTime, 0f);
        //Clamp player position within gameWindow
        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }
        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }

        if (transform.position.x > 7.0f)
        {
            transform.position = new Vector3(-7.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.0f)
        {
            transform.position = new Vector3(-7.0f, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            {

                GameObject tempBullet = ObjectPool.instance.GetObjectsFromPool("Bullet");
                tempBullet.transform.position = this.transform.position + offSet;
                // transform.Translate(0f, 0f, 1f);
                tempBullet.SetActive(true);
                //Instantiate(bulletPrefab, transform.position + offSet, Quaternion.identity);
            }
        }
        
            
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            collision.gameObject.SetActive(false);
           print("player Health Dec:" + health);

        }

    }
    
}

