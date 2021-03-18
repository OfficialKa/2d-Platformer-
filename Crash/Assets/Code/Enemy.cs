using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    void Update()
    {
        if (health <=0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDmg(int damage)
    {
        health -= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("1");
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (health >= 0)
            {
                health--;
            }
            else if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
