using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class sinematikgec : MonoBehaviour
{
    [SerializeField] string doyouwattoskip = "Press and hold ESC to quit to start menu";
    [SerializeField] string skipping = $"<color=\"red\">Skipping<color=\"white\">";
    [SerializeField] TextMeshProUGUI skippingText;
    [SerializeField] float waitTime = 3f;
    float targetTime = float.MaxValue;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            targetTime = float.MaxValue;
            skippingText.text = doyouwattoskip;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            targetTime = Time.time + waitTime;
            skippingText.text = skipping;
        }

        if(targetTime <= Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
