using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAlternate : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        float dx = mouse.x - transform.position.x;
        float dy = mouse.y - transform.position.y;
        float a = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, a);
        if (Input.GetKeyDown(KeyCode.Mouse0) && physic.canShoot)
        {
            physic.canShoot = false;
            Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, a));
            StartCoroutine(FireCoolDown());
        }
    }
    IEnumerator FireCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        physic.canShoot = true;
    }
}
