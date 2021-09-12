using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (fileName = "Unnamed Liquid", menuName = "Liquid")]
public class Liquid : ScriptableObject
{
    public float volume;
    public Color color;
    public string name;
    public int id;

}
