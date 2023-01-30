using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!transform.IsChildOf(player))
            {
                gameObject.layer = 11;
                transform.parent = player;
                transform.parent.GetComponent<HealthManager>().ControlShield(true);
                transform.localPosition = Vector3.zero;
            }
        }

        else
        {
            Destroy(collision.gameObject);
            Invoke("DisableShield", .2f);
            Destroy(gameObject,.5f);
            
        }
    }

    void DisableShield()
    {
        transform.parent.GetComponent<HealthManager>().ControlShield(false);
    }
}
