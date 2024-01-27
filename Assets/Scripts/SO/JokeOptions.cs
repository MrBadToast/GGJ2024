using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewJokeOptions", menuName = "Scriptable Object/JokeOptions", order = int.MaxValue)]
public class JokeOptions : ScriptableObject
{
    [TextArea]
    public string hint;
    public string proper;
    public string wrong1;
    public string wrong2;
}
