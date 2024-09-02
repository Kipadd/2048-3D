using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoSingleton<ScoreCounter>
{
    public Text currentScoreText;
    public Text bestScoreText;
    public Text current2048Text;
    public Text best2048Text;

    public int currentScoreNumber;
    public int bestScoreNumber;
    public int current2048Number;
    public int best2048Number;

    private void Start()
    {
        ResetScores();
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateScore(int materialIndex)
    {
        currentScoreNumber += (int)Mathf.Pow(2, materialIndex) / 2;
        current2048Number = Mathf.Max(current2048Number, (int)Mathf.Pow(2, materialIndex + 1));

        if (currentScoreNumber > bestScoreNumber)
        {
            bestScoreNumber = currentScoreNumber;
        }

        if (current2048Number > best2048Number)
        {
            best2048Number = current2048Number;
        }
    }

    public void ResetScores()
    {
        currentScoreNumber = 0;
        current2048Number = 2;

        UpdateUI();
    }

    private void UpdateUI()
    {
        currentScoreText.text = currentScoreNumber.ToString();
        current2048Text.text = current2048Number.ToString();
        bestScoreText.text = bestScoreNumber.ToString();
        best2048Text.text = best2048Number.ToString();
    }
}
