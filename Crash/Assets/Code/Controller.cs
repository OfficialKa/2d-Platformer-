using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float xСhange;
    public float minPos;
    public float maxPos;
    public float speed;
    public int health;
    private Vector2 targetPos;
    private Rigidbody2D rb;
    private Transform Enemy;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        print("123");
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < maxPos)
        {
            targetPos = new Vector2(transform.position.x + xСhange, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minPos)
        {
            targetPos = new Vector2(transform.position.x - xСhange, transform.position.y );
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && health <= 0)
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy") && health != 0)
        {
            health--;
        }
    }
}
