using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] int score;
    [SerializeField] ParticleSystem explosionEffect;
    int currentHealth=1;

    [SerializeField] bool canShake;
    [SerializeField] bool isPlayer;
    [SerializeField] bool isBoss;
    bool haveShield;
    CameraShake cameraShake;

    AuidioPlayer auidioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        auidioPlayer = FindObjectOfType<AuidioPlayer>();
        cameraShake= Camera.main.GetComponent<CameraShake>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (haveShield && isPlayer && !other.CompareTag("shield"))
        {
            ApplyDamageEffect();
            return;
        }

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            ApplyDamageEffect();
            damageDealer.Hit();
        }
    }

    private void ApplyDamageEffect()
    {
        PlayEffect();
        ShakeCamera();
        auidioPlayer.PlayDamagingClip();
    }

    public int GetHealth()
    {
        return currentHealth; // Just for player and boss
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    void TakeDamage(int damageValue)
    {
        currentHealth-=damageValue;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            if (scoreKeeper != null)
            {
                scoreKeeper.ModifyScore(score);
            }
            else
            {
                scoreKeeper = FindObjectOfType<ScoreKeeper>();
                scoreKeeper.ModifyScore(score);
            }
        }
        else if(isPlayer)
        {
            levelManager.LoadGameOver();
        }
        if (!isBoss)
        {
            Destroy(gameObject);
        }
        auidioPlayer.PlayDestroyingClip();
    }

    void PlayEffect()
    {
        if(explosionEffect != null)
        {
            ParticleSystem newEffect= Instantiate(explosionEffect, transform.position,Quaternion.identity);
            Destroy(newEffect, newEffect.main.duration);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake!= null && canShake)
        {
            cameraShake.PlayCameraShake();
        }
    }

    public void ControlShield(bool statues)
    {
        haveShield= statues;
    }
}
