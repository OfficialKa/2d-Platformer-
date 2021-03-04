using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalFreze : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void NextScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Kubom"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
