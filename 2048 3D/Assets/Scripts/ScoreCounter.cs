using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text currentScore, bestScore, current2048, best2048;

    public static ScoreCounter instance = null;
    public int cS_str, bS_str, c2_str, b2_str;

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
    private void Start()
    {
        currentScore.text = "0";
        current2048.text = "0";
        c2_str = 2;
    }

    private void Update()
    {
        currentScore.text = cS_str.ToString();
        current2048.text = c2_str.ToString();
    }
}
