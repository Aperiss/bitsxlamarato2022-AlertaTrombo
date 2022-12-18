using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "ScriptableObjects/DifficultySettings")]
public class DifficultySettings : ScriptableObject
{
    public float ClotRate;
    public float TargetWpm;
}
