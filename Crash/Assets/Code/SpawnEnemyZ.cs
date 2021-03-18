using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyZ : MonoBehaviour
{
    public GameObject[] zombies;
    public float whaitSpawn;
    private float[] positions = {-4f, -2f, 4f, 2f};
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(zombies[Random.Range(0, zombies.Length)], new Vector3(positions[Random.Range(0, 4)], 6, 0),
                Quaternion.Euler(new Vector3(0, 0, 180)));
        }
    }
}
