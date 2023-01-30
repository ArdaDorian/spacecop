using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        if (scoreKeeper != null)
        {
            score_text.text = "Your score:\n" + scoreKeeper.GetScore().ToString("00000");
        }

        else
        {
            scoreKeeper= FindObjectOfType<ScoreKeeper>();
            score_text.text = "Your score:\n" + scoreKeeper.GetScore().ToString("00000");
        }
        
    }

    
}
