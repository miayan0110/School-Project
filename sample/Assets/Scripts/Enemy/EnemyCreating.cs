using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreating : MonoBehaviour
{
    public GameObject Square;

    float lowerBoundX, upBoundX, lowerBoundY, upBoundY;
    Vector3 creatingPoint;

    void Start()
    {
        //creatingPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        lowerBoundX = -8.0f;
        lowerBoundY = -4.5f;
        //creatingPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, Camera.main.nearClipPlane));
        upBoundX = 8.0f;
        upBoundY = 4.5f;
    }

    void Update()
    {
        GeneratingSquare();
    }

    void GeneratingSquare()
    {
        creatingPoint = new Vector3(Random.Range(lowerBoundX, upBoundX), Random.Range(lowerBoundY, upBoundY), 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Square, creatingPoint, transform.rotation);
        }
    }
}
