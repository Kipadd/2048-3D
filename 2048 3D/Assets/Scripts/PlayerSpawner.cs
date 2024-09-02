using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerSpawner : MonoSingleton<PlayerSpawner>
{
    public GameObject[] prefabsToSpawn;
    public GameObject startCubePrefab;
    public Vector3 playerSpawnPosition = new Vector3(0, 0.5f, -2.5f);
    public float spawnInterval = 5f;

    private int spawnCounter = 0;
    private readonly Vector3 startCubePosition = new Vector3(0, 0.34f, -2.22f);
    public UIController uiController;

    private GameObject[] delete;

    void Update()
    {
        if (uiController.IsGameAreaActive() && !uiController.IsPausePanelActive())
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (spawnCounter == 0)
                {
                    Invoke("SpawnPrefab", spawnInterval);
                    spawnCounter += 1;
                }
            }
        }
        delete = GameObject.FindGameObjectsWithTag("Cube");

    }
    public void SpawnPrefab()
    {
        float randomValue = Random.value;
        if (randomValue <= 0.75f)
        {
            Instantiate(prefabsToSpawn[0], transform.position, transform.rotation);
        }
        else
        {
            Instantiate(prefabsToSpawn[1], transform.position, transform.rotation);
        }
        spawnCounter = 0;
    }
    public void SpawnStartCube()
    {
        Instantiate(startCubePrefab, startCubePosition, transform.rotation);
    }


    public void ResetGame()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            Destroy(cube);
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            Destroy(player);
        }

        ScoreCounter.Instance.ResetScores();
        UIController.Instance.ShowScorePanel();
    }
}
