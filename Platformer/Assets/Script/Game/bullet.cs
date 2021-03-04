using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        StartCoroutine(whaitBefDel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(1);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollision2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    IEnumerator whaitBefDel()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
