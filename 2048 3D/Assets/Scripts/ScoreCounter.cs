using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text currentScore, bestScore, current2048, best2048;

    public static ScoreCounter instance = null;
    public int cS, bS, c2, b2;

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
    private void Start()
    {
        currentScore.text = "0";
        current2048.text = "0";
        c2 = 2;
        best2048.text = "32";
        bestScore.text = "54";
        b2 = 32;
        bS = 54;
    }

    private void Update()
    {
        currentScore.text = cS.ToString();
        current2048.text = c2.ToString();
        if(cS >= bS)
        {
            bestScore.text = cS.ToString();
        }
        if(c2 >= b2)
        {
            best2048.text = c2.ToString();
        }
    }
}
