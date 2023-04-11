using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{

    Vector3 startPos;

    public float frequency = 2;
    public float magnitude = 2;
    public float offset = 0;
    //public float moveSpeed = 5;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //startPos = transform.position;
        transform.position = startPos + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
        //transform.Translate(new Vector3(0, 0, moveSpeed)*Time.deltaTime);
        //transform.position = (new Vector3(0, 0, -moveSpeed));
    }
}
