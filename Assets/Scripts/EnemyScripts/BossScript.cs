using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BossScript : MonoBehaviour
{
    HealthManager health;
    LevelManager levelManager;

    private void Awake()
    {
        health= GetComponent<HealthManager>();
        levelManager= FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
       if (health.GetHealth() <= 0)
       {
            if (gameObject.activeSelf)
            {
                StartCoroutine("DestroyBoss");
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator DestroyBoss()
    {
        GetComponentInChildren<SpriteRenderer>().DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        levelManager.LoadEndGame();
        yield return null;
    }
}
