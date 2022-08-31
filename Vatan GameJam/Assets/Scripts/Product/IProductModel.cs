using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType { Laptop, Monitor, Kasa}

public interface IProductModel
{
    ProductType productType { get; set; }
    string productName { get; set; }
    int productPrice { get; set; }
}
