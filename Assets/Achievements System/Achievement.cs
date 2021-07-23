using UnityEngine;

[CreateAssetMenu(fileName = "Achievement #", menuName = "Systems/ Achievement")]
public class Achievement : ScriptableObject
{
    public string nameOfAchievement;
    public bool status; // true for achieved
}