using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Planets/newPlanet", fileName = "newPlanet")]
public class Planets : ScriptableObject
{
    public Color color;
    public Vector2 positionBall;
    public float gravity;
}
