using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.05f;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), speed) ;                             
    }
}
