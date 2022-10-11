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
        float cycles = Time.time / period; //zaman içinde sürekli büyüyecektir

        const float tau = Mathf.PI * 2;  // const sabir bir deðiþken demektir. bizim güncellemeye ya da deðiþtirmeye çalýþacaðýmýz bir þey deðil. sabit deðer 6 dýr
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 den 1 e gitmek için 

        movementFactor = (rawSinWave + 1f) / 2f; // 0 dan 1 e gitmek için yeniden hesaplanýr

        Vector3 ofset = movementVector * movementFactor;
        transform.position = startingPosition + ofset;
    }
}
