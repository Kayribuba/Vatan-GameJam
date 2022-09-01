using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPopulator : MonoBehaviour
{
    List<GameObject> AllProductGOsInTheScene = new List<GameObject>();

    void Awake()
    {
        GameObject[] disposable1 = FindObjectsOfType<GameObject>();
        foreach(GameObject go in disposable1)
        {
            if (go.layer == LayerMask.NameToLayer(Constants.ProductLayerName))
                AllProductGOsInTheScene.Add(go);
        }

        foreach (GameObject go in AllProductGOsInTheScene)
        {
            if (go.GetComponent<ProductInfo>() == null)
                go.AddComponent(typeof(ProductInfo));
            ProductInfo pm = go.GetComponent<ProductInfo>();

            pm.productName = go.name;
            if(go.CompareTag(Constants.LaptopTag))
            {
                pm.productType = ProductType.Laptop;
                pm.productPrice = 15000;

                pm.features = new string[1];
                pm.features[0] = Features.RAM[Random.Range(0, 4)];
            }
            else if (go.CompareTag(Constants.MonitorTag))
            {
                pm.productType = ProductType.Monitor;
                pm.productPrice = 4000;

                //pm.features = new string[0];
                //özellikler buraa
            }
            else if(go.CompareTag(Constants.BilgisayarKasaTag))
            {
                pm.productType = ProductType.Kasa;
                pm.productPrice = 30000;

                pm.features = new string[1];
                pm.features[0] = Features.RAM[Random.Range(0, 6)];
            }
        }
    }
}
