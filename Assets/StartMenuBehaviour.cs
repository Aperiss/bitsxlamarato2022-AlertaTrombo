using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class StartMenuBehaviour : MonoBehaviour
{
    public DifficultySettings settings;
    // Update is called once per frame
    private void OnEnable()
    {
        settings.ClotRate = 0.05f;
        settings.TargetWpm = 30;
    }
}
