using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = .5f;
    Vector3 firstPos; 

    void Start()
    {
        firstPos= transform.position;
    }

    public void PlayCameraShake()
    {
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {
        float shakeTime=0;

        while(shakeTime<= shakeDuration)
        {
            transform.position = firstPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }        

        transform.position = firstPos;
    }
}
