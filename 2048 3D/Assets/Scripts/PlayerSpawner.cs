using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance = null;
    public GameObject[] prefabToSpawn;
    public float interval = 5f;
    public int counter = 0;


    // Start is called before the first frame update

    private void Awake()
    {
        // ”беждаемс€, что только один экземпл€р объекта Spawner существует
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SpawnPrefab();

    }
    void Update()
    {
      if(Input.GetMouseButtonUp(0))
        {
            if (counter == 0)
            {
                Invoke("SpawnPrefab", interval);
                counter += 1;
            }
        }
    }
    public void SpawnPrefab()
    {
        
        float randomValue = Random.value;
        if (randomValue <= 0.75f)
        {
            Instantiate(prefabToSpawn[0], transform.position, transform.rotation);
        }
        else
        {
            Instantiate(prefabToSpawn[1], transform.position, transform.rotation);
        }
        counter = 0;
    }
}
