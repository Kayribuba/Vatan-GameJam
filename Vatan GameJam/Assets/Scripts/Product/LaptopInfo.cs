using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInfo : MonoBehaviour, IProductModel
{
    public ProductType productType { get; set; } = ProductType.Laptop;
    public string productName { get; set; }
    public int productPrice { get; set; }

    [HideInInspector] public E_RAM RAM;
    [HideInInspector] public int DiskSpace;
}
