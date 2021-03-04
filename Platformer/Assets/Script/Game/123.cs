using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingTrigger : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D bullet;
    public Transform gunPoint;
    public float fireRate = 1;
    public Transform player;
    Vector3 playerPos;
    private Rigidbody2D clone;
    float explantedTime = 0.0f;
    void Update()
    {
        playerPos = player.position;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        print("123");
        if (other.gameObject.CompareTag("Player"))
        {
            fireRate = Random.Range(0.5f, 3f);
            explantedTime += Time.deltaTime;    
            if (explantedTime > fireRate && enemy.shouldShoot)
            {
                explantedTime = 0.0f;
                clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
                if (enemy.moveLeft)
                {
                    Flip();
                }
                clone.velocity = transform.right * speed;
            }   
        }
    }
    void Flip()
    {
        transform.Rotate(0, 180f, 0);
    }
}
