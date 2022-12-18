using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinProgressBar : MonoBehaviour
{
    public float progress;

    // Update is called once per frame

    public void OnEnable()
    {
        progress = 0;

        this.transform.localScale = new Vector3(0.8f, Mathf.Lerp(0.02f, 0.97f, progress), 1.3f);
        this.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(-0.475f, 0f, progress), 0f);

    }
    
    void Update()
    {
        progress += 0.025f * Time.deltaTime;
        progress = Mathf.Clamp(progress, 0.0f, 1.0f);

        this.transform.localScale = new Vector3(0.8f, Mathf.Lerp(0.02f, 0.97f, progress), 1.3f);
        this.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(-0.475f, 0f, progress), 0f);

    }

    public void OnDisable()
    {
        progress = 0;
        
        this.transform.localScale = new Vector3(0.8f, Mathf.Lerp(0.02f, 0.97f, progress), 1.3f);
        this.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(-0.475f, 0f, progress), 0f);
    }
}
