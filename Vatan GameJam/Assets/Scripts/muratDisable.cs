using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muratDisable : MonoBehaviour
{
    public GameObject tablet;
    public GameObject scanner;
    public void DisableObjects()
    {
        tablet.SetActive(false);
        scanner.SetActive(false);
    }
}
