using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlternateFire : MonoBehaviour
{

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Kubom").transform;
    }

    void Update()
    {
        float dx = player.transform.position.x - this.transform.position.x;
        float dy = player.transform.position.y - this.transform.position.y;
        float a = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, a);
        this.transform.rotation = rotation;
    }
}
