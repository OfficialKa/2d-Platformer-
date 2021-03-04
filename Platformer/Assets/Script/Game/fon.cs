using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fon : MonoBehaviour
{
    public Transform CameraTransform;
    private Transform[] layers;

    public float vievZone = 5f;
    private int leftIndex;
    private int rightIndex;
    public float bgSize = 3.65f;
    public float parralaxSpeed;
    public float lastCameraX;
    // Start is called before the first frame update
    void Start()
    {
        lastCameraX = CameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i <transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
            leftIndex = 0;
            rightIndex = layers.Length - 1;

        }
    }

    void ScrollRight()
    {
        float lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + bgSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    void ScrollLeft()
    {
        float lastIndex = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - bgSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0) rightIndex = layers.Length - 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, CameraTransform.position.y);
        layers[leftIndex].transform.position = new Vector2(layers[leftIndex].transform.position.x, CameraTransform.position.y);
        layers[rightIndex].transform.position = new Vector2(layers[rightIndex].transform.position.x, CameraTransform.position.y);
        float deltaX = CameraTransform.position.x - lastCameraX;
        lastCameraX = transform.position.x;
        transform.position += Vector3.right * (deltaX * parralaxSpeed);
        if (CameraTransform.position.x < layers[leftIndex].transform.position.x + vievZone)
        {
            ScrollLeft();
        }
        if (CameraTransform.position.x < layers[rightIndex].transform.position.x - vievZone)
        {
            ScrollRight();
        }
    }
}


















