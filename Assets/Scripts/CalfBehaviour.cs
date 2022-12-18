using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CalfBehaviour : MonoBehaviour
{
    private float increment = 0;
    public CalfParameters parameters;
    public bool isLeft = false;

    void Start()
    {
        parameters.averageWpm = 0;
        parameters.rawWpm = 0;
        parameters.wordCountAverageWpm = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        float legSpeed = Mathf.Lerp(0.0f, parameters.maxVelocity, parameters.wordCountAverageWpm / parameters.maxWpm);
        increment += legSpeed * Time.deltaTime;
        if(isLeft)
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * Mathf.Sin(increment) * legSpeed;
        else
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * Mathf.Cos(increment) * legSpeed;
    }
}
