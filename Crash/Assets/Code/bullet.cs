using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed, lifeTime, distance;
    public int damage;
    public LayerMask whaitIsSolid;
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whaitIsSolid);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        //if (hitInfo.collider != null)
        //{
        //    if (hitInfo.collider.CompareTag("Enemy"))
        //    {
        //        hitInfo.collider.GetComponent<Enemy>().takeDmg(damage);
        //    }
        //    Destroy(gameObject);
        //}
        print("2");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("2");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
