using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muratDisable : MonoBehaviour
{
    public GameObject tablet;
    public GameObject scanner;
    public void DisableObjects()
    {
        tablet.SetActive(false);
        scanner.SetActive(false);
    }
    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
