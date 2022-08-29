using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private float movementSpeed = 5;

    private Vector3 initialPosition;

    private void Start()
    {
        this.initialPosition = transform.position;
    }

    private void Update()
    {
        if (this.movementSpeed >= Mathf.Epsilon)
        {
            float cycles = Time.time / this.movementSpeed;
            float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(cycles * tau);
            float factor = (rawSinWave + 1) / 2;
            Vector3 offset = this.direction * factor;
            transform.position = this.initialPosition + offset;
        }
    }
}
