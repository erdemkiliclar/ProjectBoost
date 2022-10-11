using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    float movementFactor;

    
    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {

        if (period <= Mathf.Epsilon){ return; }
        float cycles = Time.time / period; //zaman i�inde s�rekli b�y�yecektir

        const float tau = Mathf.PI * 2;  // const sabir bir de�i�ken demektir. bizim g�ncellemeye ya da de�i�tirmeye �al��aca��m�z bir �ey de�il. sabit de�er 6 d�r
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 den 1 e gitmek i�in 

        movementFactor = (rawSinWave + 1f) / 2f; // 0 dan 1 e gitmek i�in yeniden hesaplan�r

        Vector3 ofset = movementVector * movementFactor;
        transform.position = startingPosition + ofset;
    }
}
