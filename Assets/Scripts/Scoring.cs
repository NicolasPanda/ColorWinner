using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int currentScore = 0;
    public Text currentScoreText;

    private void Update()
    {
        AddOnePoint();
    }

    public void AddOnePoint()
    {
        currentScore++;
        currentScoreText.text = currentScore.ToString();
        Debug.Log(currentScore);
    }

    public void RemoveOnePoint()
    {
        currentScore--;
        currentScoreText.text = currentScore.ToString();
        Debug.Log(currentScore);
    }
}
