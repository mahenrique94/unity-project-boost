using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float thrustSpeed = 1000;
    [SerializeField]
    private float rotateSpeed = 250;
    [SerializeField]
    private AudioClip engineClip;
    [SerializeField]
    private ParticleSystem engineParticle;

    private Rigidbody rb;
    private AudioSource audioSource;

    private void ApplyRotation(float direction = 1)
    {
        this.rb.freezeRotation = true;
        transform.Rotate((Vector3.forward * direction) * this.rotateSpeed * Time.deltaTime);
        this.rb.freezeRotation = false;
    }

    public void Crash()
    {
        this.enabled = false;
        this.audioSource.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.ApplyRotation();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.ApplyRotation(-1);
        }
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.StartThrusting();
        }
        else
        {
            this.StopThrusting();
        }
    }

    private void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.ProcessThrust();
        this.ProcessRotation();
    }

    private void StartThrusting()
    {
        this.rb.AddRelativeForce(Vector3.up * this.thrustSpeed * Time.deltaTime);
        if (!this.audioSource.isPlaying)
        {
            this.audioSource.PlayOneShot(this.engineClip);
        }

        if (!this.engineParticle.isPlaying)
        {
            this.engineParticle.Play();
        }
    }

    private void StopThrusting()
    {
        this.audioSource.Stop();
        this.engineParticle.Stop();
    }
}
