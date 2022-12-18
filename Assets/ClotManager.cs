using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClotManager : MonoBehaviour
{
    public ProgressBar progressBar;
    public List<MeshRenderer> ClotRenderers;

    private void OnEnable()
    {
        int index = 0;
        foreach (var meshRenderer in ClotRenderers)
        {
            index++;
            if (progressBar.progress * ClotRenderers.Count < index)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int index = 0;
        foreach (var meshRenderer in ClotRenderers)
        {
            index++;
            if (progressBar.progress * ClotRenderers.Count < index)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = true;
            }
        }
    }
}
