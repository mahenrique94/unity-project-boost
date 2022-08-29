using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    private int currentSceneIndex = 0;

    private void Awake()
    {
        this.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        this.ProcessLevelCheats();
        this.ProcessPhisicCheats();
    }

    private void ProcessLevelCheats()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            SceneManager.LoadScene(this.currentSceneIndex + 1);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            SceneManager.LoadScene(this.currentSceneIndex - 1);
        }
    }

    private void ProcessPhisicCheats()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            GetComponent<Collision>().ToggleCollisions();
        }
    }
}
