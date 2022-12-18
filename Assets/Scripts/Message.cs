using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Message", order = 1)]
public class Message : ScriptableObject
{
    public List<string> messages;
}