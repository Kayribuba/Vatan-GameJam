using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPopulator : MonoBehaviour
{
    public List<ProductInfo> AllProducts = new List<ProductInfo>();

    [SerializeField] int NumberOfItemsToSelect = 15;
    public List<ProductInfo> SelectedProducts { get; private set; } = new List<ProductInfo>();

    List<string> usedCodes = new List<string>();
    int DolarTlKuru;
    int priceMultiplier = 1;

    void Awake()
    {
        int disposable2 = Random.Range(1, 101);
        DolarTlKuru = disposable2 == 31 ? Random.Range(1, 10) : Random.Range(10, 21);//100de 1 ihtimal dolar kuru 10 tlden düþük olucak

        List<GameObject> AllProductGOsInTheScene = new List<GameObject>();

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
            string[][] UseThese = null;
            if (go.CompareTag(Constants.LaptopTag))
            {
                pm.productType = ProductType.Laptop;
                priceMultiplier = 10;

                UseThese = new string[4][] { Features.LaptopGraphicsCard, Features.LaptopProcessor, Features.LaptopRAM, Features.LaptopStorageSpace };

                //pm.features = new string[4];
                //pm.features[0] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
                //pm.features[1] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
                //pm.features[2] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
                //pm.features[3] = GetRandomStringFromArray(Features.LaptopGraphicsCard);
            }
            else if (go.CompareTag(Constants.MonitorTag))
            {
                pm.productType = ProductType.Monitor;
                priceMultiplier = 7;

                UseThese = new string[][] { Features.MonitorScreenSize, Features.ScreenResolution, Features.MonitorRefreshRate };
            }
            else if(go.CompareTag(Constants.BilgisayarKasaTag))
            {
                pm.productType = ProductType.Kasa;
                priceMultiplier = 12;

                UseThese = new string[][] { Features.LaptopProcessor, Features.RAM, Features.LaptopStorageSpace };
            }
            else if (go.CompareTag(Constants.VacuumCleanerTag))
            {
                pm.productType = ProductType.VacuumCleaner;
                priceMultiplier = 5;

                UseThese = new string[][] { Features.DirtCapacity, Features.VacuumCleanerWeight, Features.SuctionPower };
            }
            else if (go.CompareTag(Constants.TVTag))
            {
                pm.productType = ProductType.TV;
                priceMultiplier = 9;

                UseThese = new string[][] { Features.TVScreenSize, Features.ScreenResolution, Features.SatelliteReceiver };
            }
            else if (go.CompareTag(Constants.KeyBoardTag))
            {
                pm.productType = ProductType.Keyboard;
                priceMultiplier = 4;

                UseThese = new string[][] { Features.Switch, Features.KeyboardWeight, Features.BackLit };
            }
            else if (go.CompareTag(Constants.CellPhoneTag))
            {
                pm.productType = ProductType.Cellphone;
                priceMultiplier = 8;

                UseThese = new string[][] { Features.CellPhoneStorageSpace, Features.CellPhoneMemory, Features.CellPhoneWeight };
            }
            else if (go.CompareTag(Constants.HeadphoneTag))
            {
                pm.productType = ProductType.Headphone;
                priceMultiplier = 3;

                UseThese = new string[][] { Features.HeadPhoneWeight, Features.ConnectionType, Features.Microphone };
            }
            else if (go.CompareTag(Constants.MouseTag))
            {
                pm.productType = ProductType.Mouse;
                priceMultiplier = 2;

                UseThese = new string[][] { Features.NumberOfMouseButtons, Features.MouseWeight, Features.ConnectionType };
            }
            else if (go.CompareTag(Constants.PrinterTag))
            {
                pm.productType = ProductType.Printer;
                priceMultiplier = 6;

                UseThese = new string[][] { Features.PrinterSpeed, Features.PrinterWeight, Features.PrinterResolution };
            }
            else
            {
                pm.productType = ProductType.UNKNOWN;
                pm.productPrice = 0;

                pm.features = new string[1];
                pm.features[0] = Features.DebugMessages[0];
            }

            if (UseThese != null)
                SetFeaturesAndPrice(ref pm, UseThese);

            pm.productPrice *= priceMultiplier;

            AllProducts.Add(pm);
        }

        List<int> usedNumbers = new List<int>();
        for(int i = 0; i < NumberOfItemsToSelect; i++)
        {
            int randomNumber = -1;
            while (true)
            {
                randomNumber = Random.Range(0, AllProducts.Count);
                if(!usedNumbers.Contains(randomNumber))
                {
                    usedNumbers.Add(randomNumber);
                    break;
                }
            }

            SelectedProducts.Add(AllProducts[randomNumber]);
        }
    }

    void SetFeaturesAndPrice(ref ProductInfo pm, string[][] setTo)
    {
        pm.features = new string[setTo.Length];
        float price = 0;

        int tries = 0;
        while (true)
        {
            string code = pm.productType.ToString();
            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < pm.features.Length; i++)
            {
                int randomNumber = Random.Range(0, setTo[i].Length);
                randomNumbers.Add(randomNumber);
                code += randomNumber;
            }
            if (!usedCodes.Contains(code))
            {
                for (int i = 0; i < randomNumbers.Count; i++)
                {
                    pm.features[i] = setTo[i][randomNumbers[i]];
                    price += KayribubasThings.primeNumbers[randomNumbers[i]] * DolarTlKuru * Random.Range(2f, 3f);
                }
                break;
            }

            tries++;
            if (tries >= 400)
            {
                Debug.Log($"<ERROR - Setting random features to {pm.name} has failed after {tries} tries.>");
                for (int i = 0; i < pm.features.Length; i++)
                {
                    int randomNumber = Random.Range(0, setTo[i].Length);
                    pm.features[i] = setTo[i][randomNumber];
                    price += KayribubasThings.primeNumbers[randomNumber] * DolarTlKuru * Random.Range(2f, 3f);
                }
                break;
            }
        }

        price /= setTo.Length;
        pm.productPrice = (int)Mathf.Ceil(price);
    }
}
