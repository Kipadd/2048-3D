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
    GameObject[] delete;

    public GameObject panelScore, area, panelMenu,BordersMenu, borders;
    public GameObject btnPause, Pausepanel, btncontinue, btnendgame;


    private void Awake()
    {
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
        if (area.active && !Pausepanel.active)
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
        delete = GameObject.FindGameObjectsWithTag("Cube");
      
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

    public void Pause()
    {
        Pausepanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BtnYes()
    {
        panelScore.SetActive(true);
        area.SetActive(true);
        BordersMenu.SetActive(false);
        borders.SetActive(true);
        SpawnStartCube();
        btnPause.SetActive(true);
        ScoreRestart(ScoreCounter.instance.currentScoreNumber, ScoreCounter.instance.current2048Number);
    }
    public void BtnNo()
    {
        panelScore.SetActive(true);
        area.SetActive(true);
        BordersMenu.SetActive(false);
        SpawnStartCube();
        btnPause.SetActive(true);
        ScoreRestart(ScoreCounter.instance.currentScoreNumber, ScoreCounter.instance.current2048Number);
    }
    public void Continue()
    {
        Pausepanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void EndGame()
    {
        Time.timeScale = 1.0f;
        Pausepanel.SetActive(false);
        panelScore.SetActive(false);
        panelMenu.SetActive(true);
        area.SetActive(false);
        for(int i = 0; i < delete.Length; i++)
        {
            Destroy(delete[i]);
        }
        if (ScoreCounter.instance.currentScoreNumber > ScoreCounter.instance.bestScoreNumber)
        {
            ScoreCounter.instance.bestScoreNumber = ScoreCounter.instance.currentScoreNumber;

        }
        if (ScoreCounter.instance.current2048Number > ScoreCounter.instance.best2048Number)
        {
            ScoreCounter.instance.best2048Number = ScoreCounter.instance.current2048Number;

        }
    }

    public void GameStart()
    {
        panelMenu.SetActive(false);
        BordersMenu.SetActive(true);
    }
    public void ScoreRestart(int cS, int c2)
    {
        ScoreCounter.instance.currentScoreNumber = 0;
        ScoreCounter.instance.current2048Number = 0;

    }
}
