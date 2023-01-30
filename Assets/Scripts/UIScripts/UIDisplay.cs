using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthBar;
    [SerializeField] HealthManager playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI score_text;
    ScoreKeeper scoreKeeper;


    private void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthBar.maxValue = playerHealth.GetMaxHealth();
    }

    private void Update()
    {
        AdjustHealthBar();
        AdjustScoreText();
    }

    private void AdjustScoreText()
    {
        score_text.text = scoreKeeper.GetScore().ToString("00000");
    }

    private void AdjustHealthBar()
    {
        healthBar.value = playerHealth.GetHealth();
    }
}
