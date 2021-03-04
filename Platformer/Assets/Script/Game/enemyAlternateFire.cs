using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAlternateFire : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = player.transform.position.x - this.transform.position.x;
        float dy = player.transform.position.y - this.transform.position.y;
        float a = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, a);
        this.transform.rotation = rotation;
    }
}
