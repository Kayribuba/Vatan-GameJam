using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    int currentBuildIndex;
    void Awake()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void GoToNextLevel() => SceneManager.LoadScene(currentBuildIndex + 1);
}
