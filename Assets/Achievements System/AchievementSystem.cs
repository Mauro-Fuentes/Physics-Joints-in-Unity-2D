using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievement System", menuName = "Systems/ Achievement System")]
public class AchievementSystem : ScriptableObject
{
    public List<Achievement> achievements;
}