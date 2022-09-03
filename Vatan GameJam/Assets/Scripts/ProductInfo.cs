using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType { Laptop, Monitor, Kasa, VacuumCleaner, TV, Keyboard, Cellphone, Headphone, Mouse, Printer, UNKNOWN}

public class ProductInfo : MonoBehaviour
{
    public ProductType productType;
    public string productName;
    public string[] features;
    public int productPrice;
}
