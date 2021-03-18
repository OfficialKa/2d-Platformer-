using UnityEngine;
using UnityEditor;

public class moveAndSpawnRoad : MonoBehaviour
{
    public float speed = 2f;
    public GameObject road;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -7.26)
        {
            Instantiate(road, new Vector3(0f, 16.3f, 0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
