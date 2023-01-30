using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileLifeTime;
    [SerializeField] float baseFireRate;

    [Header("AI")]
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] float minFireRate = .1f;
    [SerializeField] bool isAI;

    Coroutine firingCoroutine;

    [HideInInspector]
    public bool isFiring;

    AuidioPlayer auidioPlayer;

    private void Awake()
    {
        auidioPlayer= FindObjectOfType<AuidioPlayer>();
    }

    private void Start()
    {
        isFiring = isAI ? true: false;
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine==null)
        {
            firingCoroutine = StartCoroutine("FireContinuosly");
        }
        else if (!isFiring && firingCoroutine!=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine= null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while (isFiring)
        {
            GameObject newProjectile = Instantiate(projectile,transform.position,Quaternion.identity);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(newProjectile, projectileLifeTime);

            float fireRate = UnityEngine.Random.Range(baseFireRate-fireRateVariance,baseFireRate+fireRateVariance);
            Mathf.Clamp(fireRate, minFireRate, float.MaxValue);

            auidioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(fireRate);
        }
        
    }
}
