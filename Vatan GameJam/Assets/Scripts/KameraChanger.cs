using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraChanger : MonoBehaviour
{
    [SerializeField] Camera[] cameras;

    int index;
    int oldIndex = -1;

    void Update()
    {
        if (cameras != null)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (index > 0)
                        index--;
                    else if (index <= 0)
                        index = cameras.Length - 1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (index < cameras.Length - 1)
                        index++;
                    else if (index >= cameras.Length - 1)
                        index = 0;
                }
            }
        }

        SetCamera(cameras[index]);
    }

    private void SetCamera(Camera cameraToUse)
    {
        if (index != oldIndex)
        {
            foreach (Camera k in cameras)
            {
                if (k != cameraToUse)
                    k.enabled = false;
                else
                    k.enabled = true;
            }

            oldIndex = index;
        }
    }
}
