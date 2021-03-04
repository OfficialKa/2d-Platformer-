using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public static int hearth = 3;
    public Transform startPos;
    private bool lookRight = true;
    private bool lookLeft = false;
    private bool moveRight = false;
    public float timeToMoveRight = 1f;
    public float timeToMoveLeft = 1f;
    private Rigidbody2D enemyRb;
    private Animator anim;
    public static bool shouldMove = true;
    public static bool shouldShoot = true;
    public GameObject Character;
    public float speed = 5f;
    public static bool moveLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        anim = GetComponent<Animator>();
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveRight && shouldMove)
        {
            MoveRight();
        }
        else if (moveRight && shouldMove)
        {
            MoveLeft();
        }
        else if (!shouldMove)
        {

        }
    }
    private void MoveRight()
    {
        moveLeft = false;
        enemyRb.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
    }
    private void MoveLeft()
    {
        moveLeft = true;
        enemyRb.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
    }
    private void flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0, 180, 0);
    }
    IEnumerator whaitBefDel()
    {
        anim.SetInteger("hearth", hearth);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    IEnumerator Move()
    {
        if (shouldMove)
        {
            yield return new WaitForSeconds(timeToMoveRight);
            moveRight = true;
            moveLeft = false;
            flip();
            yield return new WaitForSeconds(timeToMoveLeft);
            moveRight = false;
            moveLeft = true;
            flip();
            StartCoroutine(Move());
        }
    }
}
