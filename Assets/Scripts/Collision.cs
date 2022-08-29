using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private float transitionScenesDelay = 1;
    [SerializeField]
    private AudioClip crashClip;
    [SerializeField]
    private AudioClip landingClip;
    [SerializeField]
    private ParticleSystem crashParticle;
    [SerializeField]
    private ParticleSystem landingParticle;

    private float effectsVolume = 0.1f;
    private bool isPlaying = true;
    private bool hasCollisions = true;

    private AudioSource audioSource;

    public void ToggleCollisions()
    {
        this.hasCollisions = !this.hasCollisions;
    }

    private void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (this.hasCollisions)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("I hit a friend!");
                    break;
                case "Fuel":
                    Debug.Log("I hit a fuel!");
                    break;
                case "Finish":
                    this.Finish();
                    break;
                case "Obstacle":
                    this.Crash();
                    break;
                default:
                    Debug.Log("I don't know this object");
                    break;
            }
        }
    }

    private void Crash()
    {
        if (this.isPlaying)
        {
            this.isPlaying = false;
            GetComponent<Movement>().Crash();
            this.audioSource.PlayOneShot(this.crashClip, this.effectsVolume);
            this.crashParticle.Play();
            Invoke("ReloadScene", this.transitionScenesDelay);
        }
    }

    private void Finish()
    {
        if (this.isPlaying)
        {
            this.isPlaying = false;
            GetComponent<Movement>().Crash();
            this.audioSource.PlayOneShot(this.landingClip, this.effectsVolume);
            this.landingParticle.Play();
            Invoke("GoToNextLevel", this.transitionScenesDelay);
        }
    }

    private int GetCurrenctSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void GoToNextLevel()
    {
        int nextLevelIndex = this.GetCurrenctSceneIndex() + 1;
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        } else
        {
            Debug.Log("Congrats, you have been finished all levels");
        }
        this.isPlaying = true;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(this.GetCurrenctSceneIndex());
        this.isPlaying = true;
    }
}
