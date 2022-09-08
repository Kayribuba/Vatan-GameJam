using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoCarrierr : MonoBehaviour
{

    [Header("Options")]
    [SerializeField] bool DestroyAfterUsage = true;

    public string[] Types { get; private set; }
    public string[] Names { get; private set; }
    public string[][] Features { get; private set; }
    public int[] Prices { get; private set; }

    public void SetInfo(ProductInfo[] Info)
    {
        Types = new string[Info.Length];
        Names = new string[Info.Length];
        Prices = new int[Info.Length];
        Features = new string[Info.Length][];

        for (int i = 0; i < Info.Length; i++)
        {
            Types[i] = Info[i].productType.ToString();
            Names[i] = Info[i].productName;
            Prices[i] = Info[i].productPrice;
            Features[i] = Info[i].features;
        }

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)//Sahne yüklendiði zaman
    {
        var HD = FindObjectOfType<HostDialogue>();
        if (HD != null && (Types != null && Names != null && Features != null && Prices != null))
        {
            HD.SetInfo(Types, Names, Features, Prices);

            if (DestroyAfterUsage)
                Destroy(gameObject);
        }
    }
}
