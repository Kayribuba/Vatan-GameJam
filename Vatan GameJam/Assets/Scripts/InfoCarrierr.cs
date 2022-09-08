using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCarrierr : MonoBehaviour
{
    public string[] Types;
    public string[] Names;
    public string[][] Features;
    public int[] Prices;
    // { get; private set; }

    public void SetInfo(ProductInfo[] Info)
    {
        //for (int i = 0; i < Info.Length; i++)
        //{
        //    Types[i] = Info[i].ToString();
        //    Names[i] = Info[i].productName;
        //    Prices[i] = Info[i].productPrice;
        //    Features[i] = Info[i].features;
        //}
    }
}
