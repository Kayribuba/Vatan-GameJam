using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPopulator : MonoBehaviour
{
    List<IProductModel> AllProductsInTheScene = new List<IProductModel>();

    void Start()
    {
        GameObject[] LaptopsInScene = GameObject.FindGameObjectsWithTag(Constants.LaptopTag);
        foreach(GameObject lgo in LaptopsInScene)
        {
            if (lgo.GetComponent<LaptopInfo>() == null)
                lgo.AddComponent(typeof(LaptopInfo));

            LaptopInfo lInfo = lgo.GetComponent<LaptopInfo>();

            lInfo.RAM = (E_RAM)Random.Range(0,4);

            AllProductsInTheScene.Add(lInfo);
        }
    }
}
