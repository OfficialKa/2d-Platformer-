using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_enemy : MonoBehaviour
{
    private Transform Player;
    public float speed = 0.1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.Find("kobum").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Player.position, 0.01f);
        Vector2 delta = Player.position + GetComponent<Transform>().position;
        delta.Normalize();
        transform.Translate(delta * speed * Time.deltaTime);
        float andle = Mathf.Atan2(delta.x, delta.y) * Mathf.Rad2Deg;
        rb.rotation = andle;
    }
}
