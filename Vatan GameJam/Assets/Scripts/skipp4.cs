using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipp4 : MonoBehaviour//yorulduuum
{
    [SerializeField] int buildIndex = 1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}
