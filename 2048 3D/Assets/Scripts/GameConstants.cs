
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    public float MoveSpeed = 1.0f;
    public float MinXPosition = -1.04f;
    public float MaxXPosition = 1.04f;
    public float PushForce = 12f;

    public Vector3 playerSpawnPosition = new Vector3(0, 0.5f, -2.5f);
    public float spawnInterval = 1f;
    public readonly Vector3 startCubePosition = new Vector3(0, 0.34f, -2.22f);
}
