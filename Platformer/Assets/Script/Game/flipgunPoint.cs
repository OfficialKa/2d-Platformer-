using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipgunPoint : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private bool lookRight = true;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !lookRight)
        {
            Flip();
        }
        else if (move < 0 && lookRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            canShoot = false;
            StartCoroutine(FireCoolDown());
        }
    }
    IEnumerator FireCoolDown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
    void Flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0, 180f, 0);
    }
}
