using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerSpawner : MonoSingleton<PlayerSpawner>
{
    [SerializeField] private GameConstants gameConstants;

    public GameObject[] prefabsToSpawn;
    public GameObject startCubePrefab;

    public UIController uiController;

    public int spawnCounter = 0;

    private List<GameObject> spawnedCubes = new List<GameObject>();

    void Update()
    {
        if (uiController.IsGameAreaActive() && !uiController.IsPausePanelActive())
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (spawnCounter == 0)
                {
                    Invoke("SpawnPlayerCube", gameConstants.spawnInterval);
                    spawnCounter += 1;
                }
            }
        }

    }
    public void SpawnPlayerCube()
    {
        float randomValue = Random.value;
        if (randomValue <= 0.75f)
        {
            GameObject newCube = Instantiate(prefabsToSpawn[0], transform.position, transform.rotation);
            spawnedCubes.Add(newCube);
        }
        else
        {
            GameObject newCube = Instantiate(prefabsToSpawn[1], transform.position, transform.rotation);
            spawnedCubes.Add(newCube);
        }
        spawnCounter = 0;
    }
    public void SpawnStartCube()
    {
        GameObject newCube = Instantiate(startCubePrefab, gameConstants.startCubePosition, transform.rotation);
        spawnedCubes.Add(newCube);
    }


    public void ResetGame()
    {
        foreach (var cube in spawnedCubes)
        {
            Destroy(cube);
        }
        spawnedCubes.Clear();

        ScoreCounter.Instance.ResetScores();
        UIController.Instance.ShowScorePanel();
    }
}
