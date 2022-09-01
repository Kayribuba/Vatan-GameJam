using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType { Laptop, Monitor, Kasa}

public class ProductInfo : MonoBehaviour
{
    public ProductType productType;
    public string productName;
    public string[] features;
    public int productPrice;
}
