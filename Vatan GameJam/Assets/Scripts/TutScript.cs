using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    int index = -1;

    void Awake()
    {
        OpenNext();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            OpenNext();
    }

    void OpenNext()
    {
        if (index < objects.Length - 1)
        {
            index++;

            for (int i = 0; i < objects.Length; i++)
            {
                if (i == index)
                    objects[i].SetActive(true);
                else
                    objects[i].SetActive(false);
            }
        }
        else
        {
            objects[objects.Length - 1].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
