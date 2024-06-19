using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text currentScoreText, bestScoreText, current2048Text, best2048Text;

    public static ScoreCounter instance = null;
    public int currentScoreNumber, bestScoreNumber, current2048Number, best2048Number;

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
        currentScoreText.text = "0";
        current2048Text.text = "0";
        current2048Number = 2;
        best2048Text.text = "32";
        bestScoreText.text = "54";
        best2048Number = 32;
        bestScoreNumber = 54;
    }

    private void Update()
    {
        currentScoreText.text = currentScoreNumber.ToString();
        current2048Text.text = current2048Number.ToString();
        if(currentScoreNumber >= bestScoreNumber)
        {
            bestScoreText.text = currentScoreNumber.ToString();
        }
        if(current2048Number >= best2048Number)
        {
            best2048Text.text = current2048Number.ToString();
        }
    }
}
