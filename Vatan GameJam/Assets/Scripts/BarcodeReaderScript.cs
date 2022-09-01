using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BarcodeReaderScript : MonoBehaviour
{
    public event EventHandler<ProductInfo> SetProductEvent;

    [Header("Reference")]
    [SerializeField] Camera kamera;
    [SerializeField] LayerMask LayersToSee;
    [SerializeField] Canvas crossHair;

    [Header("Variable")]
    [SerializeField] float reach = 10f;

    [Header("Option")]
    [SerializeField] bool showRaycast;

    Ray ray;
    ProductInfo productInfo;
    bool isSeeingLayers;

    void Start()
    {
        if (kamera == null && gameObject.GetComponent<Camera>() != null)
            kamera = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        RaycastHit hitInfo;
        ray = new Ray(kamera.transform.position, kamera.transform.forward);
        Physics.Raycast(ray, out hitInfo, reach, LayersToSee);//---Kameradan Ray Cast'lendi---

        isSeeingLayers = hitInfo.collider != null;
        crossHair.enabled = isSeeingLayers;

        if (isSeeingLayers)//---Hedeflenen ürün raycast'e yakalandý---
        {
            ProductInfo newProductInfo = hitInfo.transform.GetComponent<ProductInfo>();

            if (newProductInfo != productInfo)//---Yeni birþey yakalandý---
            {
                productInfo = newProductInfo;

                SetProductEvent?.Invoke(this, productInfo);//---Event yoluyla yollandý---
            }

            if (crossHair != null)
                crossHair.transform.position = hitInfo.point;
        }
    }

    void OnDrawGizmos()
    {
        if (showRaycast)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ray.GetPoint(reach), .2f);
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * reach);
        }
    }
}
