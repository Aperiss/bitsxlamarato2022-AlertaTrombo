using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Calf", menuName = "ScriptableObjects/CalfParams")]
public class CalfParameters : ScriptableObject
{
    public float maxWpm;
    public float maxVelocity;
    public float rawWpm;
    public float averageWpm;
    public float wordCountAverage;
    public float wordCountAverageWpm;
}