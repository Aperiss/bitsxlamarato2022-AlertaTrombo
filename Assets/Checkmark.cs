using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkmark : MonoBehaviour
{
    public bool isEnabled = false;
    public DifficultySettings settings;

    public float clotRateIncrease;
    public float targetWpmIncrease;
    // Update is called once per frame

    private void OnEnable()
    {
        isEnabled = false;
    }

    public void OnClick()
    {
        Debug.Log("TEST CLICK");
        if (!isEnabled)
        {
            isEnabled = true;
            this.GetComponent<Image>().enabled = true;
            settings.ClotRate += clotRateIncrease;
            settings.TargetWpm += targetWpmIncrease;
        }
        else
        {
            isEnabled = false;
            this.GetComponent<Image>().enabled = false;
            settings.ClotRate -= clotRateIncrease;
            settings.TargetWpm -= targetWpmIncrease;
        }
    }
}
