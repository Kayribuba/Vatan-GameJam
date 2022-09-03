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

                string[][] UseThese = new string[4][] { Features.LaptopGraphicsCard, Features.LaptopProcessor, Features.LaptopRAM, Features.LaptopStorageSpace };
                SetFeatures(ref pm.features, UseThese);
                //pm.features = new string[4];
                //pm.features[0] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
                //pm.features[1] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
                //pm.features[2] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
                //pm.features[3] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
            }
            else if (go.CompareTag(Constants.MonitorTag))
            {
                pm.productType = ProductType.Monitor;
                pm.productPrice = 4000;

                string[][] UseThese = new string[][] { Features.MonitorScreenSize, Features.ScreenResolution, Features.MonitorRefreshRate };
                SetFeatures( ref pm.features, UseThese);
            }
            else if(go.CompareTag(Constants.BilgisayarKasaTag))
            {
                pm.productType = ProductType.Kasa;
                pm.productPrice = 30000;

                string[][] UseThese = new string[][] { Features.LaptopProcessor, Features.RAM, Features.LaptopStorageSpace };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.VacuumCleanerTag))
            {
                pm.productType = ProductType.VacuumCleaner;
                pm.productPrice = 5000;

                string[][] UseThese = new string[][] { Features.DirtCapacity, Features.VacuumCleanerWeight, Features.SuctionPower };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.TVTag))
            {
                pm.productType = ProductType.TV;
                pm.productPrice = 5500;

                string[][] UseThese = new string[][] { Features.TVScreenSize, Features.ScreenResolution, Features.SatelliteReceiver };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.KeyBoardTag))
            {
                pm.productType = ProductType.Keyboard;
                pm.productPrice = 1250;

                string[][] UseThese = new string[][] { Features.Switch, Features.KeyboardWeight, Features.BackLit };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.CellPhoneTag))
            {
                pm.productType = ProductType.Cellphone;
                pm.productPrice = 3500;

                string[][] UseThese = new string[][] { Features.CellPhoneStorageSpace, Features.CellPhoneMemory, Features.CellPhoneWeight };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.HeadphoneTag))
            {
                pm.productType = ProductType.Headphone;
                pm.productPrice = 930;

                string[][] UseThese = new string[][] { Features.HeadPhoneWeight, Features.ConnectionType, Features.Microphone };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.MouseTag))
            {
                pm.productType = ProductType.Mouse;
                pm.productPrice = 331;

                string[][] UseThese = new string[][] { Features.NumberOfMouseButtons, Features.MouseWeight, Features.ConnectionType };
                SetFeatures( ref pm.features, UseThese);
            }
            else if (go.CompareTag(Constants.PrinterTag))
            {
                pm.productType = ProductType.Printer;
                pm.productPrice = 6452;

                string[][] UseThese = new string[][] { Features.PrinterSpeed, Features.PrinterWeight, Features.PrinterResolution };
                SetFeatures( ref pm.features, UseThese);
            }
            else
            {
                pm.productType = ProductType.UNKNOWN;
                pm.productPrice = 0;

                pm.features = new string[1];
                pm.features[0] = Features.DebugMessages[0];
            }
        }
    }
    void SetFeatures(ref string[] pmFeatures, string[][] setTo)
    {
        pmFeatures = new string[setTo.Length];

        for (int i = 0; i < pmFeatures.Length; i++)
            pmFeatures[i] = setTo[i][Random.Range(0, setTo[i].Length)];
    }
}
