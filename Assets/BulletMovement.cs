using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int bulletSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0f, 0f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Fire")
        {
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

}