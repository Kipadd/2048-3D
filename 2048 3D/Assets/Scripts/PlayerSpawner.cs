using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance = null;
    public GameObject[] prefabToSpawn;
    public GameObject startCube;
    public float interval = 5f;
    public int counter = 0;
    private Vector3 StartCubePosition = new Vector3(0,0.34f,-2.22f);

    public GameObject panelScore, area, panelMenu,BordersMenu, borders;


    private void Awake()
    {
        // ����������, ��� ������ ���� ��������� ������� Spawner ����������
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (area.active)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (counter == 0)
                {
                    Invoke("SpawnPrefab", interval);
                    counter += 1;
                }
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
    public void SpawnStartCube()
    {
        Instantiate(startCube, StartCubePosition ,transform.rotation);
    }
    public void BtnYes()
    {
        panelScore.SetActive(true);
        area.SetActive(true);
        BordersMenu.SetActive(false);
        borders.SetActive(true);
        SpawnStartCube();
    }
    public void BtnNo()
    {
        panelScore.SetActive(true);
        area.SetActive(true);
        BordersMenu.SetActive(false);
        SpawnStartCube();
    }

    public void GameStart()
    {
        panelMenu.SetActive(false);
        BordersMenu.SetActive(true);
    }
}
